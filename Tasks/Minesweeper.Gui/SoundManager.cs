using System.Media;

namespace Academits.Karetskas.Minesweeper.Gui
{
    public sealed class SoundManager
    {
        private readonly SoundPlayer _playButtonPress;
        private readonly SoundPlayer _playVictoryGame;
        private readonly SoundPlayer _playDefeat;
        private readonly SoundPlayer _playMarkCell;
        private readonly SoundPlayer _playCheckCell;

        public SoundManager()
        {
            _playButtonPress = new SoundPlayer(Properties.Resources.ButtonPress);
            _playVictoryGame = new SoundPlayer(Properties.Resources.Victory);
            _playDefeat = new SoundPlayer(Properties.Resources.Defeat);
            _playMarkCell = new SoundPlayer(Properties.Resources.MarkCell);
            _playCheckCell = new SoundPlayer(Properties.Resources.CheckCell);
        }

        public void PlayButtonPress()
        {
            _playButtonPress.Play();
        }

        public void PlayVictoryGame()
        {
            _playVictoryGame.Play();
        }

        public void PlayDefeat()
        {
            _playDefeat.Play();
        }

        public void PlayMarkCell()
        {
            _playMarkCell.Play();
        }

        public void PlayCheckCell()
        {
            _playCheckCell.Play();
        }
    }
}
