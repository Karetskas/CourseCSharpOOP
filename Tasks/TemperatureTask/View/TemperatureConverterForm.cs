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
            InitializeComponent();

            _controller = controller ?? throw new ArgumentNullException(nameof(controller), $@"Argument ""{nameof(controller)}"" is null");

            var scales = _controller.Scales;

            ConvertFromComboBox.Items.AddRange(scales);
            ConvertFromComboBox.SelectedIndex = 0;

            ConvertToComboBox.Items.AddRange(scales);
            ConvertToComboBox.SelectedIndex = 0;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            CalculateTemperature();
        }

        public void CalculateTemperature()
        {
            var convertFromScale = (IScale)ConvertFromComboBox.SelectedItem;
            var convertToScale = (IScale)ConvertToComboBox.SelectedItem;

            if (!double.TryParse(TemperatureBeforeConversionTextBox.Text, NumberStyles.Float, new CultureInfo("en-US"),
                    out var temperature))
            {
                ShowMessage("Please enter a valid real number.");
            }

            var conversionResult = _controller.Convert(convertFromScale, convertToScale, temperature);
            conversionResult = Math.Round(conversionResult, 3, MidpointRounding.AwayFromZero);

            TemperatureAfterConversionTextBox.Text = conversionResult.ToString(new CultureInfo("en-US"));
        }

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message, "Error message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}