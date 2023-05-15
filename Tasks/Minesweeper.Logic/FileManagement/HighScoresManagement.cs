using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public sealed class HighScoresManagement : XmlFileManagement
    {
        private const string FileName = "HighScores.xml";

        private readonly List<GameResult> _gameResults = new(10);

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
            var gameResultsElements = _document?.Root?.Elements("gameResult");

            _gameResults.Clear();

            if (gameResultsElements is null)
            {
                return;
            }

            foreach (var gameResultElement in gameResultsElements)
            {
                _ = int.TryParse(gameResultElement.Element("field")?.Element("width")?.Value, out var width);
                _ = int.TryParse(gameResultElement.Element("field")?.Element("height")?.Value, out var height);
                _ = int.TryParse(gameResultElement.Element("minesCount")?.Value, out var minesCount);

                var time = gameResultElement.Element("gameTime")?.Value ?? TimeSpan.Zero.ToString();

                var gameTime = TimeSpan.ParseExact(time, @"hh\:mm\:ss\:fff", null);

                var gameResult = new GameResult((width, height), minesCount, gameTime);

                _gameResults.Add(gameResult);
            }
        }

        protected override void CreateDefaultXmlDocument()
        {
            var highScores = new XElement("highScores");
            
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
