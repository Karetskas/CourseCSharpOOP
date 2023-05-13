namespace Minesweeper.Gui
{
    partial class HighScoresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScoresForm));
            titleLabel = new System.Windows.Forms.Label();
            buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            buttonOkPictureBox = new System.Windows.Forms.PictureBox();
            highScoresLabel = new System.Windows.Forms.Label();
            buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonOkPictureBox).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.BackColor = System.Drawing.Color.Transparent;
            titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            titleLabel.Font = new System.Drawing.Font("Ink Free", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(252, 137, 28);
            titleLabel.Location = new System.Drawing.Point(0, 0);
            titleLabel.Margin = new System.Windows.Forms.Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(384, 59);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "High scores";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = System.Drawing.Color.Transparent;
            buttonsPanel.ColumnCount = 3;
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            buttonsPanel.Controls.Add(buttonOkPictureBox, 1, 0);
            buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonsPanel.Location = new System.Drawing.Point(0, 296);
            buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 2;
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            buttonsPanel.Size = new System.Drawing.Size(384, 65);
            buttonsPanel.TabIndex = 9;
            // 
            // buttonOkPictureBox
            // 
            buttonOkPictureBox.BackColor = System.Drawing.Color.Transparent;
            buttonOkPictureBox.Image = (System.Drawing.Image)resources.GetObject("buttonOkPictureBox.Image");
            buttonOkPictureBox.Location = new System.Drawing.Point(132, 0);
            buttonOkPictureBox.Margin = new System.Windows.Forms.Padding(0);
            buttonOkPictureBox.Name = "buttonOkPictureBox";
            buttonOkPictureBox.Size = new System.Drawing.Size(120, 50);
            buttonOkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            buttonOkPictureBox.TabIndex = 6;
            buttonOkPictureBox.TabStop = false;
            buttonOkPictureBox.MouseDown += ButtonOkPictureBox_MouseDown;
            buttonOkPictureBox.MouseEnter += ButtonOkPictureBox_MouseEnter;
            buttonOkPictureBox.MouseLeave += ButtonOkPictureBox_MouseLeave;
            buttonOkPictureBox.MouseUp += ButtonOkPictureBox_MouseUp;
            // 
            // highScoresLabel
            // 
            highScoresLabel.BackColor = System.Drawing.Color.Transparent;
            highScoresLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            highScoresLabel.Font = new System.Drawing.Font("Ink Free", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            highScoresLabel.ForeColor = System.Drawing.Color.White;
            highScoresLabel.Location = new System.Drawing.Point(0, 59);
            highScoresLabel.Margin = new System.Windows.Forms.Padding(0);
            highScoresLabel.Name = "highScoresLabel";
            highScoresLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            highScoresLabel.Size = new System.Drawing.Size(384, 237);
            highScoresLabel.TabIndex = 10;
            highScoresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HighScoresForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(148, 193, 30);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(384, 361);
            Controls.Add(highScoresLabel);
            Controls.Add(buttonsPanel);
            Controls.Add(titleLabel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Ink Free", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HighScoresForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "HighScores";
            buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonOkPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.PictureBox buttonOkPictureBox;
        private System.Windows.Forms.Label highScoresLabel;
    }
}