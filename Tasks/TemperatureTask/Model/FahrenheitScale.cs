namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class FahrenheitScale : IScale
    {
        public double ConvertToCelsius(double temperature)
        {
            return (temperature - 32) / 1.8;
        }

        public double ConvertFromCelsius(double temperature)
        {
            return temperature * 1.8 + 32;
        }

        public override string ToString()
        {
            return "Fahrenheit";
        }
    }
}
