namespace Academits.Karetskas.RangeTask
{
    public sealed class Range
    {
        private const double minNumber = 1.0e-10;
        private double from;
        private double to;

        public double From
        {
            get => from;
            set => from = value < minNumber ? 0 : value;
        }

        public double To
        {
            get => to;
            set => to = value < minNumber ? 0 : value;
        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            const double epsilon = 1.0e-10;

            return number - From >= -epsilon && number - To <= epsilon;
        }

        private double[] GetSortedElements(Range otherRange)
        {
            double[] numbersArray =
            {
                From,
                To,
                otherRange.From,
                otherRange.To
            };

            Array.Sort(numbersArray);

            return numbersArray;
        }

        public Range? GetRangesIntersection(Range otherRange)
        {
            if (To <= otherRange.From || otherRange.To <= From)
            {
                return null;
            }

            double[] numbersArray = GetSortedElements(otherRange);

            return new Range(numbersArray[1], numbersArray[^2]);
        }

        public Range[] GetRangesJoin(Range otherRange)
        {
            if (To < otherRange.From || otherRange.To < From)
            {
                return new Range[] { this, otherRange };
            }

            double[] numbersArray = GetSortedElements(otherRange);

            return new Range[] { new Range(numbersArray[0], numbersArray[^1]) };
        }

        // In this function: Range - otherRange.
        public Range[] GetRangesDifference(Range otherRange)
        {
            if (From >= otherRange.From && To <= otherRange.To)
            {
                return new Range[0];
            }

            if (To <= otherRange.From || From >= otherRange.To)
            {
                return new Range[] { this };
            }

            if (To > otherRange.From && To <= otherRange.To && otherRange.From > From)
            {
                return new Range[] { new Range(From, otherRange.From - minNumber) };
            }

            if (otherRange.To > From && otherRange.To < To && From >= otherRange.From)
            {
                return new Range[] { new Range(otherRange.To + minNumber, To) };
            }

            return new Range[] { new Range(From, otherRange.From - minNumber), new Range(otherRange.To + minNumber, To) };
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}