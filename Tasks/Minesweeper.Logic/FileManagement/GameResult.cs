using System;

namespace Academits.Karetskas.Minesweeper.Logic.FileManagement
{
    public readonly record struct GameResult((int width, int height) Field, int MinesCount, TimeSpan GameTime);
}
