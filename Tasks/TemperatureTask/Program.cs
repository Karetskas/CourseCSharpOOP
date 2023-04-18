using System;
using System.Windows.Forms;
using Academits.Karetskas.TemperatureTask.View;
using Academits.Karetskas.TemperatureTask.Model;
using Academits.Karetskas.TemperatureTask.Controller;

namespace Academits.Karetskas.TemperatureTask
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var scales = new IScale[]
            {
                new CelsiusScale(),
                new KelvinScale(),
                new FahrenheitScale()
            };

            var model = new TemperatureConverter(scales);

            var controller = new TemperatureController(model);

            var view = new TemperatureConverterForm(controller);

            Application.Run(view);
        }
    }
}