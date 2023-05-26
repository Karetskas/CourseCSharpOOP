namespace Academits.Karetskas.Minesweeper.Gui.Forms
{
    partial class OptionsForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            leftButtonWidthPictureBox = new System.Windows.Forms.PictureBox();
            rightButtonWidthPictureBox = new System.Windows.Forms.PictureBox();
            widthFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            widthLabel = new System.Windows.Forms.Label();
            widthValueLabel = new System.Windows.Forms.Label();
            heightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            heightLabel = new System.Windows.Forms.Label();
            leftButtonHeightPictureBox = new System.Windows.Forms.PictureBox();
            heightValueLabel = new System.Windows.Forms.Label();
            rightButtonHeightPictureBox = new System.Windows.Forms.PictureBox();
            minesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            minesLabel = new System.Windows.Forms.Label();
            leftButtonMinesPictureBox = new System.Windows.Forms.PictureBox();
            minesValueLabel = new System.Windows.Forms.Label();
            rightButtonMinesPictureBox = new System.Windows.Forms.PictureBox();
            titleLabel = new System.Windows.Forms.Label();
            buttonOkPictureBox = new System.Windows.Forms.PictureBox();
            buttonCancelPictureBox = new System.Windows.Forms.PictureBox();
            buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            automaticValueChangeTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)leftButtonWidthPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonWidthPictureBox).BeginInit();
            widthFlowLayoutPanel.SuspendLayout();
            heightFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leftButtonHeightPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonHeightPictureBox).BeginInit();
            minesFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leftButtonMinesPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonMinesPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonOkPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonCancelPictureBox).BeginInit();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftButtonWidthPictureBox
            // 
            leftButtonWidthPictureBox.BackColor = System.Drawing.Color.Transparent;
            leftButtonWidthPictureBox.Image = (System.Drawing.Image)resources.GetObject("leftButtonWidthPictureBox.Image");
            leftButtonWidthPictureBox.Location = new System.Drawing.Point(160, 0);
            leftButtonWidthPictureBox.Margin = new System.Windows.Forms.Padding(0);
            leftButtonWidthPictureBox.Name = "leftButtonWidthPictureBox";
            leftButtonWidthPictureBox.Size = new System.Drawing.Size(42, 50);
            leftButtonWidthPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            leftButtonWidthPictureBox.TabIndex = 0;
            leftButtonWidthPictureBox.TabStop = false;
            leftButtonWidthPictureBox.MouseDown += LeftButtonWidthPictureBox_MouseDown;
            leftButtonWidthPictureBox.MouseEnter += LeftButtonWidthPictureBox_MouseEnter;
            leftButtonWidthPictureBox.MouseLeave += LeftButtonWidthPictureBox_MouseLeave;
            leftButtonWidthPictureBox.MouseUp += LeftButtonWidthPictureBox_MouseUp;
            // 
            // rightButtonWidthPictureBox
            // 
            rightButtonWidthPictureBox.BackColor = System.Drawing.Color.Transparent;
            rightButtonWidthPictureBox.Image = (System.Drawing.Image)resources.GetObject("rightButtonWidthPictureBox.Image");
            rightButtonWidthPictureBox.Location = new System.Drawing.Point(302, 0);
            rightButtonWidthPictureBox.Margin = new System.Windows.Forms.Padding(0);
            rightButtonWidthPictureBox.Name = "rightButtonWidthPictureBox";
            rightButtonWidthPictureBox.Size = new System.Drawing.Size(42, 50);
            rightButtonWidthPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            rightButtonWidthPictureBox.TabIndex = 1;
            rightButtonWidthPictureBox.TabStop = false;
            rightButtonWidthPictureBox.MouseDown += RightButtonWidthPictureBox_MouseDown;
            rightButtonWidthPictureBox.MouseEnter += RightButtonWidthPictureBox_MouseEnter;
            rightButtonWidthPictureBox.MouseLeave += RightButtonWidthPictureBox_MouseLeave;
            rightButtonWidthPictureBox.MouseUp += RightButtonWidthPictureBox_MouseUp;
            // 
            // widthFlowLayoutPanel
            // 
            widthFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            widthFlowLayoutPanel.Controls.Add(widthLabel);
            widthFlowLayoutPanel.Controls.Add(leftButtonWidthPictureBox);
            widthFlowLayoutPanel.Controls.Add(widthValueLabel);
            widthFlowLayoutPanel.Controls.Add(rightButtonWidthPictureBox);
            widthFlowLayoutPanel.Location = new System.Drawing.Point(12, 79);
            widthFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            widthFlowLayoutPanel.Name = "widthFlowLayoutPanel";
            widthFlowLayoutPanel.Size = new System.Drawing.Size(363, 50);
            widthFlowLayoutPanel.TabIndex = 2;
            // 
            // widthLabel
            // 
            widthLabel.BackColor = System.Drawing.Color.Transparent;
            widthLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            widthLabel.ForeColor = System.Drawing.Color.White;
            widthLabel.Location = new System.Drawing.Point(0, 0);
            widthLabel.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new System.Drawing.Size(140, 50);
            widthLabel.TabIndex = 6;
            widthLabel.Text = "Width:";
            widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // widthValueLabel
            // 
            widthValueLabel.BackColor = System.Drawing.Color.Transparent;
            widthValueLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            widthValueLabel.ForeColor = System.Drawing.Color.White;
            widthValueLabel.Location = new System.Drawing.Point(202, 0);
            widthValueLabel.Margin = new System.Windows.Forms.Padding(0);
            widthValueLabel.Name = "widthValueLabel";
            widthValueLabel.Size = new System.Drawing.Size(100, 50);
            widthValueLabel.TabIndex = 3;
            widthValueLabel.Text = "0";
            widthValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heightFlowLayoutPanel
            // 
            heightFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            heightFlowLayoutPanel.Controls.Add(heightLabel);
            heightFlowLayoutPanel.Controls.Add(leftButtonHeightPictureBox);
            heightFlowLayoutPanel.Controls.Add(heightValueLabel);
            heightFlowLayoutPanel.Controls.Add(rightButtonHeightPictureBox);
            heightFlowLayoutPanel.Location = new System.Drawing.Point(12, 139);
            heightFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            heightFlowLayoutPanel.Name = "heightFlowLayoutPanel";
            heightFlowLayoutPanel.Size = new System.Drawing.Size(363, 50);
            heightFlowLayoutPanel.TabIndex = 3;
            // 
            // heightLabel
            // 
            heightLabel.BackColor = System.Drawing.Color.Transparent;
            heightLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            heightLabel.ForeColor = System.Drawing.Color.White;
            heightLabel.Location = new System.Drawing.Point(0, 0);
            heightLabel.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new System.Drawing.Size(140, 50);
            heightLabel.TabIndex = 7;
            heightLabel.Text = "Height:";
            heightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leftButtonHeightPictureBox
            // 
            leftButtonHeightPictureBox.BackColor = System.Drawing.Color.Transparent;
            leftButtonHeightPictureBox.Image = (System.Drawing.Image)resources.GetObject("leftButtonHeightPictureBox.Image");
            leftButtonHeightPictureBox.Location = new System.Drawing.Point(160, 0);
            leftButtonHeightPictureBox.Margin = new System.Windows.Forms.Padding(0);
            leftButtonHeightPictureBox.Name = "leftButtonHeightPictureBox";
            leftButtonHeightPictureBox.Size = new System.Drawing.Size(42, 50);
            leftButtonHeightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            leftButtonHeightPictureBox.TabIndex = 4;
            leftButtonHeightPictureBox.TabStop = false;
            leftButtonHeightPictureBox.MouseDown += LeftButtonHeightPictureBox_MouseDown;
            leftButtonHeightPictureBox.MouseEnter += LeftButtonHeightPictureBox_MouseEnter;
            leftButtonHeightPictureBox.MouseLeave += LeftButtonHeightPictureBox_MouseLeave;
            leftButtonHeightPictureBox.MouseUp += LeftButtonHeightPictureBox_MouseUp;
            // 
            // heightValueLabel
            // 
            heightValueLabel.BackColor = System.Drawing.Color.Transparent;
            heightValueLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            heightValueLabel.ForeColor = System.Drawing.Color.White;
            heightValueLabel.Location = new System.Drawing.Point(202, 0);
            heightValueLabel.Margin = new System.Windows.Forms.Padding(0);
            heightValueLabel.Name = "heightValueLabel";
            heightValueLabel.Size = new System.Drawing.Size(100, 50);
            heightValueLabel.TabIndex = 5;
            heightValueLabel.Text = "0";
            heightValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightButtonHeightPictureBox
            // 
            rightButtonHeightPictureBox.BackColor = System.Drawing.Color.Transparent;
            rightButtonHeightPictureBox.Image = (System.Drawing.Image)resources.GetObject("rightButtonHeightPictureBox.Image");
            rightButtonHeightPictureBox.Location = new System.Drawing.Point(302, 0);
            rightButtonHeightPictureBox.Margin = new System.Windows.Forms.Padding(0);
            rightButtonHeightPictureBox.Name = "rightButtonHeightPictureBox";
            rightButtonHeightPictureBox.Size = new System.Drawing.Size(42, 50);
            rightButtonHeightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            rightButtonHeightPictureBox.TabIndex = 6;
            rightButtonHeightPictureBox.TabStop = false;
            rightButtonHeightPictureBox.MouseDown += RightButtonHeightPictureBox_MouseDown;
            rightButtonHeightPictureBox.MouseEnter += RightButtonHeightPictureBox_MouseEnter;
            rightButtonHeightPictureBox.MouseLeave += RightButtonHeightPictureBox_MouseLeave;
            rightButtonHeightPictureBox.MouseUp += RightButtonHeightPictureBox_MouseUp;
            // 
            // minesFlowLayoutPanel
            // 
            minesFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            minesFlowLayoutPanel.Controls.Add(minesLabel);
            minesFlowLayoutPanel.Controls.Add(leftButtonMinesPictureBox);
            minesFlowLayoutPanel.Controls.Add(minesValueLabel);
            minesFlowLayoutPanel.Controls.Add(rightButtonMinesPictureBox);
            minesFlowLayoutPanel.Location = new System.Drawing.Point(12, 199);
            minesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            minesFlowLayoutPanel.Name = "minesFlowLayoutPanel";
            minesFlowLayoutPanel.Size = new System.Drawing.Size(363, 50);
            minesFlowLayoutPanel.TabIndex = 4;
            // 
            // minesLabel
            // 
            minesLabel.BackColor = System.Drawing.Color.Transparent;
            minesLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            minesLabel.ForeColor = System.Drawing.Color.White;
            minesLabel.Location = new System.Drawing.Point(0, 0);
            minesLabel.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            minesLabel.Name = "minesLabel";
            minesLabel.Size = new System.Drawing.Size(140, 50);
            minesLabel.TabIndex = 6;
            minesLabel.Text = "Mines:";
            minesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leftButtonMinesPictureBox
            // 
            leftButtonMinesPictureBox.BackColor = System.Drawing.Color.Transparent;
            leftButtonMinesPictureBox.Image = (System.Drawing.Image)resources.GetObject("leftButtonMinesPictureBox.Image");
            leftButtonMinesPictureBox.Location = new System.Drawing.Point(160, 0);
            leftButtonMinesPictureBox.Margin = new System.Windows.Forms.Padding(0);
            leftButtonMinesPictureBox.Name = "leftButtonMinesPictureBox";
            leftButtonMinesPictureBox.Size = new System.Drawing.Size(42, 50);
            leftButtonMinesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            leftButtonMinesPictureBox.TabIndex = 5;
            leftButtonMinesPictureBox.TabStop = false;
            leftButtonMinesPictureBox.MouseDown += LeftButtonMinesPictureBox_MouseDown;
            leftButtonMinesPictureBox.MouseEnter += LeftButtonMinesPictureBox_MouseEnter;
            leftButtonMinesPictureBox.MouseLeave += LeftButtonMinesPictureBox_MouseLeave;
            leftButtonMinesPictureBox.MouseUp += LeftButtonMinesPictureBox_MouseUp;
            // 
            // minesValueLabel
            // 
            minesValueLabel.BackColor = System.Drawing.Color.Transparent;
            minesValueLabel.Font = new System.Drawing.Font("Ink Free", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            minesValueLabel.ForeColor = System.Drawing.Color.White;
            minesValueLabel.Location = new System.Drawing.Point(202, 0);
            minesValueLabel.Margin = new System.Windows.Forms.Padding(0);
            minesValueLabel.Name = "minesValueLabel";
            minesValueLabel.Size = new System.Drawing.Size(100, 50);
            minesValueLabel.TabIndex = 6;
            minesValueLabel.Text = "0";
            minesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightButtonMinesPictureBox
            // 
            rightButtonMinesPictureBox.BackColor = System.Drawing.Color.Transparent;
            rightButtonMinesPictureBox.Image = (System.Drawing.Image)resources.GetObject("rightButtonMinesPictureBox.Image");
            rightButtonMinesPictureBox.Location = new System.Drawing.Point(302, 0);
            rightButtonMinesPictureBox.Margin = new System.Windows.Forms.Padding(0);
            rightButtonMinesPictureBox.Name = "rightButtonMinesPictureBox";
            rightButtonMinesPictureBox.Size = new System.Drawing.Size(42, 50);
            rightButtonMinesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            rightButtonMinesPictureBox.TabIndex = 7;
            rightButtonMinesPictureBox.TabStop = false;
            rightButtonMinesPictureBox.MouseDown += RightButtonMinesPictureBox_MouseDown;
            rightButtonMinesPictureBox.MouseEnter += RightButtonMinesPictureBox_MouseEnter;
            rightButtonMinesPictureBox.MouseLeave += RightButtonMinesPictureBox_MouseLeave;
            rightButtonMinesPictureBox.MouseUp += RightButtonMinesPictureBox_MouseUp;
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
            titleLabel.Size = new System.Drawing.Size(384, 50);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Options";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonOkPictureBox
            // 
            buttonOkPictureBox.BackColor = System.Drawing.Color.Transparent;
            buttonOkPictureBox.Image = (System.Drawing.Image)resources.GetObject("buttonOkPictureBox.Image");
            buttonOkPictureBox.Location = new System.Drawing.Point(48, 0);
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
            // buttonCancelPictureBox
            // 
            buttonCancelPictureBox.BackColor = System.Drawing.Color.Transparent;
            buttonCancelPictureBox.Image = (System.Drawing.Image)resources.GetObject("buttonCancelPictureBox.Image");
            buttonCancelPictureBox.Location = new System.Drawing.Point(216, 0);
            buttonCancelPictureBox.Margin = new System.Windows.Forms.Padding(0);
            buttonCancelPictureBox.Name = "buttonCancelPictureBox";
            buttonCancelPictureBox.Size = new System.Drawing.Size(120, 50);
            buttonCancelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            buttonCancelPictureBox.TabIndex = 7;
            buttonCancelPictureBox.TabStop = false;
            buttonCancelPictureBox.MouseDown += ButtonCancelPictureBox_MouseDown;
            buttonCancelPictureBox.MouseEnter += ButtonCancelPictureBox_MouseEnter;
            buttonCancelPictureBox.MouseLeave += ButtonCancelPictureBox_MouseLeave;
            buttonCancelPictureBox.MouseUp += ButtonCancelPictureBox_MouseUp;
            // 
            // buttonsPanel
            // 
            buttonsPanel.BackColor = System.Drawing.Color.Transparent;
            buttonsPanel.ColumnCount = 5;
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            buttonsPanel.Controls.Add(buttonOkPictureBox, 1, 0);
            buttonsPanel.Controls.Add(buttonCancelPictureBox, 3, 0);
            buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonsPanel.Location = new System.Drawing.Point(0, 296);
            buttonsPanel.Margin = new System.Windows.Forms.Padding(0);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.RowCount = 2;
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            buttonsPanel.Size = new System.Drawing.Size(384, 65);
            buttonsPanel.TabIndex = 8;
            // 
            // automaticValueChangeTimer
            // 
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Tick += AutomaticValueChangeTimer_Tick;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(148, 193, 30);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(384, 361);
            Controls.Add(buttonsPanel);
            Controls.Add(titleLabel);
            Controls.Add(minesFlowLayoutPanel);
            Controls.Add(heightFlowLayoutPanel);
            Controls.Add(widthFlowLayoutPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Ink Free", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Options";
            FormClosing += OptionsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)leftButtonWidthPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonWidthPictureBox).EndInit();
            widthFlowLayoutPanel.ResumeLayout(false);
            heightFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leftButtonHeightPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonHeightPictureBox).EndInit();
            minesFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leftButtonMinesPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightButtonMinesPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonOkPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonCancelPictureBox).EndInit();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox leftButtonWidthPictureBox;
        private System.Windows.Forms.PictureBox rightButtonWidthPictureBox;
        private System.Windows.Forms.FlowLayoutPanel widthFlowLayoutPanel;
        private System.Windows.Forms.Label widthValueLabel;
        private System.Windows.Forms.FlowLayoutPanel heightFlowLayoutPanel;
        private System.Windows.Forms.PictureBox leftButtonHeightPictureBox;
        private System.Windows.Forms.Label heightValueLabel;
        private System.Windows.Forms.PictureBox rightButtonHeightPictureBox;
        private System.Windows.Forms.FlowLayoutPanel minesFlowLayoutPanel;
        private System.Windows.Forms.PictureBox leftButtonMinesPictureBox;
        private System.Windows.Forms.Label minesValueLabel;
        private System.Windows.Forms.PictureBox rightButtonMinesPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label minesLabel;
        private System.Windows.Forms.PictureBox buttonOkPictureBox;
        private System.Windows.Forms.PictureBox buttonCancelPictureBox;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Timer automaticValueChangeTimer;
    }
}