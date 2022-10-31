namespace Academits.Karetskas.TemperatureTask
{
    partial class ConvertureTemperatureForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TemperatureBeforeConversionTextBox = new System.Windows.Forms.TextBox();
            this.EnterTemperatureLabel = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ConvertFromComboBox = new System.Windows.Forms.ComboBox();
            this.ConversionResultLabel = new System.Windows.Forms.Label();
            this.ConvertToComboBox = new System.Windows.Forms.ComboBox();
            this.TemperatureAfterConversionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TemperatureBeforeConversionTextBox
            // 
            this.TemperatureBeforeConversionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemperatureBeforeConversionTextBox.Location = new System.Drawing.Point(142, 12);
            this.TemperatureBeforeConversionTextBox.Name = "TemperatureBeforeConversionTextBox";
            this.TemperatureBeforeConversionTextBox.Size = new System.Drawing.Size(121, 23);
            this.TemperatureBeforeConversionTextBox.TabIndex = 0;
            this.TemperatureBeforeConversionTextBox.Text = "0";
            this.TemperatureBeforeConversionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnterTemperatureLabel
            // 
            this.EnterTemperatureLabel.AutoSize = true;
            this.EnterTemperatureLabel.Location = new System.Drawing.Point(12, 15);
            this.EnterTemperatureLabel.Name = "EnterTemperatureLabel";
            this.EnterTemperatureLabel.Size = new System.Drawing.Size(125, 15);
            this.EnterTemperatureLabel.TabIndex = 1;
            this.EnterTemperatureLabel.Text = "Enter the temperature:";
            // 
            // ConvertButton
            // 
            this.ConvertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertButton.Location = new System.Drawing.Point(12, 41);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(430, 34);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ConvertFromComboBox
            // 
            this.ConvertFromComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertFromComboBox.Items.AddRange(new object[] {
            "Celsius",
            "Fahrenheit",
            "Kelvin"});
            this.ConvertFromComboBox.Location = new System.Drawing.Point(269, 12);
            this.ConvertFromComboBox.Name = "ConvertFromComboBox";
            this.ConvertFromComboBox.Size = new System.Drawing.Size(173, 23);
            this.ConvertFromComboBox.TabIndex = 1;
            // 
            // ConversionResultLabel
            // 
            this.ConversionResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConversionResultLabel.AutoSize = true;
            this.ConversionResultLabel.Location = new System.Drawing.Point(12, 84);
            this.ConversionResultLabel.Name = "ConversionResultLabel";
            this.ConversionResultLabel.Size = new System.Drawing.Size(102, 15);
            this.ConversionResultLabel.TabIndex = 4;
            this.ConversionResultLabel.Text = "Conversion result:";
            // 
            // ConvertToComboBox
            // 
            this.ConvertToComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertToComboBox.FormattingEnabled = true;
            this.ConvertToComboBox.Items.AddRange(new object[] {
            "Celsius",
            "Fahrenheit",
            "Kelvin"});
            this.ConvertToComboBox.Location = new System.Drawing.Point(269, 81);
            this.ConvertToComboBox.Name = "ConvertToComboBox";
            this.ConvertToComboBox.Size = new System.Drawing.Size(173, 23);
            this.ConvertToComboBox.TabIndex = 2;
            // 
            // TemperatureAfterConversionTextBox
            // 
            this.TemperatureAfterConversionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemperatureAfterConversionTextBox.Location = new System.Drawing.Point(142, 81);
            this.TemperatureAfterConversionTextBox.Name = "TemperatureAfterConversionTextBox";
            this.TemperatureAfterConversionTextBox.ReadOnly = true;
            this.TemperatureAfterConversionTextBox.Size = new System.Drawing.Size(121, 23);
            this.TemperatureAfterConversionTextBox.TabIndex = 4;
            this.TemperatureAfterConversionTextBox.Text = "32";
            this.TemperatureAfterConversionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConvertureTemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 116);
            this.Controls.Add(this.TemperatureAfterConversionTextBox);
            this.Controls.Add(this.ConvertToComboBox);
            this.Controls.Add(this.ConversionResultLabel);
            this.Controls.Add(this.ConvertFromComboBox);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.TemperatureBeforeConversionTextBox);
            this.Controls.Add(this.EnterTemperatureLabel);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 155);
            this.Name = "ConvertureTemperatureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TemperatureBeforeConversionTextBox;
        private System.Windows.Forms.Label EnterTemperatureLabel;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ComboBox ConvertFromComboBox;
        private System.Windows.Forms.Label ConversionResultLabel;
        private System.Windows.Forms.ComboBox ConvertToComboBox;
        private System.Windows.Forms.TextBox TemperatureAfterConversionTextBox;
    }
}