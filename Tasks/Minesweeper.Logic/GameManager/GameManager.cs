using System;
using Academits.Karetskas.Minesweeper.Logic.Minefield;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;

namespace Academits.Karetskas.Minesweeper.Logic.GameManager
{
    public sealed class GameManager : IGameManager
    {
        private readonly OptionsManagement _optionsManagement;
        private readonly HighScoresManagement _highScoresManagement;
        private readonly Stopwatch _stopwatch;

        private Map _map;
        private bool _gameCreated;
        private GameOutcome _outcome;

        public event Action<Cell[,]>? RefreshMap;
        public event Action<int>? MinesFoundCount;
        public event Action<GameOutcome>? EndGame;
        public event Action<TimeSpan> TimeUpdate
        {
            add => _stopwatch.TimeUpdate += value;
            remove => _stopwatch.TimeUpdate -= value;
        }

        public GameManager(OptionsManagement optionsManagement)
        {
            _optionsManagement = optionsManagement ?? throw new ArgumentNullException(nameof(optionsManagement),
                $@"The argument {nameof(optionsManagement)} is null.");
            _highScoresManagement = new HighScoresManagement();
            _map = new Map(_optionsManagement.FieldWidth, _optionsManagement.FieldHeight, _optionsManagement.MinesCount);
            _stopwatch = new Stopwatch();
            _outcome = GameOutcome.None;
        }

        public void CreateNewGame()
        {
            if (_map.Height != _optionsManagement.FieldHeight
                || _map.Width != _optionsManagement.FieldWidth
                || _map.MinesCount != _optionsManagement.MinesCount)
            {
                _map = new Map(_optionsManagement.FieldWidth, _optionsManagement.FieldHeight, _optionsManagement.MinesCount);
            }
            else
            {
                _map.Clear();
            }

            _outcome = GameOutcome.None;

            _stopwatch.Stop();
            _stopwatch.Reset();

            MinesFoundCount?.Invoke(_map.MinesCount - _map.MinesFoundCount);

            _gameCreated = true;
        }

        public void CheckCell(int x, int y)
        {
            if (_outcome != GameOutcome.None)
            {
                return;
            }

            if (_gameCreated)
            {
                _map.Mine(x, y);

                _gameCreated = false;

                _stopwatch.Start();
            }

            _map.CheckCell(x, y);

            CheckGameStatus();
        }

        public void CheckNearbyCells(int x, int y)
        {
            if (_outcome != GameOutcome.None)
            {
                return;
            }

            _map.CheckNearbyCells(x, y);

            CheckGameStatus();
        }

        public void LeaveNote(int x, int y)
        {
            if (_outcome != GameOutcome.None)
            {
                return;
            }

            _map.LeaveNote(x, y);

            CheckGameStatus();
        }

        private void RecordGameResult()
        {
            var gameResult = new GameResult((_map.Width, _map.Height), _map.MinesCount, _stopwatch.TimeCounter);
            _highScoresManagement.AddNewGameResultToXml(gameResult);
            _highScoresManagement.SaveToXmlFile();
        }

        private void CheckGameStatus()
        {
            MinesFoundCount?.Invoke(_map.MinesCount - _map.MinesFoundCount);

            _outcome = CheckEndGameConditions();

            if (_outcome == GameOutcome.None)
            {
                RefreshMap?.Invoke(_map.Field);

                return;
            }

            _stopwatch.Stop();

            if (_outcome == GameOutcome.Victory)
            {
                RecordGameResult();
            }

            _map.CheckAllCells();
            RefreshMap?.Invoke(_map.Field);
        }

        private GameOutcome CheckEndGameConditions()
        {
            if (_map.MinesCount == _map.MinesFoundCount &&
                _map.CellsCheckedCount + _map.MinesFoundCount == _map.Field.Length)
            {
                EndGame?.Invoke(GameOutcome.Victory);

                return GameOutcome.Victory;
            }

            if (_map.MineDetonated)
            {
                EndGame?.Invoke(GameOutcome.Defeat);

                return GameOutcome.Defeat;
            }

            return GameOutcome.None;
        }
    }
}
