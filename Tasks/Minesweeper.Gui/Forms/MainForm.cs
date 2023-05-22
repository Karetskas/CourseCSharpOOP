using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Gui.Controller;
using Academits.Karetskas.Minesweeper.Logic.Minefield;
using Academits.Karetskas.Minesweeper.Logic.GameManager;
using Academits.Karetskas.Minesweeper.Gui.PictureManagement;

namespace Academits.Karetskas.Minesweeper.Gui.Forms
{
    public partial class MainForm : Form
    {
        private GameOutcome _outcome;
        private bool _isGameStart;

        private readonly PictureBoxManager _pictureBoxManager;
        private readonly ColorInterpolator _colorInterpolator;
        private readonly IMinesweeperController _controller;
        private readonly SoundManager _soundManager;
        private readonly Map _map;

        public MainForm(IMinesweeperController controller, IGameManager model)
        {
            InitializeComponent();

            CheckObject(controller);
            CheckObject(model);

            _controller = controller;
            _isGameStart = false;

            model.RefreshMap += RefreshMap;
            model.MinesFoundCount += RefreshMinesFoundCount;
            model.TimeUpdate += TimeUpdate;
            model.EndGame += EndGame;

            _pictureBoxManager = new PictureBoxManager();
            _soundManager = new SoundManager();

            var (width, height, _) = _controller.GetGameOptions();
            _map = new Map(width, height, _controller.GetMaxFieldSize(), mapPanel, _pictureBoxManager);
            _controller.CreateNewGame();

            _map.CellLeftMouseClick += (_, _) =>
            {
                if (_outcome == GameOutcome.None)
                {
                    _soundManager.PlayCheckCell();
                }

                _isGameStart = true;
            };
            _map.CellLeftMouseClick += _controller.CheckCell;

            _map.CellRightMouseClick += (_, _) =>
            {
                if (_outcome == GameOutcome.None)
                {
                    _soundManager.PlayMarkCell();
                }
            };
            _map.CellRightMouseClick += _controller.LeaveNote;

            _map.CellMiddleMouseClick += (_, _) =>
            {
                if (_outcome == GameOutcome.None)
                {
                    _soundManager.PlayCheckCell();
                }
            };
            _map.CellMiddleMouseClick += _controller.CheckNearbyCells;

            _map.MouseCursorEnterCell += SetSoldierEmotion;
            _map.MouseChangeCell += SetSoldierEmotion;

            _colorInterpolator = new ColorInterpolator();
            _outcome = GameOutcome.None;
        }

        private static void CheckObject(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        private void SetSoldierEmotion(AliasForPictures aliasForPictures)
        {
            switch (_outcome)
            {
                case GameOutcome.Victory:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionWhenVictory);
                    return;
                case GameOutcome.Defeat:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionWhenDefeat);
                    return;
            }

