namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class KelvinScale : IScale
    {
        public double ConvertToCelsius(double temperature)
        {
            return temperature - 273.15;
        }

        public double ConvertFromCelsius(double temperature)
        {
            return temperature + 273.15;
        }

        public override string ToString()
        {
            return "Kelvin";
        }
    }
}
