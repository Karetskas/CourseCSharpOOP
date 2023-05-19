namespace Academits.Karetskas.TemperatureTask.Model
{
    public interface ITemperatureConverter
    {
        IScale[] Scales { get; }

        double Convert(IScale convertFromScale, IScale convertToScale, double temperature);
    }
}
