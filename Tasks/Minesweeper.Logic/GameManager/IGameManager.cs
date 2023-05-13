using System;
using Academits.Karetskas.Minesweeper.Logic.Minefield;

namespace Academits.Karetskas.Minesweeper.Logic.GameManager
{
    public interface IGameManager
    {
        event Action<Cell[,]> RefreshMap;
        event Action<int> MinesFoundCount;
        event Action<GameOutcome> EndGame;
        event Action<TimeSpan> TimeUpdate;

        void CreateNewGame();

        void CheckCell(int x, int y);

        void CheckNearbyCells(int x, int y);

        void LeaveNote(int x, int y);
    }
}
