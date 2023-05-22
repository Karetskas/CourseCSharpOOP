namespace Academits.Karetskas.Minesweeper.Gui.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            colorTransfusionTimer = new System.Windows.Forms.Timer(components);
            leftFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            titleLabel = new System.Windows.Forms.Label();
            newGamePictureBox = new System.Windows.Forms.PictureBox();
            highScoresPictureBox = new System.Windows.Forms.PictureBox();
            optionsPictureBox = new System.Windows.Forms.PictureBox();
            aboutPictureBox = new System.Windows.Forms.PictureBox();
            exitPictureBox = new System.Windows.Forms.PictureBox();
            soldierPictureBox = new System.Windows.Forms.PictureBox();
            informationPanel = new System.Windows.Forms.TableLayoutPanel();
            timeLabel = new System.Windows.Forms.Label();
            resultPanel = new System.Windows.Forms.Panel();
            resultGameLabel = new System.Windows.Forms.Label();
            minesFoundCountLabel = new System.Windows.Forms.Label();
            panelForMap = new System.Windows.Forms.Panel();
            mapPanel = new System.Windows.Forms.TableLayoutPanel();
            leftFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)newGamePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)highScoresPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)optionsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aboutPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exitPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)soldierPictureBox).BeginInit();
            informationPanel.SuspendLayout();
            resultPanel.SuspendLayout();
            panelForMap.SuspendLayout();
            SuspendLayout();
            // 
            // colorTransfusionTimer
            // 
            colorTransfusionTimer.Tick += ColorTransfusionTimer_Tick;
            // 
            // leftFlowLayoutPanel
            // 
            leftFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            leftFlowLayoutPanel.Controls.Add(titleLabel);
            leftFlowLayoutPanel.Controls.Add(newGamePictureBox);
            leftFlowLayoutPanel.Controls.Add(highScoresPictureBox);
            leftFlowLayoutPanel.Controls.Add(optionsPictureBox);
            leftFlowLayoutPanel.Controls.Add(aboutPictureBox);
            leftFlowLayoutPanel.Controls.Add(exitPictureBox);
            leftFlowLayoutPanel.Controls.Add(soldierPictureBox);
            leftFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            leftFlowLayoutPanel.Location = new System.Drawing.Point(10, 10);
            leftFlowLayoutPanel.Name = "leftFlowLayoutPanel";
            leftFlowLayoutPanel.Size = new System.Drawing.Size(213, 541);
            leftFlowLayoutPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new System.Drawing.Font("Ink Free", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(252, 137, 28);
            titleLabel.Location = new System.Drawing.Point(11, 15);
            titleLabel.Margin = new System.Windows.Forms.Padding(11, 15, 3, 5);
            titleLabel.Name = "titleLabel";
            titleLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            titleLabel.Size = new System.Drawing.Size(191, 47);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Minesweeper";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            titleLabel.MouseEnter += TitleLabel_MouseEnter;
            // 
            // newGamePictureBox
            // 
            newGamePictureBox.BackColor = System.Drawing.Color.Transparent;
            newGamePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            newGamePictureBox.Image = (System.Drawing.Image)resources.GetObject("newGamePictureBox.Image");
            newGamePictureBox.Location = new System.Drawing.Point(20, 75);
            newGamePictureBox.Margin = new System.Windows.Forms.Padding(20, 8, 0, 0);
            newGamePictureBox.Name = "newGamePictureBox";
            newGamePictureBox.Size = new System.Drawing.Size(170, 50);
            newGamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            newGamePictureBox.TabIndex = 1;
            newGamePictureBox.TabStop = false;
            newGamePictureBox.MouseDown += NewGamePictureBox_MouseDown;
            newGamePictureBox.MouseEnter += NewGamePictureBox_MouseEnter;
            newGamePictureBox.MouseLeave += NewGamePictureBox_MouseLeave;
            newGamePictureBox.MouseUp += NewGamePictureBox_MouseUp;
            // 
            // highScoresPictureBox
            // 
            highScoresPictureBox.BackColor = System.Drawing.Color.Transparent;
            highScoresPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            highScoresPictureBox.Image = (System.Drawing.Image)resources.GetObject("highScoresPictureBox.Image");
            highScoresPictureBox.Location = new System.Drawing.Point(20, 133);
            highScoresPictureBox.Margin = new System.Windows.Forms.Padding(20, 8, 0, 0);
            highScoresPictureBox.Name = "highScoresPictureBox";
            highScoresPictureBox.Size = new System.Drawing.Size(170, 50);
            highScoresPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            highScoresPictureBox.TabIndex = 2;
            highScoresPictureBox.TabStop = false;
            highScoresPictureBox.MouseDown += HighScoresPictureBox_MouseDown;
            highScoresPictureBox.MouseEnter += HighScoresPictureBox_MouseEnter;
            highScoresPictureBox.MouseLeave += HighScoresPictureBox_MouseLeave;
            highScoresPictureBox.MouseUp += HighScoresPictureBox_MouseUp;
            // 
            // optionsPictureBox
            // 
            optionsPictureBox.BackColor = System.Drawing.Color.Transparent;
            optionsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            optionsPictureBox.Image = (System.Drawing.Image)resources.GetObject("optionsPictureBox.Image");
            optionsPictureBox.Location = new System.Drawing.Point(20, 191);
            optionsPictureBox.Margin = new System.Windows.Forms.Padding(20, 8, 0, 0);
            optionsPictureBox.Name = "optionsPictureBox";
            optionsPictureBox.Size = new System.Drawing.Size(170, 50);
            optionsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            optionsPictureBox.TabIndex = 3;
            optionsPictureBox.TabStop = false;
            optionsPictureBox.MouseDown += OptionsPictureBox_MouseDown;
            optionsPictureBox.MouseEnter += OptionsPictureBox_MouseEnter;
            optionsPictureBox.MouseLeave += OptionsPictureBox_MouseLeave;
            optionsPictureBox.MouseUp += OptionsPictureBox_MouseUp;
            // 
            // aboutPictureBox
            // 
            aboutPictureBox.BackColor = System.Drawing.Color.Transparent;
            aboutPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            aboutPictureBox.Image = (System.Drawing.Image)resources.GetObject("aboutPictureBox.Image");
            aboutPictureBox.Location = new System.Drawing.Point(20, 249);
            aboutPictureBox.Margin = new System.Windows.Forms.Padding(20, 8, 0, 0);
            aboutPictureBox.Name = "aboutPictureBox";
            aboutPictureBox.Size = new System.Drawing.Size(170, 50);
            aboutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            aboutPictureBox.TabIndex = 4;
            aboutPictureBox.TabStop = false;
            aboutPictureBox.MouseDown += AboutPictureBox_MouseDown;
            aboutPictureBox.MouseEnter += AboutPictureBox_MouseEnter;
            aboutPictureBox.MouseLeave += AboutPictureBox_MouseLeave;
            aboutPictureBox.MouseUp += AboutPictureBox_MouseUp;
            // 
            // exitPictureBox
            // 
            exitPictureBox.BackColor = System.Drawing.Color.Transparent;
            exitPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            exitPictureBox.Image = (System.Drawing.Image)resources.GetObject("exitPictureBox.Image");
            exitPictureBox.Location = new System.Drawing.Point(20, 307);
            exitPictureBox.Margin = new System.Windows.Forms.Padding(20, 8, 0, 10);
            exitPictureBox.Name = "exitPictureBox";
            exitPictureBox.Size = new System.Drawing.Size(170, 50);
            exitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            exitPictureBox.TabIndex = 5;
            exitPictureBox.TabStop = false;
            exitPictureBox.MouseDown += ExitPictureBox_MouseDown;
            exitPictureBox.MouseEnter += ExitPictureBox_MouseEnter;
            exitPictureBox.MouseLeave += ExitPictureBox_MouseLeave;
            exitPictureBox.MouseUp += ExitPictureBox_MouseUp;
            // 
            // soldierPictureBox
            // 
            soldierPictureBox.BackColor = System.Drawing.Color.Transparent;
            soldierPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            soldierPictureBox.Image = (System.Drawing.Image)resources.GetObject("soldierPictureBox.Image");
            soldierPictureBox.Location = new System.Drawing.Point(20, 367);
            soldierPictureBox.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            soldierPictureBox.Name = "soldierPictureBox";
            soldierPictureBox.Size = new System.Drawing.Size(174, 174);
            soldierPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            soldierPictureBox.TabIndex = 6;
            soldierPictureBox.TabStop = false;
            soldierPictureBox.MouseEnter += SoldierPictureBox_MouseEnter;
            // 
            // informationPanel
            // 
            informationPanel.BackColor = System.Drawing.Color.Transparent;
            informationPanel.ColumnCount = 3;
            informationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            informationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            informationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            informationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            informationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            informationPanel.Controls.Add(timeLabel, 2, 0);
            informationPanel.Controls.Add(resultPanel, 1, 0);
            informationPanel.Controls.Add(minesFoundCountLabel, 0, 0);
            informationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            informationPanel.Location = new System.Drawing.Point(223, 10);
            informationPanel.Name = "informationPanel";
            informationPanel.RowCount = 1;
            informationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            informationPanel.Size = new System.Drawing.Size(551, 60);
            informationPanel.TabIndex = 1;
            informationPanel.MouseEnter += InformationPanel_MouseEnter;
            // 
            // timeLabel
            // 
            timeLabel.BackColor = System.Drawing.Color.Transparent;
            timeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            timeLabel.Font = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            timeLabel.ForeColor = System.Drawing.Color.FromArgb(96, 26, 60);
            timeLabel.Image = (System.Drawing.Image)resources.GetObject("timeLabel.Image");
            timeLabel.Location = new System.Drawing.Point(351, 5);
            timeLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(200, 50);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "  Time: 00:00:00.0";
            timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            timeLabel.MouseEnter += TimeLabel_MouseEnter;
            // 
            // resultPanel
            // 
            resultPanel.BackColor = System.Drawing.Color.Transparent;
            resultPanel.BackgroundImage = (System.Drawing.Image)resources.GetObject("resultPanel.BackgroundImage");
            resultPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            resultPanel.Controls.Add(resultGameLabel);
            resultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            resultPanel.Location = new System.Drawing.Point(203, 5);
            resultPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            resultPanel.Name = "resultPanel";
            resultPanel.Size = new System.Drawing.Size(145, 50);
            resultPanel.TabIndex = 2;
            // 
            // resultGameLabel
            // 
            resultGameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            resultGameLabel.Font = new System.Drawing.Font("Ink Free", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            resultGameLabel.ForeColor = System.Drawing.Color.FromArgb(96, 26, 60);
            resultGameLabel.Location = new System.Drawing.Point(0, 0);
            resultGameLabel.Name = "resultGameLabel";
            resultGameLabel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            resultGameLabel.Size = new System.Drawing.Size(145, 50);
            resultGameLabel.TabIndex = 0;
            resultGameLabel.Text = "GAME";
            resultGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            resultGameLabel.MouseEnter += ResultGameLabel_MouseEnter;
            // 
            // minesFoundCountLabel
            // 
            minesFoundCountLabel.BackColor = System.Drawing.Color.Transparent;
            minesFoundCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            minesFoundCountLabel.Font = new System.Drawing.Font("Ink Free", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            minesFoundCountLabel.ForeColor = System.Drawing.Color.FromArgb(96, 26, 60);
            minesFoundCountLabel.Image = (System.Drawing.Image)resources.GetObject("minesFoundCountLabel.Image");
            minesFoundCountLabel.Location = new System.Drawing.Point(0, 5);
            minesFoundCountLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            minesFoundCountLabel.Name = "minesFoundCountLabel";
            minesFoundCountLabel.Size = new System.Drawing.Size(200, 50);
            minesFoundCountLabel.TabIndex = 4;
            minesFoundCountLabel.Text = "Mines: 0";
            minesFoundCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            minesFoundCountLabel.MouseEnter += MinesFoundCountLabel_MouseEnter;
            // 
            // panelForMap
            // 
            panelForMap.AutoSize = true;
            panelForMap.BackColor = System.Drawing.Color.FromArgb(148, 193, 30);
            panelForMap.Controls.Add(mapPanel);
            panelForMap.Dock = System.Windows.Forms.DockStyle.Fill;
            panelForMap.Location = new System.Drawing.Point(223, 70);
            panelForMap.Margin = new System.Windows.Forms.Padding(0);
            panelForMap.Name = "panelForMap";
            panelForMap.Size = new System.Drawing.Size(551, 481);
            panelForMap.TabIndex = 2;
            panelForMap.MouseEnter += PanelForMap_MouseEnter;
            // 
            // mapPanel
            // 
            mapPanel.AutoSize = true;
            mapPanel.BackColor = System.Drawing.Color.FromArgb(148, 193, 30);
            mapPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mapPanel.ColumnCount = 1;
            mapPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            mapPanel.Location = new System.Drawing.Point(10, 10);
            mapPanel.Margin = new System.Windows.Forms.Padding(0);
            mapPanel.Name = "mapPanel";
            mapPanel.RowCount = 1;
            mapPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            mapPanel.Size = new System.Drawing.Size(100, 100);
            mapPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(164, 62, 0);
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(panelForMap);
            Controls.Add(informationPanel);
            Controls.Add(leftFlowLayoutPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Ink Free", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Padding = new System.Windows.Forms.Padding(10);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            FormClosing += MainForm_FormClosing;
            leftFlowLayoutPanel.ResumeLayout(false);
            leftFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)newGamePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)highScoresPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)optionsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)aboutPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)exitPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)soldierPictureBox).EndInit();
            informationPanel.ResumeLayout(false);
            resultPanel.ResumeLayout(false);
            panelForMap.ResumeLayout(false);
            panelForMap.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer colorTransfusionTimer;
        private System.Windows.Forms.FlowLayoutPanel leftFlowLayoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox newGamePictureBox;
        private System.Windows.Forms.PictureBox highScoresPictureBox;
        private System.Windows.Forms.PictureBox optionsPictureBox;
        private System.Windows.Forms.PictureBox aboutPictureBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
        private System.Windows.Forms.PictureBox soldierPictureBox;
        private System.Windows.Forms.TableLayoutPanel informationPanel;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultGameLabel;
        private System.Windows.Forms.Label minesFoundCountLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel panelForMap;
        private System.Windows.Forms.TableLayoutPanel mapPanel;
    }
}