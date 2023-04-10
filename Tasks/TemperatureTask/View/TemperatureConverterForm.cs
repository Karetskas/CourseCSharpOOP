using System;
using System.Globalization;
using System.Windows.Forms;
using Academits.Karetskas.TemperatureTask.Controller;
using Academits.Karetskas.TemperatureTask.Model;

namespace Academits.Karetskas.TemperatureTask.View
{
    public partial class TemperatureConverterForm : Form
    {
        private readonly IController _controller;

        public TemperatureConverterForm(IController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller), $@"Argument ""{nameof(controller)}"" is null");

            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            CalculateTemperature();
        }

        public void CalculateTemperature()
        {
            var convertFromScale = ConvertFromComboBox.SelectedItem as IScale;
            CheckForNull(convertFromScale);

            var convertToScale = ConvertToComboBox.SelectedItem as IScale;
            CheckForNull(convertToScale);

            if (!double.TryParse(TemperatureBeforeConversionTextBox.Text, NumberStyles.Float, new CultureInfo("en-US"),
                    out var temperature))
            {
                ShowMessage("The argument is not of type \"double\"");
            }
            
            var conversionResult = _controller.ConvertTemperature(convertFromScale, convertToScale, temperature);
            conversionResult = Math.Round(conversionResult, 3, MidpointRounding.AwayFromZero);

            TemperatureAfterConversionTextBox.Text = conversionResult.ToString(new CultureInfo("en-US"));
        }

        private static void CheckForNull(IScale scale)
        {
            if (scale is null)
            {
                throw new ArgumentNullException(nameof(scale), $"Argument \"{nameof(scale)}\" is null.");
            }
        }

        public void LoadScales()
        {
            var scales = _controller.GetScales();

            ConvertFromComboBox.Items.AddRange(scales);
            ConvertFromComboBox.SelectedIndex = 0;

            ConvertToComboBox.Items.AddRange(scales);
            ConvertToComboBox.SelectedIndex = 0;
        }

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message, @"Error message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}