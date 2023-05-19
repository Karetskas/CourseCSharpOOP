using System;
using Academits.Karetskas.TemperatureTask.Model;

namespace Academits.Karetskas.TemperatureTask.Controller
{
    internal sealed class TemperatureController : IController
    {
        private readonly ITemperatureConverter _model;

        public TemperatureController(ITemperatureConverter model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model), $@"Argument ""{nameof(model)}"" is null.");
        }

        public IScale[] Scales => _model.Scales;

        public double Convert(IScale convertFromScale, IScale convertToScale, double temperature)
        {
            return _model.Convert(convertFromScale, convertToScale, temperature);
        }
    }
}
