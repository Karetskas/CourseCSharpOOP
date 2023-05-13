using System;
using System.Windows.Forms;
using Minesweeper.Gui.PictureManagement;

namespace Minesweeper.Gui
{
    public partial class AboutForm : Form
    {
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly ColorInterpolator _colorInterpolator;

        public AboutForm(PictureBoxManager pictureBoxManager)
        {
            InitializeComponent();

            _pictureBoxManager = pictureBoxManager ?? throw new ArgumentNullException(nameof(pictureBoxManager),
                $@"The argument {nameof(pictureBoxManager)} is null.");

            _colorInterpolator = new ColorInterpolator();

            colorTransfusionTimer.Start();
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

        private void СolorTransfusionTimer_Tick(object sender, EventArgs e)
        {
            informationLabel.ForeColor = _colorInterpolator.GetTransfusionEffectInAllColors();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            colorTransfusionTimer.Stop();
        }
    }
}
