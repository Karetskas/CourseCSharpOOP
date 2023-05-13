using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public sealed class HighScoresManagement : XmlFileManagement
    {
        private const string FileName = "HighScores.xml";

        private List<GameResult> _gameResults = new(10);

        public IReadOnlyCollection<GameResult> GameResults
        {
            get
            {
                if (_gameResults.Count == 0)
                {
                    UpdateGameResultsList();
                }

                return _gameResults.AsReadOnly();
            }
        }

        public HighScoresManagement() : base(FileName) { }

        private void UpdateGameResultsList()
        {
            //var maxTime = new TimeSpan(23, 59, 59);
            var gameResultsElements = _document?.Root?.Elements("gameResult");

            /*if (gameResultsElements is null)
            {
                for (var i = 0; i < 10; i++)
                {
                    _gameResults.Add(new GameResult((0, 0), 0, maxTime));
                }

                return;
            }*/

            _gameResults.Clear();

            if (gameResultsElements is null)
            {
                return;
            }

            foreach (XElement gameResultElement in gameResultsElements)
            {
                _ = int.TryParse(gameResultElement.Element("field")?.Element("width")?.Value, out var width);
                _ = int.TryParse(gameResultElement.Element("field")?.Element("height")?.Value, out var height);
                _ = int.TryParse(gameResultElement.Element("minesCount")?.Value, out var minesCount);
                //_ = TimeSpan.TryParse(gameResultElement.Element("gameTime")?.Value, out var gameTime);

                var time = gameResultElement.Element("gameTime")?.Value ?? TimeSpan.Zero.ToString();

                var gameTime = TimeSpan.ParseExact(time, @"hh\:mm\:ss\:fff", null);

                /*if (gameTime == TimeSpan.Zero)
                {
                    gameTime = maxTime;
                }*/

                var gameResult = new GameResult((width, height), minesCount, gameTime);

                _gameResults.Add(gameResult);
            }
        }

        protected override void CreateDefaultXmlDocument()
        {
            //UpdateGameResultsList();

            var highScores = new XElement("highScores");

            /*foreach (var gameResult in _gameResults)
            {
                highScores.Add(CreateGameResultElement(gameResult));
            }*/

            _document = new XDocument(highScores);
        }

        public void AddNewGameResultToXml(GameResult gameResult)
        {
            _document?.Root?.Add(CreateGameResultElement(gameResult));

            var gameResults = _document?.Root?.Elements("gameResult")
                .OrderBy(gameResult => gameResult.Element("gameTime")?.Value);

            if (gameResults?.Count() > 10)
            {
                gameResults.Last().Remove();
                _document?.Root?.ReplaceNodes(gameResults);
            }

            /*gameResults.Last().Remove();*/
            _document?.Root?.ReplaceNodes(gameResults);
            
            UpdateGameResultsList();
        }

        private static XElement CreateGameResultElement(GameResult gameResult)
        {
            return new XElement("gameResult",
                new XElement("field",
                    new XElement("width", gameResult.Field.width),
                    new XElement("height", gameResult.Field.height)),
                new XElement("minesCount", gameResult.MinesCount),
                new XElement("gameTime", gameResult.GameTime.ToString(@"hh\:mm\:ss\:fff")));
        }
    }
}
