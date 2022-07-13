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
    }
}
