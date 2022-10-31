namespace Academits.Karetskas.TemperatureTask.Model.Celsius
{
    internal sealed class CelsiusToFahrenheit : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return temperature * 1.8 + 32;
        }
    }
}
