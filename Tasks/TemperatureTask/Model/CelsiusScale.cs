namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class CelsiusScale : IScale
    {
        public double ConvertFromCelsius(double temperature)
        {
            return temperature;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature;
        }

        public override string ToString()
        {
            return "Celsius";
        }
    }
}
