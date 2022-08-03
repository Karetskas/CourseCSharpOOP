using System;
using System.Collections.Generic;
using Academits.Karetskas.ShapesTask.Shapes;

namespace Academits.Karetskas.ShapesTask.Comparers
{
    public sealed class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null)
            {
                throw new ArgumentNullException(nameof(shape1), $"Argument \"{nameof(shape1)}\" is null.");
            }

            if (shape2 is null)
            {
                throw new ArgumentNullException(nameof(shape2), $"Argument \"{nameof(shape2)}\" is null.");
            }

            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}
