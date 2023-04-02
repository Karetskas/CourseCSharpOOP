using System;
using System.Globalization;
using System.Linq;

namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class TemperatureConverter
    {
        private readonly IScale[] _scales;

        public string[] ScalesList
        {
            get
            {
                return _scales.Select(s => s.ToString()).ToArray();
            }
        }

        public TemperatureConverter(IScale[] scales)
        {
            if (scales is null)
            {
                throw new ArgumentNullException($"{nameof(scales)}",
                    $@"Argument ""{nameof(scales)}"" is null.");
            }

            if (scales.Length == 0)
            {
                throw new ArgumentException($@"Argument ""{nameof(scales)}"" is not be equal 0 items.",
                    $"{nameof(scales)}");
            }

            _scales = scales;
        }

        private IScale GetScaleType(string? scale)
        {
            if (scale is null)
            {
                throw new ArgumentNullException($"{nameof(scale)}",
                    $@"Argument ""{nameof(scale)}"" is null.");
            }

            IScale? scaleType = Array.Find(_scales, s => s.ToString() == scale);

            return scaleType ?? throw new ArgumentException($@"Argument ""{nameof(scale)}"" is passed to a method is invalid.",
                $"{nameof(scale)}");
        }

        public string ConvertBetweenScales(string? convertFromScale, string? convertToScale, string temperature)
        {
            IScale fromScale = GetScaleType(convertFromScale);
            IScale toScale = GetScaleType(convertToScale);

            if (!double.TryParse(temperature, NumberStyles.Float, new CultureInfo("en-US"),
                    out double temperatureValue))
            {
                throw new FormatException("The argument is not of type \"double\"");
            }

            double conversionResult = toScale.ConvertFromCelsius(fromScale.ConvertToCelsius(temperatureValue));

            return Math.Round(conversionResult, 3, MidpointRounding.AwayFromZero)
                .ToString(new CultureInfo("en-US"));
        }
    }
}
