using System;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using Academits.Karetskas.TemperatureTask.Model;
using Academits.Karetskas.TemperatureTask.Model.Kelvin;
using Academits.Karetskas.TemperatureTask.Model.Celsius;
using Academits.Karetskas.TemperatureTask.Model.Fahrenheit;

namespace Academits.Karetskas.TemperatureTask
{
    public partial class ConvertureTemperatureForm : Form
    {
        Dictionary<string, IConverter> conversionOptions = new Dictionary<string, IConverter>(6)
        {
            { "CelsiusFahrenheit", new CelsiusToFahrenheit() },
            { "CelsiusKelvin", new CelsiusToKelvin() },
            { "FahrenheitCelsius", new FahrenheitToCelsius() },
            { "FahrenheitKelvin", new FahrenheitToKelvin() },
            { "KelvinCelsius", new KelvinToCelsius() },
            { "KelvinFahrenheit", new KelvinToFahrenheit() }
        };

        public ConvertureTemperatureForm()
        {
            InitializeComponent();

            ConvertFromComboBox.SelectedItem = "Celsius";
            ConvertToComboBox.SelectedItem = "Fahrenheit";
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            if (!double.TryParse(TemperatureBeforeConversionTextBox.Text, NumberStyles.Float,
                formatter, out double temperature))
            {
                MessageBox.Show(this, "You have entered the temperature in the wrong format "
                    + $"\"{TemperatureBeforeConversionTextBox.Text}\" in the input field. "
                    + "Please enter the temperature in the input field, for example, \"17.5\".", "Input ERROR!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (ConvertFromComboBox.Text == ConvertToComboBox.Text)
            {
                TemperatureAfterConversionTextBox.Text = TemperatureBeforeConversionTextBox.Text;

                return;
            }

            TemperatureConverter temperatureConverter
                = new TemperatureConverter(conversionOptions[ConvertFromComboBox.Text + ConvertToComboBox.Text]);

            TemperatureAfterConversionTextBox.Text = Convert.ToString(temperatureConverter.ConvertTo(temperature));
        }
    }
}