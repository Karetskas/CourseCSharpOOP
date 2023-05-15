using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Academits.Karetskas.Minesweeper.Gui.PictureManagement
{
    public sealed class PictureBoxManager
    {
        private readonly Dictionary<AliasForPictures, Bitmap> _pictures;

        public PictureBoxManager()
        {
            try
            {
                _pictures = new Dictionary<AliasForPictures, Bitmap>
                {
                    {AliasForPictures.SoldierEmotionOnForm, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForForm.png"))},
                    {AliasForPictures.SoldierEmotionOnNewGameButton, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForNewGame.png"))},
                    {AliasForPictures.SoldierEmotionOnHighScoresButton, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForHighScores.png"))},
                    {AliasForPictures.SoldierEmotionOnOptionsButton, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForOptions.png"))},
                    {AliasForPictures.SoldierEmotionOnAboutButton, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForAbout.png"))},
                    {AliasForPictures.SoldierEmotionOnExitButton, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForExit.png"))},
                    {AliasForPictures.SoldierEmotionOnFullCell, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForFullCell.png"))},
                    {AliasForPictures.SoldierEmotionOnEmptyCell, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForEmptyCell.png"))},
                    {AliasForPictures.SoldierEmotionOnCellWithFlag, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForFlag.png"))},
                    {AliasForPictures.SoldierEmotionOnCellWithQuestion, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForQuestion.png"))},
                    {AliasForPictures.SoldierEmotionWhenDefeat, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForDefeat.png"))},
                    {AliasForPictures.SoldierEmotionWhenVictory, new Bitmap(Image.FromFile( @"Pictures\SoldierEmotions\SoldierForVictory.png"))},

                    {AliasForPictures.NewGameButtonDown, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Down\NewGame.png"))},
                    {AliasForPictures.NewGameButtonUp, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Up\NewGame.png"))},
                    {AliasForPictures.NewGameButtonSelect, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Select\NewGame.png"))},

                    {AliasForPictures.HighScoresButtonDown, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Down\HighScores.png"))},
                    {AliasForPictures.HighScoresButtonUp, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Up\HighScores.png"))},
                    {AliasForPictures.HighScoresButtonSelect, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Select\HighScores.png"))},

                    {AliasForPictures.OptionButtonDown, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Down\Options.png"))},
                    {AliasForPictures.OptionButtonUp, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Up\Options.png"))},
                    {AliasForPictures.OptionButtonSelect, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Select\Options.png"))},

                    {AliasForPictures.AboutButtonDown, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Down\About.png"))},
                    {AliasForPictures.AboutButtonUp, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Up\About.png"))},
                    {AliasForPictures.AboutButtonSelect, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Select\About.png"))},

                    {AliasForPictures.ExitButtonDown, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Down\Exit.png"))},
                    {AliasForPictures.ExitButtonUp, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Up\Exit.png"))},
                    {AliasForPictures.ExitButtonSelect, new Bitmap(Image.FromFile( @"Pictures\Buttons\MenuButtons\Select\Exit.png"))},

                    {AliasForPictures.CellEmptyDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\EmptyCell.png"))},
                    {AliasForPictures.CellEmptySelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\EmptyCell.png"))},

                    {AliasForPictures.CellFullDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\FullCell.png"))},
                    {AliasForPictures.CellFullSelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\FullCell.png"))},

                    {AliasForPictures.CellWithFlagDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\Flag.png"))},
                    {AliasForPictures.CellWithFlagSelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\Flag.png"))},

                    {AliasForPictures.CellWithQuestionDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\Question.png"))},
                    {AliasForPictures.CellWithQuestionSelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\Question.png"))},

                    {AliasForPictures.CellNumber1Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\1.png"))},
                    {AliasForPictures.CellNumber1Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\1.png"))},

                    {AliasForPictures.CellNumber2Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\2.png"))},
                    {AliasForPictures.CellNumber2Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\2.png"))},

                    {AliasForPictures.CellNumber3Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\3.png"))},
                    {AliasForPictures.CellNumber3Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\3.png"))},

                    {AliasForPictures.CellNumber4Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\4.png"))},
                    {AliasForPictures.CellNumber4Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\4.png"))},

                    {AliasForPictures.CellNumber5Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\5.png"))},
                    {AliasForPictures.CellNumber5Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\5.png"))},

                    {AliasForPictures.CellNumber6Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\6.png"))},
                    {AliasForPictures.CellNumber6Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\6.png"))},

                    {AliasForPictures.CellNumber7Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\7.png"))},
                    {AliasForPictures.CellNumber7Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\7.png"))},

                    {AliasForPictures.CellNumber8Down, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\8.png"))},
                    {AliasForPictures.CellNumber8Select, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\8.png"))},

                    {AliasForPictures.CellWithMineDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\Mine.png"))},
                    {AliasForPictures.CellWithMineSelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\Mine.png"))},

                    {AliasForPictures.CellErrorDown, new Bitmap(Image.FromFile( @"Pictures\Cells\Down\MineError.png"))},
                    {AliasForPictures.CellErrorSelect, new Bitmap(Image.FromFile( @"Pictures\Cells\Select\MineError.png"))},

                    { AliasForPictures.LeftButtonDown, new Bitmap(Image.FromFile(@"Pictures\Buttons\LeftButtons\Down.png"))},
                    { AliasForPictures.LeftButtonUp, new Bitmap(Image.FromFile(@"Pictures\Buttons\LeftButtons\Up.png"))},
                    { AliasForPictures.LeftButtonSelect, new Bitmap(Image.FromFile(@"Pictures\Buttons\LeftButtons\Select.png"))},

                    { AliasForPictures.RightButtonDown, new Bitmap(Image.FromFile(@"Pictures\Buttons\RightButtons\Down.png"))},
                    { AliasForPictures.RightButtonUp, new Bitmap(Image.FromFile(@"Pictures\Buttons\RightButtons\Up.png"))},
                    { AliasForPictures.RightButtonSelect, new Bitmap(Image.FromFile(@"Pictures\Buttons\RightButtons\Select.png"))},

                    { AliasForPictures.OkButtonDown, new Bitmap(Image.FromFile(@"Pictures\Buttons\OkButtons\Down.png"))},
                    { AliasForPictures.OkButtonUp, new Bitmap(Image.FromFile(@"Pictures\Buttons\OkButtons\Up.png"))},
                    { AliasForPictures.OkButtonSelect, new Bitmap(Image.FromFile(@"Pictures\Buttons\OkButtons\Select.png"))},

                    { AliasForPictures.CancelButtonDown, new Bitmap(Image.FromFile(@"Pictures\Buttons\CancelButtons\Down.png"))},
                    { AliasForPictures.CancelButtonUp, new Bitmap(Image.FromFile(@"Pictures\Buttons\CancelButtons\Up.png"))},
                    { AliasForPictures.CancelButtonSelect, new Bitmap(Image.FromFile(@"Pictures\Buttons\CancelButtons\Select.png"))}
                };
            }
            catch (Exception e)
            {
                throw new ArgumentException("Failed to load pictures.", e);
            }
        }

        public Bitmap GetBitmap(AliasForPictures aliasForPictures)
        {
            return (Bitmap)_pictures[aliasForPictures].Clone();
        }

        public void ChangePicture(object picture, AliasForPictures aliasForPictures)
        {
            var pictureBox = GetPictureBox(picture);

            pictureBox.Image.Dispose();
            pictureBox.Image = (Bitmap)_pictures[aliasForPictures].Clone();
        }

        public static void ChangePictureWidth(object sender, EventType eventType)
        {
            var pictureBox = GetPictureBox(sender);

            var sizePicture = pictureBox.Size;

            if (eventType == EventType.MouseEnter)
            {
                sizePicture.Width += 5;
            }
            else if (eventType == EventType.MouseLeave)
            {
                sizePicture.Width -= 5;
            }

            pictureBox.Size = sizePicture;
        }

        private static PictureBox GetPictureBox(object obj)
        {
            if (obj is not PictureBox pictureBox)
            {
                throw new ArgumentNullException(nameof(obj), $@"The argument {nameof(obj)} is null.");
            }

            return pictureBox;
        }
    }
}
