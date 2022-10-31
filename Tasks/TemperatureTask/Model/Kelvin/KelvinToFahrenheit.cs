namespace Academits.Karetskas.TemperatureTask.Model.Kelvin
{
    internal sealed class KelvinToFahrenheit : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return (temperature - 273.15) * 1.8 + 32;
        }
    }
}
