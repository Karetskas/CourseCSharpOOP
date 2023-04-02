using System;
using System.Windows.Forms;
using Academits.Karetskas.TemperatureTask.Controller;

namespace Academits.Karetskas.TemperatureTask.View
{
    internal partial class ConverterTemperatureForm : Form
    {
        private readonly CommandsForView _controller;

        public ConverterTemperatureForm(CommandsForView controller)
        {
            _controller = controller is null
                ? throw new ArgumentNullException($"{nameof(controller)}",
                    $@"Argument ""{nameof(controller)}"" is null.")
                : controller;

            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            TemperatureAfterConversionTextBox.Text = _controller.RequestConversion(ConvertFromComboBox.SelectedItem.ToString(),
                ConvertToComboBox.SelectedItem.ToString(), TemperatureBeforeConversionTextBox.Text);
        }

        public void GetScalesList()
        {
            string[] scalesList = _controller.RequestScalesList();

            ConvertFromComboBox.Items.AddRange(scalesList);
            ConvertFromComboBox.SelectedItem = "Celsius";

            ConvertToComboBox.Items.AddRange(scalesList);
            ConvertToComboBox.SelectedItem = "Celsius";
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, @"Error message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}