namespace Academits.Karetskas.Minesweeper.Gui.Forms
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
            tableResultsPanel = new System.Windows.Forms.TableLayoutPanel();
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
            titleLabel.Location = new System.Drawing.Point(10, 10);
            titleLabel.Margin = new System.Windows.Forms.Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(364, 61);
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
            buttonsPanel.Controls.Add(buttonOkPictureBox, 1, 0);
            buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonsPanel.Location = new System.Drawing.Point(10, 299);
            buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 1;
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            buttonsPanel.Size = new System.Drawing.Size(364, 54);
            buttonsPanel.TabIndex = 9;
            // 
            // buttonOkPictureBox
            // 
            buttonOkPictureBox.BackColor = System.Drawing.Color.Transparent;
            buttonOkPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonOkPictureBox.Image = (System.Drawing.Image)resources.GetObject("buttonOkPictureBox.Image");
            buttonOkPictureBox.Location = new System.Drawing.Point(122, 4);
            buttonOkPictureBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
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
            // tableResultsPanel
            // 
            tableResultsPanel.AutoSize = true;
            tableResultsPanel.BackColor = System.Drawing.Color.Transparent;
            tableResultsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableResultsPanel.ColumnCount = 1;
            tableResultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableResultsPanel.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tableResultsPanel.ForeColor = System.Drawing.Color.Lime;
            tableResultsPanel.Location = new System.Drawing.Point(10, 71);
            tableResultsPanel.Name = "tableResultsPanel";
            tableResultsPanel.RowCount = 1;
            tableResultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableResultsPanel.Size = new System.Drawing.Size(364, 228);
            tableResultsPanel.TabIndex = 11;
            // 
            // HighScoresForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(148, 193, 30);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(384, 361);
            Controls.Add(tableResultsPanel);
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
            Padding = new System.Windows.Forms.Padding(10, 10, 10, 8);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "HighScores";
            buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonOkPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.PictureBox buttonOkPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableResultsPanel;
    }
}