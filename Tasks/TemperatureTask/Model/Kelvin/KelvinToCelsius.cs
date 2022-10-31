namespace Academits.Karetskas.TemperatureTask.Model.Kelvin
{
    internal sealed class KelvinToCelsius : IConverter
    {
        public double ConvertTo(double temperature)
        {
            return temperature - 273.15;
        }
    }
}
