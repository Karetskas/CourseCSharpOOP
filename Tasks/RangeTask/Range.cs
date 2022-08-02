using System;

namespace Academits.Karetskas.RangeTask
{
    public sealed class Range
    {
        public double From { get; set; }

        public double To { get; set; }

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

        public Range? GetIntersection(Range range)
        {
            if (To <= range.From || range.To <= From)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From || range.To < From)
            {
                return new Range[]
                {
                    new Range(From, To),
                    new Range(range.From, range.To)
                };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        // In this function: this - range.
        public Range[] GetDifference(Range range)
        {
            if (From >= range.From && To <= range.To)
            {
                return new Range[0];
            }

            if (To <= range.From || From >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (To > range.From && To <= range.To && range.From > From)
            {
                return new Range[] { new Range(From, range.From) };
            }

            if (range.To > From && range.To < To && From >= range.From)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[]
            {
                new Range(From, range.From),
                new Range(range.To, To)
            };
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}