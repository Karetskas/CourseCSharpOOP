namespace Academits.Karetskas.TemperatureTask.Model.Fahrenheit
{
    internal sealed class FahrenheitToCelsius : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return (temperature - 32) / 1.8;
        }
    }
}
