using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academits.Karetskas.Minesweeper.Logic.Minefield;
using Minesweeper.Gui.PictureManagement;

namespace Minesweeper.Gui
{
    public sealed class Map
    {
        private int _width;
        private int _height;
        private (bool isSelected, AliasForPictures aliasForPictures)[,] _aliasesMap;

        private readonly TableLayoutPanel _mapPanel;
        private readonly PictureBoxManager _pictureBoxManager;

        public event Action<int, int>? CellLeftMouseClick;
        public event Action<int, int>? CellRightMouseClick;
        public event Action<int, int>? CellMiddleMouseClick;
        public event Action<AliasForPictures>? MouseCursorEnterCell;
        public event Action<AliasForPictures>? MouseChangeCell;

        public int Width
        {
            get => _width;

            private set
            {
                CheckSize(value);

                _width = value;
            }
        }

        public int Height
        {
            get => _height;

            private set
            {
                CheckSize(value);

                _height = value;
            }
        }

        public Map(int width, int height, TableLayoutPanel mapPanel, PictureBoxManager pictureBoxManager)
        {
            CheckObject(mapPanel);
            CheckObject(pictureBoxManager);

            _mapPanel = mapPanel;
            _pictureBoxManager = pictureBoxManager;

            _aliasesMap = new (bool isSelected, AliasForPictures aliasForPictures)[0, 0];

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

        public void CreateNewMap(int width, int height)
        {
            if (Width == width && Height == height)
            {
                ClearMap();

                return;
            }

            Width = width;
            Height = height;
            _aliasesMap = new(bool, AliasForPictures)[height, width];

            var panel = _mapPanel.Parent as Panel;
            CheckObject(panel);
            panel!.Visible = false;

            _mapPanel.SuspendLayout();

            _mapPanel.Controls.Clear();

            _mapPanel.ColumnCount = width;
            _mapPanel.RowCount = height;

            var minCellSize = Math.Min(panel!.Size.Width / width, panel.Size.Height / height);
            
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    _mapPanel.Controls.Add(CreatePictureBox(minCellSize, minCellSize), i, j);
                    _mapPanel.GetControlFromPosition(i, j).Margin = new Padding(0);

                    _aliasesMap[j, i] = (false, AliasForPictures.CellFullDown);
                }
            }
            
            var maxWidthMapPanel = width * minCellSize;
            var maxHeightMapPanel = height * minCellSize;

            var mapPanelSize = _mapPanel.Size;
            mapPanelSize.Width = maxWidthMapPanel;
            mapPanelSize.Height = maxHeightMapPanel;
            _mapPanel.Size = mapPanelSize;

            var mapPanelLocation = _mapPanel.Location;
            mapPanelLocation.X = (panel.Size.Width - maxWidthMapPanel) / 2;
            mapPanelLocation.Y = (panel.Size.Height - maxHeightMapPanel) / 2;
            _mapPanel.Location = mapPanelLocation;

            _mapPanel.ResumeLayout();

            panel.Visible = true;
        }

        private PictureBox CreatePictureBox(int width, int height)
        {
            var pictureBox = new PictureBox();
            pictureBox.BackColor = Color.Transparent;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = _pictureBoxManager.GetBitmap(AliasForPictures.CellFullDown);
            pictureBox.Width = width;
            pictureBox.Height = height;

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

        public void ClearMap()
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
