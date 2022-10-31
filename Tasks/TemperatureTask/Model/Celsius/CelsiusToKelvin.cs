namespace Academits.Karetskas.TemperatureTask.Model.Celsius
{
    internal sealed class CelsiusToKelvin : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return temperature + 273.15;
        }
    }
}
