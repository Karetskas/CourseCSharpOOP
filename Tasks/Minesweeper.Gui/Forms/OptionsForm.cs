using System;
using System.Threading;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Gui.Controller;
using Academits.Karetskas.Minesweeper.Gui.PictureManagement;

namespace Academits.Karetskas.Minesweeper.Gui.Forms
{
    public partial class OptionsForm : Form
    {
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly IMinesweeperController _controller;
        private readonly SoundManager _soundManager;
        private readonly int _previousWidth;
        private readonly int _previousHeight;
        private readonly int _previousMinesCount;

        private PictureBox? _pictureBox;
        private int _counterForTimer;
        private bool _isSaved;

        public OptionsForm(PictureBoxManager pictureBoxManager, IMinesweeperController controller)
        {
            InitializeComponent();

            CheckObject(pictureBoxManager);
            CheckObject(controller);

            _pictureBoxManager = pictureBoxManager;
            _controller = controller;
            _soundManager = new SoundManager();

            var (width, height, minesCount) = _controller.GetGameOptions();

            _previousWidth = width;
            widthValueLabel.Text = _previousWidth.ToString();
            CheckOptionLimit(_controller.GetMinFieldSize(), width, leftButtonWidthPictureBox,
                AliasForPictures.LeftButtonDown);
            CheckOptionLimit(_controller.GetMaxFieldSize(), width, rightButtonWidthPictureBox,
                AliasForPictures.RightButtonDown);

            _previousHeight = height;
            heightValueLabel.Text = _previousHeight.ToString();
            CheckOptionLimit(_controller.GetMinFieldSize(), height, leftButtonHeightPictureBox,
                AliasForPictures.LeftButtonDown);
            CheckOptionLimit(_controller.GetMaxFieldSize(), height, rightButtonHeightPictureBox,
                AliasForPictures.RightButtonDown);

            _previousMinesCount = minesCount;
            minesValueLabel.Text = _previousMinesCount.ToString();
            CheckOptionLimit(_controller.GetMinMinesCount(), minesCount, leftButtonMinesPictureBox,
                AliasForPictures.LeftButtonDown);
            CheckOptionLimit(_controller.GetMaxMinesCount(), minesCount, rightButtonMinesPictureBox,
                AliasForPictures.RightButtonDown);

            _isSaved = false;
        }

        private static void CheckObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        private void CheckOptionLimit(int limitValue, int option, PictureBox pictureBox, AliasForPictures aliasForPictures)
        {
            if (option == limitValue)
            {
                _pictureBoxManager.ChangePicture(pictureBox, aliasForPictures);
            }
        }

        private void LeftButtonWidthPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMinFieldSize() != Convert.ToInt32(widthValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonWidthPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMinFieldSize() != Convert.ToInt32(widthValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonWidthPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMaxFieldSize() != Convert.ToInt32(widthValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonWidthPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMaxFieldSize() != Convert.ToInt32(widthValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonUp);
            }
        }

        private void LeftButtonHeightPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMinFieldSize() != Convert.ToInt32(heightValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonHeightPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMinFieldSize() != Convert.ToInt32(heightValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonHeightPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMaxFieldSize() != Convert.ToInt32(heightValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonHeightPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMaxFieldSize() != Convert.ToInt32(heightValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonUp);
            }
        }

        private void LeftButtonMinesPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMinMinesCount() != Convert.ToInt32(minesValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonSelect);
            }
        }

