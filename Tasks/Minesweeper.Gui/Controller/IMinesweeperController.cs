using Academits.Karetskas.Minesweeper.Logic.FileManagement;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Minesweeper.Gui.Controller
{
    public interface IMinesweeperController
    {
        void CreateNewGame();

        void CheckCell(int x, int y);

        void CheckNearbyCells(int x, int y);

        void LeaveNote(int x, int y);

        (int width, int height, int minesCount) GetGameOptions();

        bool IsValidFieldWidth(int fieldWidth);

        bool IsValidFieldHeight(int fieldHeight);

        bool IsValidMinesCount(int minesCount);

        int GetMaxMinesCount();

        void SetFieldWidth(int fieldWidth);

        void SetFieldHeight(int fieldHeight);

        void SetMinesCount(int minesCount);

        void SaveGameOptions();

        IReadOnlyCollection<GameResult> GetGameResults();
    }
}
