using System;
using Academits.Karetskas.TemperatureTask.Model;

namespace Academits.Karetskas.TemperatureTask.Controller
{
    internal sealed class TemperatureController : IController
    {
        private readonly IModel _model;

        public TemperatureController(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model), $@"Argument ""{nameof(model)}"" is null.");
        }

        public IScale[] GetScales()
        {
            return _model.Scales;
        }

        public double ConvertTemperature(IScale convertFromScale, IScale convertToScale, double temperature)
        {
            return _model.Convert(convertFromScale, convertToScale, temperature);
        }
    }
}