        private void LeftButtonMinesPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMinMinesCount() != Convert.ToInt32(minesValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonUp);
            }
        }

        private void RightButtonMinesPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (_controller.GetMaxMinesCount() != Convert.ToInt32(minesValueLabel.Text))
            {
                _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonSelect);
            }
        }

        private void RightButtonMinesPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (_controller.GetMaxMinesCount() != Convert.ToInt32(minesValueLabel.Text))
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

            _soundManager.PlayButtonPress();

            PressButton(widthValueLabel, rightButtonWidthPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldWidth,
                _controller.GetMinFieldSize(), ParameterAdjustmentDirection.Decrease);
            AdjustMinesCount();

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void LeftButtonWidthPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(widthValueLabel.Text), _controller.GetMinFieldSize(), (PictureBox)sender,
                AliasForPictures.LeftButtonDown);
        }

        private void RightButtonWidthPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            _soundManager.PlayButtonPress();

            PressButton(widthValueLabel, leftButtonWidthPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldWidth,
                _controller.GetMaxFieldSize(), ParameterAdjustmentDirection.Increase);
            AdjustMinesCount();

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void RightButtonWidthPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(widthValueLabel.Text), _controller.GetMaxFieldSize(), (PictureBox)sender,
                AliasForPictures.RightButtonDown);
        }

        private void LeftButtonHeightPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonDown);

            _soundManager.PlayButtonPress();

            PressButton(heightValueLabel, rightButtonHeightPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldHeight,
                _controller.GetMinFieldSize(), ParameterAdjustmentDirection.Decrease);
            AdjustMinesCount();

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void LeftButtonHeightPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(heightValueLabel.Text), _controller.GetMinFieldSize(), (PictureBox)sender,
                AliasForPictures.LeftButtonDown);
        }

        private void RightButtonHeightPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            _soundManager.PlayButtonPress();

            PressButton(heightValueLabel, leftButtonHeightPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldHeight,
                _controller.GetMaxFieldSize(), ParameterAdjustmentDirection.Increase);
            AdjustMinesCount();

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void RightButtonHeightPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(heightValueLabel.Text), _controller.GetMaxFieldSize(), (PictureBox)sender,
                AliasForPictures.RightButtonDown);
        }

        private void LeftButtonMinesPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.LeftButtonDown);

            _soundManager.PlayButtonPress();

            PressButton(minesValueLabel, rightButtonMinesPictureBox, AliasForPictures.RightButtonUp, _controller.SetMinesCount,
                _controller.GetMinMinesCount(), ParameterAdjustmentDirection.Decrease);

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void LeftButtonMinesPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(minesValueLabel.Text), _controller.GetMinMinesCount(), (PictureBox)sender,
                AliasForPictures.LeftButtonDown);
        }

        private void RightButtonMinesPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.RightButtonDown);

            _soundManager.PlayButtonPress();

            PressButton(minesValueLabel, leftButtonMinesPictureBox, AliasForPictures.LeftButtonUp, _controller.SetMinesCount,
                _controller.GetMaxMinesCount(), ParameterAdjustmentDirection.Increase);

            StartTimerToAutomaticallyChangeValues(sender);
        }

        private void RightButtonMinesPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            automaticValueChangeTimer.Stop();

            SelectPictureInPictureBox(Convert.ToInt32(minesValueLabel.Text), _controller.GetMaxMinesCount(), (PictureBox)sender,
                AliasForPictures.RightButtonDown);
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

            _controller.SaveGameOptions();
            _isSaved = true;

            Close();
        }

        private void ButtonCancelPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonDown);

            _soundManager.PlayButtonPress();
            Thread.Sleep(350);
        }

        private void ButtonCancelPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.CancelButtonSelect);
            
            Close();
        }
        
        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isSaved)
            {
                return;
            }

            _controller.SetFieldWidth(_previousWidth);
            _controller.SetFieldHeight(_previousHeight);
            _controller.SetMinesCount(_previousMinesCount);
        }

        private void StartTimerToAutomaticallyChangeValues(object obj)
        {
            _pictureBox = (PictureBox)obj;
            _counterForTimer = 0;
            automaticValueChangeTimer.Interval = 250;
            automaticValueChangeTimer.Start();
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

            if (_counterForTimer > 100)
            {
                automaticValueChangeTimer.Interval = 25;
            }

            if (_pictureBox.Equals(leftButtonWidthPictureBox))
            {
                PressButton(widthValueLabel, rightButtonWidthPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldWidth,
                    _controller.GetMinFieldSize(), ParameterAdjustmentDirection.Decrease);
                AdjustMinesCount();
            }
            else if (_pictureBox.Equals(leftButtonHeightPictureBox))
            {
                PressButton(heightValueLabel, rightButtonHeightPictureBox, AliasForPictures.RightButtonUp, _controller.SetFieldHeight,
                    _controller.GetMinFieldSize(), ParameterAdjustmentDirection.Decrease);
                AdjustMinesCount();
            }
            else if (_pictureBox.Equals(leftButtonMinesPictureBox))
            {
                PressButton(minesValueLabel, rightButtonMinesPictureBox, AliasForPictures.RightButtonUp, _controller.SetMinesCount,
                    _controller.GetMinMinesCount(), ParameterAdjustmentDirection.Decrease);
            }
            else if (_pictureBox.Equals(rightButtonWidthPictureBox))
            {
                PressButton(widthValueLabel, leftButtonWidthPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldWidth,
                    _controller.GetMaxFieldSize(), ParameterAdjustmentDirection.Increase);
            }
            else if (_pictureBox.Equals(rightButtonHeightPictureBox))
            {
                PressButton(heightValueLabel, leftButtonHeightPictureBox, AliasForPictures.LeftButtonUp, _controller.SetFieldHeight,
                    _controller.GetMaxFieldSize(), ParameterAdjustmentDirection.Increase);
            }
            else if (_pictureBox.Equals(rightButtonMinesPictureBox))
            {
                PressButton(minesValueLabel, leftButtonMinesPictureBox, AliasForPictures.LeftButtonUp, _controller.SetMinesCount,
                    _controller.GetMaxMinesCount(), ParameterAdjustmentDirection.Increase);
            }
        }

        private void SelectPictureInPictureBox(int value, int limitValue, PictureBox pictureBox, AliasForPictures aliasButtonDown)
        {
            if (value != limitValue)
            {
                _pictureBoxManager.ChangePicture(pictureBox, aliasButtonDown + 2);
            }
            else
            {
                _pictureBoxManager.ChangePicture(pictureBox, aliasButtonDown);
            }
        }

        private void PressButton(Label label, PictureBox oppositeButton, AliasForPictures oppositeButtonUpAlias, Action<int> functionSetOption, int limitValue, ParameterAdjustmentDirection direction)
        {
            var currentValue = Convert.ToInt32(label.Text);

            currentValue = direction == ParameterAdjustmentDirection.Increase
                ? currentValue + 1
                : currentValue - 1;

            if ((direction == ParameterAdjustmentDirection.Increase && currentValue > limitValue)
                || (direction == ParameterAdjustmentDirection.Decrease && currentValue < limitValue))
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
