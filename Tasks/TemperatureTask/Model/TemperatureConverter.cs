namespace Academits.Karetskas.TemperatureTask.Model
{
    internal sealed class TemperatureConverter
    {
        private IConverter _temperatureConvertion;

        public TemperatureConverter(IConverter temperatureConvertion)
        {
            _temperatureConvertion = temperatureConvertion;
        }

        public double ConvertTo(double temperature)
        {
            return _temperatureConvertion.ConvertTo(temperature);
        }
    }
}
