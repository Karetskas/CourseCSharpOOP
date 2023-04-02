using System;
using Academits.Karetskas.TemperatureTask.Model;
using Academits.Karetskas.TemperatureTask.View;

namespace Academits.Karetskas.TemperatureTask.Controller
{
    internal sealed class CommandsForView
    {
        private readonly TemperatureConverter _model;

        public CommandsForView(TemperatureConverter model)
        {
            _model = model is null
                ? throw new ArgumentNullException($"{nameof(model)}",
                    $@"Argument ""{nameof(model)}"" is null.")
                : model;
        }

        public string[] RequestScalesList()
        {
            return _model.ScalesList;
        }

        public string RequestConversion(string? convertFromScale, string? convertToScale, string temperature)
        {
            string conversionResult = "NaN";

            try
            {
                conversionResult = _model.ConvertBetweenScales(convertFromScale, convertToScale, temperature);
            }
            catch (FormatException)
            {
                ConverterTemperatureForm.ShowMessage("You entered a non-real number!");
            }

            return conversionResult;
        }
    }
}
