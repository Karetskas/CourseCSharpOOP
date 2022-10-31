namespace Academits.Karetskas.TemperatureTask.Model.Fahrenheit
{
    internal sealed class FahrenheitToKelvin : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return (temperature - 32) / 1.8 + 273.15;
        }
    }
}
