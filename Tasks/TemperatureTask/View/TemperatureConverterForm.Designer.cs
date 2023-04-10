namespace Academits.Karetskas.TemperatureTask.View
{
    partial class TemperatureConverterForm
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
            TemperatureBeforeConversionTextBox = new System.Windows.Forms.TextBox();
            EnterTemperatureLabel = new System.Windows.Forms.Label();
            ConvertButton = new System.Windows.Forms.Button();
            ConvertFromComboBox = new System.Windows.Forms.ComboBox();
            ConversionResultLabel = new System.Windows.Forms.Label();
            ConvertToComboBox = new System.Windows.Forms.ComboBox();
            TemperatureAfterConversionTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // TemperatureBeforeConversionTextBox
            // 
            TemperatureBeforeConversionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TemperatureBeforeConversionTextBox.Location = new System.Drawing.Point(142, 12);
            TemperatureBeforeConversionTextBox.Name = "TemperatureBeforeConversionTextBox";
            TemperatureBeforeConversionTextBox.Size = new System.Drawing.Size(121, 23);
            TemperatureBeforeConversionTextBox.TabIndex = 0;
            TemperatureBeforeConversionTextBox.Text = "0";
            TemperatureBeforeConversionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnterTemperatureLabel
            // 
            EnterTemperatureLabel.AutoSize = true;
            EnterTemperatureLabel.Location = new System.Drawing.Point(12, 15);
            EnterTemperatureLabel.Name = "EnterTemperatureLabel";
            EnterTemperatureLabel.Size = new System.Drawing.Size(125, 15);
            EnterTemperatureLabel.TabIndex = 1;
            EnterTemperatureLabel.Text = "Enter the temperature:";
            // 
            // ConvertButton
            // 
            ConvertButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ConvertButton.Location = new System.Drawing.Point(12, 41);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new System.Drawing.Size(430, 34);
            ConvertButton.TabIndex = 3;
            ConvertButton.Text = "Convert";
            ConvertButton.UseVisualStyleBackColor = true;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // ConvertFromComboBox
            // 
            ConvertFromComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ConvertFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ConvertFromComboBox.Location = new System.Drawing.Point(269, 12);
            ConvertFromComboBox.Name = "ConvertFromComboBox";
            ConvertFromComboBox.Size = new System.Drawing.Size(173, 23);
            ConvertFromComboBox.TabIndex = 1;
            // 
            // ConversionResultLabel
            // 
            ConversionResultLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ConversionResultLabel.AutoSize = true;
            ConversionResultLabel.Location = new System.Drawing.Point(12, 84);
            ConversionResultLabel.Name = "ConversionResultLabel";
            ConversionResultLabel.Size = new System.Drawing.Size(102, 15);
            ConversionResultLabel.TabIndex = 4;
            ConversionResultLabel.Text = "Conversion result:";
            // 
            // ConvertToComboBox
            // 
            ConvertToComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ConvertToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ConvertToComboBox.FormattingEnabled = true;
            ConvertToComboBox.Location = new System.Drawing.Point(269, 81);
            ConvertToComboBox.Name = "ConvertToComboBox";
            ConvertToComboBox.Size = new System.Drawing.Size(173, 23);
            ConvertToComboBox.TabIndex = 2;
            // 
            // TemperatureAfterConversionTextBox
            // 
            TemperatureAfterConversionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TemperatureAfterConversionTextBox.Location = new System.Drawing.Point(142, 81);
            TemperatureAfterConversionTextBox.Name = "TemperatureAfterConversionTextBox";
            TemperatureAfterConversionTextBox.ReadOnly = true;
            TemperatureAfterConversionTextBox.Size = new System.Drawing.Size(121, 23);
            TemperatureAfterConversionTextBox.TabIndex = 4;
            TemperatureAfterConversionTextBox.Text = "0";
            TemperatureAfterConversionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConvertureTemperatureForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(454, 116);
            Controls.Add(TemperatureAfterConversionTextBox);
            Controls.Add(ConvertToComboBox);
            Controls.Add(ConversionResultLabel);
            Controls.Add(ConvertFromComboBox);
            Controls.Add(ConvertButton);
            Controls.Add(TemperatureBeforeConversionTextBox);
            Controls.Add(EnterTemperatureLabel);
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(470, 155);
            Name = "ConverterTemperatureForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Temperature converter";
            ResumeLayout(false);
            PerformLayout();
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