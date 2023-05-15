using System.Collections.Generic;
using Academits.Karetskas.Minesweeper.Logic.FileManagement;

namespace Academits.Karetskas.Minesweeper.Gui.Controller
{
    public interface IMinesweeperController
    {
        void CreateNewGame();

        void CheckCell(int x, int y);

        void CheckNearbyCells(int x, int y);

        void LeaveNote(int x, int y);

        (int width, int height, int minesCount) GetGameOptions();

        int GetMaxFieldSize();

        int GetMinFieldSize();

        int GetMaxMinesCount();

        int GetMinMinesCount();

        void SetFieldWidth(int fieldWidth);

        void SetFieldHeight(int fieldHeight);

        void SetMinesCount(int minesCount);

        void SaveGameOptions();

        IReadOnlyCollection<GameResult> GetGameResults();
    }
}
