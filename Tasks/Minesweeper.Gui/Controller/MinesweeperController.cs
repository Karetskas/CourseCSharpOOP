using System;
using System.Collections.Generic;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;
using Academits.Karetskas.Minesweeper.Logic.GameManager;

namespace Academits.Karetskas.Minesweeper.Gui.Controller
{
    public sealed class MinesweeperController : IMinesweeperController
    {
        private readonly IGameManager _model;
        private readonly OptionsManagement _optionsManager;

        public MinesweeperController(IGameManager model, OptionsManagement optionsManagement)
        {
            CheckObject(model);
            CheckObject(optionsManagement);

            _model = model;
            _optionsManager = optionsManagement;
        }

        private static void CheckObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        public void CreateNewGame()
        {
            _model.CreateNewGame();
        }

        public void CheckCell(int x, int y)
        {
            _model.CheckCell(x, y);
        }

        public void CheckNearbyCells(int x, int y)
        {
            _model.CheckNearbyCells(x, y);
        }

        public void LeaveNote(int x, int y)
        {
            _model.LeaveNote(x, y);
        }

        public (int width, int height, int minesCount) GetGameOptions()
        {
            return (_optionsManager.FieldWidth, _optionsManager.FieldHeight, _optionsManager.MinesCount);
        }

        public int GetMaxFieldSize()
        {
            return _optionsManager.MaxFieldSize;
        }

        public int GetMinFieldSize()
        {
            return _optionsManager.MinFieldSize;
        }

        public int GetMaxMinesCount()
        {
            return _optionsManager.MaxMinesCount;
        }

        public int GetMinMinesCount()
        {
            return _optionsManager.MinMinesCount;
        }

        public void SetFieldWidth(int fieldWidth)
        {
            _optionsManager.FieldWidth = fieldWidth;
        }

        public void SetFieldHeight(int fieldHeight)
        {
            _optionsManager.FieldHeight = fieldHeight;
        }

        public void SetMinesCount(int minesCount)
        {
            _optionsManager.MinesCount = minesCount;
        }

        public void SaveGameOptions()
        {
            _optionsManager.SaveToXmlFile();
        }

        public IReadOnlyCollection<GameResult> GetGameResults()
        {
            return new HighScoresManagement().GameResults;
        }
    }
}
