using System;
using System.Windows.Forms;
using Minesweeper.Gui.Controller;
using Minesweeper.Gui.PictureManagement;

namespace Minesweeper.Gui
{
    public partial class OptionsForm : Form
    {
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly IMinesweeperController _controller;

        private int previousWidth;
        private int previousHeight;
        private int previousMinesCount;
        private PictureBox? _pictureBox;
        private int _counterForTimer;

        public OptionsForm(PictureBoxManager pictureBoxManager, IMinesweeperController controller)
        {
            InitializeComponent();

            CheckObject(pictureBoxManager);
            CheckObject(controller);

            _pictureBoxManager = pictureBoxManager;
            _controller = controller;

            var options = _controller.GetGameOptions();

            previousWidth = options.width;
            widthValueLabel.Text = previousWidth.ToString();
            if (!_controller.IsValidFieldWidth(previousWidth - 1))
            {
                _pictureBoxManager.ChangePicture(leftButtonWidthPictureBox, AliasForPictures.LeftButtonDown);
            }
            else if (!_controller.IsValidFieldWidth(previousWidth + 1))
            {
                _pictureBoxManager.ChangePicture(rightButtonWidthPictureBox, AliasForPictures.RightButtonDown);
            }

            previousHeight = options.height;
            heightValueLabel.Text = previousHeight.ToString();
            if (!_controller.IsValidFieldHeight(previousHeight - 1))
            {
                _pictureBoxManager.ChangePicture(leftButtonHeightPictureBox, AliasForPictures.LeftButtonDown);
            }
            else if (!_controller.IsValidFieldHeight(previousHeight + 1))
            {
                _pictureBoxManager.ChangePicture(rightButtonHeightPictureBox, AliasForPictures.RightButtonDown);
            }

            previousMinesCount = options.minesCount;
            minesValueLabel.Text = previousMinesCount.ToString();
            if (!_controller.IsValidMinesCount(previousMinesCount - 1))
            {
                _pictureBoxManager.ChangePicture(leftButtonMinesPictureBox, AliasForPictures.LeftButtonDown);
            }
            else if (!_controller.IsValidMinesCount(previousMinesCount + 1))
            {
                _pictureBoxManager.ChangePicture(rightButtonMinesPictureBox, AliasForPictures.RightButtonDown);
            }
        }

        private static void CheckObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        private void LeftButtonWidthPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldWidth(Convert.ToInt32(widthValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonWidthPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldWidth(Convert.ToInt32(widthValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonWidthPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldWidth(Convert.ToInt32(widthValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonWidthPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldWidth(Convert.ToInt32(widthValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonUp);
            }
        }

        private void LeftButtonHeightPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldHeight(Convert.ToInt32(heightValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonHeightPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldHeight(Convert.ToInt32(heightValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonHeightPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldHeight(Convert.ToInt32(heightValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonHeightPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidFieldHeight(Convert.ToInt32(heightValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonUp);
            }
        }

        private void LeftButtonMinesPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidMinesCount(Convert.ToInt32(minesValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonMinesPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidMinesCount(Convert.ToInt32(minesValueLabel.Text) - 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonMinesPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.IsValidMinesCount(Convert.ToInt32(minesValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonMinesPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.IsValidMinesCount(Convert.ToInt32(minesValueLabel.Text) + 1))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonUp);
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

        private void ButtonCancelPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonSelect);
        }

        private void ButtonCancelPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonUp);
        }

        private void LeftButtonWidthPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonDown);

            PressButton(widthValueLabel, rightButtonWidthPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldWidth,
                _controller.IsValidFieldWidth, ParameterAdjustmentDirection.Decrease);
            AdjustMinesCount();

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void LeftButtonWidthPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(widthValueLabel.Text), _controller.IsValidFieldWidth, (PictureBox)sender,
                AliasForPictures.LeftButtonDown, ParameterAdjustmentDirection.Decrease);
        }

        private void RightButtonWidthPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            PressButton(widthValueLabel, leftButtonWidthPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldWidth,
                _controller.IsValidFieldWidth, ParameterAdjustmentDirection.Increase);
            AdjustMinesCount();

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void RightButtonWidthPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(widthValueLabel.Text), _controller.IsValidFieldWidth, (PictureBox)sender,
                AliasForPictures.RightButtonDown, ParameterAdjustmentDirection.Increase);
        }

        private void LeftButtonHeightPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonDown);

            PressButton(heightValueLabel, rightButtonHeightPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldHeight,
                _controller.IsValidFieldHeight, ParameterAdjustmentDirection.Decrease);
            AdjustMinesCount();

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void LeftButtonHeightPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(heightValueLabel.Text), _controller.IsValidFieldHeight, (PictureBox)sender,
                AliasForPictures.LeftButtonDown, ParameterAdjustmentDirection.Decrease);
        }

        private void RightButtonHeightPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            PressButton(heightValueLabel, leftButtonHeightPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldHeight,
                _controller.IsValidFieldHeight, ParameterAdjustmentDirection.Increase);
            AdjustMinesCount();

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void RightButtonHeightPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(heightValueLabel.Text), _controller.IsValidFieldHeight, (PictureBox)sender,
                AliasForPictures.RightButtonDown, ParameterAdjustmentDirection.Increase);
        }

