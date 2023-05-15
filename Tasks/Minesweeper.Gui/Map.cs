using System;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Gui.PictureManagement;
using Academits.Karetskas.Minesweeper.Logic.Minefield;

namespace Academits.Karetskas.Minesweeper.Gui
{
    public sealed class Map
    {
        private readonly TableLayoutPanel _mapPanel;
        private readonly PictureBoxManager _pictureBoxManager;
        private readonly int _maxFieldSize;

        private int _width;
        private int _height;

        private (bool isSelected, AliasForPictures aliasForPictures)[,] _aliasesMap;

        public event Action<int, int>? CellLeftMouseClick;
        public event Action<int, int>? CellRightMouseClick;
        public event Action<int, int>? CellMiddleMouseClick;
        public event Action<AliasForPictures>? MouseCursorEnterCell;
        public event Action<AliasForPictures>? MouseChangeCell;

        private int Width
        {
            get => _width;

            set
            {
                CheckSize(value);

                _width = value;
            }
        }

        private int Height
        {
            get => _height;

            set
            {
                CheckSize(value);

                _height = value;
            }
        }

        public Map(int width, int height, int maxFieldSize, TableLayoutPanel mapPanel, PictureBoxManager pictureBoxManager)
        {
            CheckObject(mapPanel);
            CheckObject(pictureBoxManager);

            _mapPanel = mapPanel;
            _pictureBoxManager = pictureBoxManager;
            _maxFieldSize = maxFieldSize;

            _aliasesMap = new (bool isSelected, AliasForPictures aliasForPictures)[0, 0];

            CreateMap();
            CreateNewMap(width, height);
        }

        private static void CheckObject(object? obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }
        }