            switch (aliasForPictures)
            {
                case AliasForPictures.SoldierEmotionOnForm:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnForm);
                    break;
                case AliasForPictures.CellFullDown:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnFullCell);
                    break;
                case AliasForPictures.CellWithFlagDown:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnCellWithFlag);
                    break;
                case AliasForPictures.CellWithQuestionDown:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnCellWithQuestion);
                    break;
                default:
                    _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnEmptyCell);
                    break;
            }
        }

        private void RefreshMap(Cell[,] map)
        {
            _map.ChangeMap(map);
        }

        private void RefreshMinesFoundCount(int minesFoundCount)
        {
            minesFoundCountLabel.Text = $"Mines: {minesFoundCount}";
        }

        private void TimeUpdate(TimeSpan currentGameTime)
        {
            if (timeLabel.InvokeRequired)
            {
                timeLabel.BeginInvoke(() =>
                {
                    if (_isGameStart)
                    {
                        timeLabel.Text = $@"  Time: {currentGameTime:hh\:mm\:ss\.f}";
                    }
                });

                return;
            }

            _isGameStart = false;

            timeLabel.Text = $@"  Time: {currentGameTime:hh\:mm\:ss\.f}";
        }

        private void EndGame(GameOutcome outcome)
        {
            if (outcome == GameOutcome.Defeat)
            {
                _outcome = GameOutcome.Defeat;
                resultGameLabel.Text = "DEFEAT";
                SetSoldierEmotion(0);

                _soundManager.PlayDefeat();
            }
            else
            {
                _outcome = GameOutcome.Victory;
                resultGameLabel.Text = "VICTORY";
                SetSoldierEmotion(0);

                _soundManager.PlayVictoryGame();
            }

            colorTransfusionTimer.Start();
        }

        private void ResetGameChanges()
        {
            colorTransfusionTimer.Stop();
            _colorInterpolator.Reset();
            _outcome = GameOutcome.None;

            resultGameLabel.Text = "GAME";
            resultGameLabel.ForeColor = Color.FromArgb(89, 23, 61);
            timeLabel.ForeColor = Color.FromArgb(89, 23, 61);
            minesFoundCountLabel.ForeColor = Color.FromArgb(89, 23, 61);
        }

        private void NewGamePictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.NewGameButtonSelect);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseEnter);
            _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnNewGameButton);
        }

        private void NewGamePictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.NewGameButtonUp);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseLeave);
        }

        private void HighScoresPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.HighScoresButtonSelect);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseEnter);
            _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnHighScoresButton);
        }

        private void HighScoresPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.HighScoresButtonUp);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseLeave);
        }

        private void OptionsPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OptionButtonSelect);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseEnter);
            _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnOptionsButton);
        }

        private void OptionsPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OptionButtonUp);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseLeave);
        }

        private void AboutPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.AboutButtonSelect);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseEnter);
            _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnAboutButton);
        }

        private void AboutPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.AboutButtonUp);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseLeave);
        }

        private void ExitPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.ExitButtonSelect);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseEnter);
            _pictureBoxManager.ChangePicture(soldierPictureBox, AliasForPictures.SoldierEmotionOnExitButton);
        }

        private void ExitPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.ExitButtonUp);
            PictureBoxManager.ChangePictureWidth(sender, EventType.MouseLeave);
        }

        private void TitleLabel_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void SoldierPictureBox_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void InformationPanel_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void MinesFoundCountLabel_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void TimeLabel_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void ResultGameLabel_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void PanelForMap_MouseEnter(object sender, EventArgs e)
        {
            SetSoldierEmotion(AliasForPictures.SoldierEmotionOnForm);
        }

        private void NewGamePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.NewGameButtonDown);
            _soundManager.PlayButtonPress();
        }

        private void NewGamePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.NewGameButtonSelect);

            CreateNewGame();
        }

        private void CreateNewGame()
        {
            var (width, height, _) = _controller.GetGameOptions();
            _map.CreateNewMap(width, height);

            ResetGameChanges();

            _controller.CreateNewGame();
        }

        private void ExitPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.ExitButtonDown);
            _soundManager.PlayButtonPress();
            Thread.Sleep(350);
        }

        private void ExitPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.ExitButtonSelect);

            Close();
        }

        private void HighScoresPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.HighScoresButtonDown);
            _soundManager.PlayButtonPress();
        }

        private void HighScoresPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.HighScoresButtonSelect);

            var highScoresForm = new HighScoresForm(_pictureBoxManager, _controller);
            highScoresForm.ShowDialog();
        }

        private void OptionsPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OptionButtonDown);
            _soundManager.PlayButtonPress();
        }

        private void OptionsPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.OptionButtonSelect);

            var optionsForm = new OptionsForm(_pictureBoxManager, _controller);
            optionsForm.ShowDialog();

            CreateNewGame();
        }

        private void AboutPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.AboutButtonDown);
            _soundManager.PlayButtonPress();
        }

        private void AboutPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _pictureBoxManager.ChangePicture(sender, AliasForPictures.AboutButtonSelect);

            var aboutForm = new AboutForm(_pictureBoxManager);
            aboutForm.ShowDialog();
        }

        private void ColorTransfusionTimer_Tick(object sender, EventArgs e)
        {
            if (_outcome == GameOutcome.None)
            {
                colorTransfusionTimer.Stop();
                _colorInterpolator.Reset();

                return;
            }

            if (_outcome == GameOutcome.Defeat)
            {
                resultGameLabel.ForeColor = _colorInterpolator.GetRedColorGradientEffect();
                timeLabel.ForeColor = _colorInterpolator.GetRedColorGradientEffect();
                minesFoundCountLabel.ForeColor = _colorInterpolator.GetRedColorGradientEffect();

                return;
            }

            resultGameLabel.ForeColor = _colorInterpolator.GetTransfusionEffectInAllColors();
            timeLabel.ForeColor = _colorInterpolator.GetTransfusionEffectInAllColors();
            minesFoundCountLabel.ForeColor = _colorInterpolator.GetTransfusionEffectInAllColors();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetGameChanges();
        }
    }
}
