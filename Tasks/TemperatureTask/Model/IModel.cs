namespace Academits.Karetskas.TemperatureTask.Model
{
    public interface IModel
    {
        IScale[] Scales { get; }

        double Convert(IScale convertFromScale, IScale convertToScale, double temperature);
    }
}
