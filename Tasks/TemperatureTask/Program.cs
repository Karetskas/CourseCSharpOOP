using System;
using System.Windows.Forms;
using Academits.Karetskas.TemperatureTask.Controller;
using Academits.Karetskas.TemperatureTask.Model;
using Academits.Karetskas.TemperatureTask.View;

namespace Academits.Karetskas.TemperatureTask
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IScale[] scales =
            {
                new CelsiusScale(),
                new KelvinScale(),
                new FahrenheitScale()
            };

            TemperatureConverter model = new TemperatureConverter(scales);

            CommandsForView controller = new CommandsForView(model);

            ConverterTemperatureForm view = new ConverterTemperatureForm(controller);
            view.GetScalesList();

            Application.Run(view);
        }
    }
}