        private static void CheckSize(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    $@"The argument {nameof(value)} = {value} and it is less than 0.");
            }
        }

        private void CreateMap()
        {
            _aliasesMap = new (bool, AliasForPictures)[_maxFieldSize, _maxFieldSize];

            _mapPanel.Visible = false;
            _mapPanel.SuspendLayout();

            _mapPanel.ColumnCount = _maxFieldSize;
            _mapPanel.RowCount = _maxFieldSize;

            for (var i = 0; i < _maxFieldSize; i++)
            {
                for (var j = 0; j < _maxFieldSize; j++)
                {
                    _mapPanel.Controls.Add(CreatePictureBox(20), i, j);
                    _mapPanel.GetControlFromPosition(i, j).Margin = new Padding(0);

                    _aliasesMap[j, i] = (false, AliasForPictures.CellFullDown);
                }
            }

            _mapPanel.ResumeLayout();
        }

        public void CreateNewMap(int width, int height)
        {
            if (Width == width && Height == height)
            {
                ClearMap();

                return;
            }

            Width = width;
            Height = height;

            var panel = _mapPanel.Parent as Panel;
            CheckObject(panel);

            _mapPanel.Visible = false;
            _mapPanel.SuspendLayout();

            var minCellSize = Math.Min(panel!.Size.Width / width, panel.Size.Height / height);

            var maxWidthMapPanel = width * minCellSize;
            var maxHeightMapPanel = height * minCellSize;

            var mapPanelLocation = _mapPanel.Location;
            mapPanelLocation.X = (panel.Size.Width - maxWidthMapPanel) / 2;
            mapPanelLocation.Y = (panel.Size.Height - maxHeightMapPanel) / 2;
            _mapPanel.Location = mapPanelLocation;

            for (var i = 0; i < _maxFieldSize; i++)
            {
                for (var j = 0; j < _maxFieldSize; j++)
                {
                    var pictureBox = (PictureBox)_mapPanel.GetControlFromPosition(i, j);

                    if (i >= width || j >= height)
                    {
                        pictureBox.Visible = false;
                    }
                    else
                    {
                        pictureBox.Image = _pictureBoxManager.GetBitmap(AliasForPictures.CellFullDown);
                        pictureBox.Width = minCellSize;
                        pictureBox.Height = minCellSize;
                        pictureBox.Visible = true;
                    }

                    _aliasesMap[j, i] = (false, AliasForPictures.CellFullDown);
                }
            }

            _mapPanel.ResumeLayout();
            _mapPanel.Visible = true;
        }

        private PictureBox CreatePictureBox(int size)
        {
            var pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = _pictureBoxManager.GetBitmap(AliasForPictures.CellFullDown),
                Width = size,
                Height = size
            };

            pictureBox.MouseEnter += CellPictureBox_MouseEnter!;
            pictureBox.MouseLeave += CellPictureBox_MouseLeave!;
            pictureBox.MouseUp += CellPictureBox_MouseClick!;

            return pictureBox;
        }

        private void CellPictureBox_MouseEnter(object sender, EventArgs e)
        {
            var cellPosition = _mapPanel.GetCellPosition((PictureBox)sender);

            MouseCursorEnterCell?.Invoke(_aliasesMap[cellPosition.Row, cellPosition.Column].aliasForPictures);

            _aliasesMap[cellPosition.Row, cellPosition.Column].aliasForPictures += 1;
            _aliasesMap[cellPosition.Row, cellPosition.Column].isSelected = true;
            _pictureBoxManager.ChangePicture(sender, _aliasesMap[cellPosition.Row, cellPosition.Column].aliasForPictures);
        }

        private void CellPictureBox_MouseLeave(object sender, EventArgs e)
        {
            var cellPosition = _mapPanel.GetCellPosition((PictureBox)sender);

            _aliasesMap[cellPosition.Row, cellPosition.Column].aliasForPictures -= 1;
            _aliasesMap[cellPosition.Row, cellPosition.Column].isSelected = false;
            _pictureBoxManager.ChangePicture(sender, _aliasesMap[cellPosition.Row, cellPosition.Column].aliasForPictures);
        }

        private void CellPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var cellPosition = _mapPanel.GetCellPosition((PictureBox)sender);

            if (e.Button == MouseButtons.Left)
            {
                CellLeftMouseClick?.Invoke(cellPosition.Row, cellPosition.Column);
            }
            else if (e.Button == MouseButtons.Right)
            {
                CellRightMouseClick?.Invoke(cellPosition.Row, cellPosition.Column);
            }
            else
            {
                CellMiddleMouseClick?.Invoke(cellPosition.Row, cellPosition.Column);
            }
        }

        private void ClearMap()
        {
            for (var i = 0; i < _aliasesMap.GetLength(0); i++)
            {
                for (var j = 0; j < _aliasesMap.GetLength(1); j++)
                {
                    _aliasesMap[i, j] = (false, AliasForPictures.CellFullDown);

                    _pictureBoxManager.ChangePicture(_mapPanel.GetControlFromPosition(j, i), _aliasesMap[i, j].aliasForPictures);
                }
            }
        }

        public void ChangeMap(Cell[,] map)
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var cell = map[j, i];

                    if (cell.Status == Status.Unchecked)
                    {
                        switch (cell.Note)
                        {
                            case Note.Flag:
                                AssignDesiredAlias(i, j, AliasForPictures.CellWithFlagDown);
                                break;
                            case Note.QuestionMark:
                                AssignDesiredAlias(i, j, AliasForPictures.CellWithQuestionDown);
                                break;
                            default:
                                AssignDesiredAlias(i, j, AliasForPictures.CellFullDown);
                                break;
                        }
                    }
                    else
                    {
                        switch (cell.Info)
                        {
                            case Information.Zero:
                                AssignDesiredAlias(i, j, AliasForPictures.CellEmptyDown);
                                break;
                            case Information.One:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber1Down);
                                break;
                            case Information.Two:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber2Down);
                                break;
                            case Information.Three:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber3Down);
                                break;
                            case Information.Four:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber4Down);
                                break;
                            case Information.Five:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber5Down);
                                break;
                            case Information.Six:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber6Down);
                                break;
                            case Information.Seven:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber7Down);
                                break;
                            case Information.Eight:
                                AssignDesiredAlias(i, j, AliasForPictures.CellNumber8Down);
                                break;
                            case Information.Mine:
                                AssignDesiredAlias(i, j, AliasForPictures.CellWithMineDown);
                                break;
                            default:
                                AssignDesiredAlias(i, j, AliasForPictures.CellErrorDown);
                                break;
                        }
                    }

                    _pictureBoxManager.ChangePicture(_mapPanel.GetControlFromPosition(i, j), _aliasesMap[j, i].aliasForPictures);
                }
            }
        }

        private void AssignDesiredAlias(int column, int row, AliasForPictures aliasCell)
        {
            if (_aliasesMap[row, column].aliasForPictures == aliasCell)
            {
                return;
            }

            if (_aliasesMap[row, column].isSelected)
            {
                MouseChangeCell?.Invoke(aliasCell);
                _aliasesMap[row, column].aliasForPictures = aliasCell + 1;

                return;
            }

            _aliasesMap[row, column].aliasForPictures = aliasCell;
        }
    }
}
