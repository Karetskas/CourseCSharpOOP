using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Gui.Controller;
using Academits.Karetskas.Minesweeper.Gui.PictureManagement;

namespace Academits.Karetskas.Minesweeper.Gui.Forms
{
    public partial class HighScoresForm : Form
    {
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly IMinesweeperController _controller;
        private readonly SoundManager _soundManager;

        public HighScoresForm(PictureBoxManager pictureBoxManager, IMinesweeperController controller)
        {
            InitializeComponent();

            CheckObject(pictureBoxManager);
            CheckObject(controller);

            _pictureBoxManager = pictureBoxManager;
            _controller = controller;
            _soundManager = new SoundManager();

            LoadHighScores();
        }

        private static void CheckObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        private void LoadHighScores()
        {
            var records = _controller.GetGameResults();

            tableResultsPanel.SuspendLayout();

            if (records.Count == 0)
            {
                var label = CreateLabel("No records!", 20, FontStyle.Bold);
                label.Size = tableResultsPanel.Size;
                tableResultsPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                tableResultsPanel.Controls.Add(label, 0, 0);

                return;
            }

            const int columnsCount = 4;
            tableResultsPanel.ColumnCount = columnsCount;
            tableResultsPanel.RowCount = records.Count;

            var tableHeaderColumnsNames = new string[]
            {
                "#",
                "Size",
                "Mines",
                "Time"
            };

            CreateTableRow(tableHeaderColumnsNames, columnsCount,
                (rowCell, column) =>
                    tableResultsPanel.Controls.Add(CreateLabel(rowCell, 14, FontStyle.Bold), column, 0));

            var rowNumber = 1;

            foreach (var gameResult in records)
            {
                tableResultsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var resultRowElements = new string[]
                {
                    rowNumber.ToString(),
                    $"{gameResult.Field.width}x{gameResult.Field.height}",
                    gameResult.MinesCount.ToString(),
                    gameResult.GameTime.ToString(@"hh\:mm\:ss\.f")
                };

                CreateTableRow(resultRowElements, columnsCount,
                    (rowCell, column) =>
                        tableResultsPanel.Controls.Add(CreateLabel(rowCell, 11, FontStyle.Regular), column, rowNumber));

                rowNumber++;
            }

            tableResultsPanel.ResumeLayout();
        }

        private void CreateTableRow(string[] rowCells, int columnsCount, Action<string, int> addColumn)
        {
            for (var column = 0; column < columnsCount; column++)
            {
                tableResultsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

                addColumn(rowCells[column], column);

                tableResultsPanel.GetControlFromPosition(column, 0).Margin = new Padding(0);
            }
        }

        private static Label CreateLabel(string? text, float fontSize, FontStyle fontStyle)
        {
            var label = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Ink Free", fontSize, fontStyle),
                ForeColor = Color.White,
                Margin = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Text = text ?? ""
            };

            return label;
        }

        private void ButtonOkPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonSelect);
        }

        private void ButtonOkPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonUp);
        }

        private void ButtonOkPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonDown);

            _soundManager.PlayButtonPress();
            Thread.Sleep(350);
        }

        private void ButtonOkPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonSelect);

            Close();
        }
    }
}
