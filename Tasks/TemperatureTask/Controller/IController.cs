using Academits.Karetskas.TemperatureTask.Model;

namespace Academits.Karetskas.TemperatureTask.Controller
{
    public interface IController
    {
        IScale[] GetScales();

        double ConvertTemperature(IScale convertFromScale, IScale convertToScale, double temperature);
    }
}
