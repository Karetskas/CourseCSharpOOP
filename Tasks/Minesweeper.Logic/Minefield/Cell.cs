using System;

namespace Academits.Karetskas.Minesweeper.Logic.Minefield
{
    public sealed class Cell : ICloneable
    {
        public int X { get; }

        public int Y { get; }

        public Status Status { get; set; }

        public Note Note { get; private set; }

        public Information Info { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void GetNextNote()
        {
            if (Note == Note.QuestionMark)
            {
                Note = Note.Empty;

                return;
            }

            Note += 1;
        }

        public void Clear()
        {
            Status = Status.Unchecked;
            Note = Note.Empty;
            Info = Information.Zero;
        }

        public object Clone() => MemberwiseClone();
    }
}
