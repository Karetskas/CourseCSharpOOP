using System;

namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class TemperatureConverter : ITemperatureConverter
    {
        public IScale[] Scales { get; }

        public TemperatureConverter(IScale[] scales)
        {
            if (scales is null)
            {
                throw new ArgumentNullException(nameof(scales), $@"Argument ""{nameof(scales)}"" is null.");
            }

            if (scales.Length == 0)
            {
                throw new ArgumentException($@"Argument ""{nameof(scales)}"" is not be equal 0 items.", nameof(scales));
            }

            Scales = scales;
        }

        public double Convert(IScale convertFromScale, IScale convertToScale, double temperature)
        {
            return convertToScale.ConvertFromCelsius(convertFromScale.ConvertToCelsius(temperature));
        }
    }
}
