using System;
using System.Collections.Generic;

namespace Academits.Karetskas.Minesweeper.Logic.Minefield
{
    public sealed class Map
    {
        private readonly Cell[,] _field;

        public Cell[,] Field
        {
            get
            {
                var fieldClone = new Cell[Height, Width];

                WorkWithTwoDimensionalArray((x, y) => fieldClone[x, y] = (Cell)_field[x, y].Clone());

                return fieldClone;
            }
        }

        public int Height => _field.GetLength(0);

        public int Width => _field.GetLength(1);

        public int MinesCount { get; }

        public int MinesFoundCount { get; private set; }

        public int CellsCheckedCount { get; private set; }

        public bool MineDetonated { get; private set; }

        public Map(int width, int height, int minesCount)
        {
            CheckFieldSize(width);
            CheckFieldSize(height);

            var fieldArea = height * width;

            if (minesCount >= fieldArea)
            {
                throw new ArgumentException($"The count of mines \"{nameof(minesCount)}\" = {minesCount} can't be greater than "
                                            + $"the area of the field \"{nameof(fieldArea)}\" = {fieldArea}.", nameof(minesCount));
            }

            if (minesCount <= 0)
            {
                throw new ArgumentException($"The count of mines can't be less or equal to 0. Now \"{nameof(minesCount)}\" = {minesCount}",
                    nameof(minesCount));
            }

            CellsCheckedCount = 0;
            MinesCount = minesCount;
            _field = new Cell[height, width];

            WorkWithTwoDimensionalArray((x, y) => _field[x, y] = new Cell(x, y));
        }

        private static void CheckFieldSize(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException($"The argument \"{nameof(length)}\" must be greater than or equal to one.", nameof(length));
            }
        }

        public void Mine(int x, int y)
        {
            CheckCoordinate(x, Height);
            CheckCoordinate(y, Width);

            var cells = new List<Cell>(_field.Length);

            foreach (var cell in _field)
            {
                if (cell.X == x && cell.Y == y)
                {
                    continue;
                }

                cells.Add(cell);
            }

            var random = new Random();

            for (var i = 0; i < MinesCount; i++)
            {
                var randomIndex = random.Next(cells.Count);

                _field[cells[randomIndex].X, cells[randomIndex].Y].Info = Information.Mine;

                TraverseNearbyCells(cells[randomIndex], cell =>
                {
                    if (cell.Info != Information.Mine)
                    {
                        cell.Info += 1;
                    }
                });

                cells.RemoveAt(randomIndex);
            }
        }

        private void ChangeNearbyCellsStatus(int x, int y)
        {
            var emptyCells = new Stack<Cell>();

            emptyCells.Push(_field[x, y]);

            while (emptyCells.Count > 0)
            {
                var cell = emptyCells.Pop();

                TraverseNearbyCells(cell, cell =>
                {
                    if (cell.Status == Status.Checked)
                    {
                        return;
                    }

                    if (cell.Note == Note.Flag)
                    {
                        return;
                    }

                    if (cell.Info == Information.Zero)
                    {
                        emptyCells.Push(cell);
                    }

                    cell.Status = Status.Checked;
                    CellsCheckedCount++;

                    if (cell.Info == Information.Mine)
                    {
                        MineDetonated = true;
                    }
                });
            }
        }

        public void CheckCell(int x, int y)
        {
            CheckCoordinate(x, Height);
            CheckCoordinate(y, Width);

            if (_field[x, y].Status == Status.Checked || _field[x, y].Note == Note.Flag)
            {
                return;
            }

            _field[x, y].Status = Status.Checked;
            CellsCheckedCount++;

            if (_field[x, y].Info == Information.Mine)
            {
                MineDetonated = true;
            }

            if (_field[x, y].Info == Information.Zero)
            {
                ChangeNearbyCellsStatus(x, y);
            }
        }

        public void CheckNearbyCells(int x, int y)
        {
            CheckCoordinate(x, Height);
            CheckCoordinate(y, Width);

            if (_field[x, y].Status == Status.Unchecked)
            {
                return;
            }

            var flagsCount = 0;

            TraverseNearbyCells(_field[x, y], cell =>
            {
                if (cell.Note == Note.Flag)
                {
                    flagsCount++;
                }
            });

            if (flagsCount != (int)_field[x, y].Info)
            {
                return;
            }

            ChangeNearbyCellsStatus(x, y);
        }

        private void TraverseNearbyCells(Cell cell, Action<Cell> task)
        {
            CheckForNull(cell);
            CheckForNull(task);

            var startCoordinateX = cell.X - 1 < 0 ? cell.X : cell.X - 1;
            var startCoordinateY = cell.Y - 1 < 0 ? cell.Y : cell.Y - 1;
            var finishCoordinateX = cell.X + 1 >= Height ? cell.X : cell.X + 1;
            var finishCoordinateY = cell.Y + 1 >= Width ? cell.Y : cell.Y + 1;

            for (var i = startCoordinateX; i <= finishCoordinateX; i++)
            {
                for (var j = startCoordinateY; j <= finishCoordinateY; j++)
                {
                    task(_field[i, j]);
                }
            }
        }

        public void LeaveNote(int x, int y)
        {
            CheckCoordinate(x, Height);
            CheckCoordinate(y, Width);

            if (_field[x, y].Status != Status.Unchecked)
            {
                return;
            }

            _field[x, y].GetNextNote();

            if (_field[x, y].Note == Note.Flag)
            {
                MinesFoundCount++;
            }
            else if (_field[x, y].Note == Note.QuestionMark)
            {
                MinesFoundCount--;
            }
        }

        public void CheckAllCells()
        {
            WorkWithTwoDimensionalArray((x, y) =>
            {
                if (_field[x, y].Note == Note.Flag && _field[x, y].Info != Information.Mine)
                {
                    return;
                }

                if (_field[x, y].Note != Note.Flag && _field[x, y].Info == Information.Mine && _field[x, y].Status == Status.Checked)
                {
                    _field[x, y].Info = Information.Error;
                }

                _field[x, y].Status = Status.Checked;
            });
        }

        public void Clear()
        {
            WorkWithTwoDimensionalArray((x, y) => _field[x, y].Clear());

            CellsCheckedCount = 0;
            MinesFoundCount = 0;
            MineDetonated = false;
        }

        private static void CheckCoordinate(int coordinate, int limit)
        {
            if (coordinate < 0)
            {
                throw new ArgumentException("The coordinate must be greater than or equal 0. "
                    + $"Now \"{nameof(coordinate)}\" = {coordinate}.", nameof(coordinate));
            }

            if (coordinate >= limit)
            {
                throw new ArgumentException($"The coordinate must be less than {limit}. "
                    + $"Now \"{nameof(coordinate)} = {coordinate}.", nameof(coordinate));
            }
        }

        private static void CheckForNull(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentException($"The argument {nameof(obj)} is null.", nameof(obj));
            }
        }

        private void WorkWithTwoDimensionalArray(Action<int, int> task)
        {
            CheckForNull(task);

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    task(i, j);
                }
            }
        }
    }
}
