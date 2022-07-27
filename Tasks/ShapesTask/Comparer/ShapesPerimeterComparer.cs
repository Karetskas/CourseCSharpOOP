using System;
using System.Collections.Generic;

namespace Academits.Karetskas.ShapesTask
{
    public sealed class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentException("Argument is null.");
            }

            double shape1Perimeter = shape1.GetPerimeter();
            double shape2Perimeter = shape2.GetPerimeter();

            if (shape1Perimeter > shape2Perimeter)
            {
                return 1;
            }

            if (shape1Perimeter < shape2Perimeter)
            {
                return -1;
            }

            return 0;
        }
    }
}