        private void LeftButtonMinesPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonDown);

            PressButton(minesValueLabel, rightButtonMinesPictureBox, AliasForPictures.RightButtonUp, _controller.SetMinesCount,
                _controller.IsValidMinesCount, ParameterAdjustmentDirection.Decrease);

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void LeftButtonMinesPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(minesValueLabel.Text), _controller.IsValidMinesCount, (PictureBox)sender,
                AliasForPictures.LeftButtonDown, ParameterAdjustmentDirection.Decrease);
        }

        private void RightButtonMinesPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            PressButton(minesValueLabel, leftButtonMinesPictureBox, AliasForPictures.LeftButtonUp, _controller.SetMinesCount,
                _controller.IsValidMinesCount, ParameterAdjustmentDirection.Increase);

            _pictureBox = (PictureBox)sender;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
        }

        private void RightButtonMinesPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(minesValueLabel.Text), _controller.IsValidMinesCount, (PictureBox)sender,
                AliasForPictures.RightButtonDown, ParameterAdjustmentDirection.Increase);
        }

        private void ButtonOkPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonDown);
        }

        private void ButtonOkPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OkButtonSelect);

            _controller.SaveGameOptions();
            Close();
        }

        private void ButtonCancelPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonDown);
        }

        private void ButtonCancelPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonSelect);

            _controller.SetFieldWidth(previousWidth);
            _controller.SetFieldHeight(previousHeight);
            _controller.SetMinesCount(previousMinesCount);

            Close();
        }

        private void AutomaticValueChangeTimer_Tick(object sender, EventArgs e)
        {
            if (_pictureBox is null)
            {
                automaticValueChangeTimer.Stop();

                return;
            }

            _counterForTimer++;

            if (_counterForTimer > 5 && _counterForTimer < 10)
            {
                automaticValueChangeTimer.Interval = 100;
            }

            if (_counterForTimer > 20 && _counterForTimer < 40)
            {
                automaticValueChangeTimer.Interval = 50;
            }

            if (_pictureBox.Equals(leftButtonWidthPictureBox))
            {
                PressButton(widthValueLabel, rightButtonWidthPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldWidth,
                    _controller.IsValidFieldWidth, ParameterAdjustmentDirection.Decrease);
                AdjustMinesCount();
            }
            else if (_pictureBox.Equals(leftButtonHeightPictureBox))
            {
                PressButton(heightValueLabel, rightButtonHeightPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldHeight,
                    _controller.IsValidFieldHeight, ParameterAdjustmentDirection.Decrease);
                AdjustMinesCount();
            }
            else if (_pictureBox.Equals(leftButtonMinesPictureBox))
            {
                PressButton(minesValueLabel, rightButtonMinesPictureBox, AliasForPictures.RightButtonUp, _controller.SetMinesCount,
                    _controller.IsValidMinesCount, ParameterAdjustmentDirection.Decrease);
            }
            else if (_pictureBox.Equals(rightButtonWidthPictureBox))
            {
                PressButton(widthValueLabel, leftButtonWidthPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldWidth,
                    _controller.IsValidFieldWidth, ParameterAdjustmentDirection.Increase);
            }
            else if (_pictureBox.Equals(rightButtonHeightPictureBox))
            {
                PressButton(heightValueLabel, leftButtonHeightPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldHeight,
                    _controller.IsValidFieldHeight, ParameterAdjustmentDirection.Increase);
            }
            else if (_pictureBox.Equals(rightButtonMinesPictureBox))
            {
                PressButton(minesValueLabel, leftButtonMinesPictureBox, AliasForPictures.LeftButtonUp, _controller.SetMinesCount,
                    _controller.IsValidMinesCount, ParameterAdjustmentDirection.Increase);
            }
        }

        private void SelectPictureInPictureBox(int value, Predicate<int> checkLimit, PictureBox pictureBox, AliasForPictures aliasButtonDown, ParameterAdjustmentDirection direction)
        {
            value = direction == ParameterAdjustmentDirection.Increase ? value + 1 : value - 1;

            if (checkLimit(value))
            {
                _pictureBoxManager.ChangePicture(pictureBox, aliasButtonDown + 2);
            }
            else
            {
                _pictureBoxManager.ChangePicture(pictureBox, aliasButtonDown);
            }
        }

        private void PressButton(Label label, PictureBox oppositeButton, AliasForPictures oppositeButtonUpAlias, Action<int> functionSetOption, Predicate<int> checkLimit, ParameterAdjustmentDirection direction)
        {
            var currentValue = Convert.ToInt32(label.Text);

            currentValue = direction == ParameterAdjustmentDirection.Increase ? currentValue + 1 : currentValue - 1;

            if (!checkLimit(currentValue))
            {
                return;
            }

            _pictureBoxManager.ChangePicture(oppositeButton, oppositeButtonUpAlias);

            label.Text = currentValue.ToString();
            functionSetOption(currentValue);
        }

        private void AdjustMinesCount()
        {
            var maxMinesCount = _controller.GetMaxMinesCount();

            if (Convert.ToInt32(minesValueLabel.Text) < maxMinesCount)
            {
                _pictureBoxManager.ChangePicture(rightButtonMinesPictureBox, AliasForPictures.RightButtonUp);

                return;
            }

            if (Convert.ToInt32(minesValueLabel.Text) >= maxMinesCount)
            {
                minesValueLabel.Text = maxMinesCount.ToString();
                _pictureBoxManager.ChangePicture(rightButtonMinesPictureBox, AliasForPictures.RightButtonDown);

                _controller.SetMinesCount(maxMinesCount);
            }
        }
    }
}
