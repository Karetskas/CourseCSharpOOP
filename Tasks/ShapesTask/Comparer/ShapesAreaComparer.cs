using System;
using System.Collections.Generic;

namespace Academits.Karetskas.ShapesTask
{
    public sealed class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape? shape1, IShape? shape2)
        {
            if (shape1 is null || shape2 is null)
            {
                throw new ArgumentException("Argument is null.");
            }

            double shape1Area = shape1.GetArea();
            double shape2Area = shape2.GetArea();

            if (shape1Area > shape2Area)
            {
                return 1;
            }

            if (shape1Area < shape2Area)
            {
                return -1;
            }

            return 0;
        }
    }
}
