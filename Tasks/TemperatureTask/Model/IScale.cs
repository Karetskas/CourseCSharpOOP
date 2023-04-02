namespace Academits.Karetskas.TemperatureTask.Model
{
    public interface IScale
    {
        double ConvertToCelsius(double temperature);

        double ConvertFromCelsius(double temperature);

        string ToString();
    }
}
