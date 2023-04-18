using Academits.Karetskas.TemperatureTask.Model;

namespace Academits.Karetskas.TemperatureTask.Controller
{
    public interface IController
    {
        IScale[] Scales { get; }

        double Convert(IScale convertFromScale, IScale convertToScale, double temperature);
    }
}
