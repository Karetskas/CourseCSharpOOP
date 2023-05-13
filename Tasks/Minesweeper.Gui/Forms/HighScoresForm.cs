using System;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.Gui.Controller;
using Minesweeper.Gui.PictureManagement;

namespace Minesweeper.Gui
{
    public partial class HighScoresForm : Form
    {
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly IMinesweeperController _controller;

        public HighScoresForm(PictureBoxManager pictureBoxManager, IMinesweeperController controller)
        {
            InitializeComponent();

            CheckObject(pictureBoxManager);
            CheckObject(controller);

            _pictureBoxManager = pictureBoxManager;
            _controller = controller;

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

            if (records.Count == 0)
            {
                highScoresLabel.Font = new Font("Ink Free", 20, FontStyle.Bold);
                highScoresLabel.TextAlign = ContentAlignment.MiddleCenter;
                highScoresLabel.Text = "No records!";

                return;
            }

            var i = 1;

            highScoresLabel.Font = new Font("Ink Free", 12, FontStyle.Bold);
            highScoresLabel.TextAlign = ContentAlignment.MiddleLeft;

            foreach (var gameResult in records)
            {
                highScoresLabel.Text += $@"{i}. Size: {gameResult.Field.width}x{gameResult.Field.height}; "
                                        + $@"Mines: {gameResult.MinesCount}; Time: {gameResult.GameTime:hh\:mm\:ss\:f}"
                                        + Environment.NewLine;

                i++;
            }
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
        }

        private void ButtonOkPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonSelect);

            Close();
        }
    }
}
