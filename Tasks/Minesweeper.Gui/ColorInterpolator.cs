using System.Drawing;

namespace Academits.Karetskas.Minesweeper.Gui
{
    public sealed class ColorInterpolator
    {
        private (int component, int step) _blue = (0, 9);
        private (int component, int step) _green = (0, 12);
        private (int component, int step) _red = (0, 15);

        public Color GetTransfusionEffectInAllColors()
        {
            _blue.component += _blue.step;
            _green.component += _green.step;
            _red.component += _red.step;

            _blue = ChangeStepDirection(_blue.component, _blue.step);
            _green = ChangeStepDirection(_green.component, _green.step);
            _red = ChangeStepDirection(_red.component, _red.step);

            return Color.FromArgb(_red.component, _green.component, _blue.component);
        }

        private static (int colorComponent, int step) ChangeStepDirection(int colorComponent, int step)
        {
            if (colorComponent > 255)
            {
                step *= -1;
                colorComponent = 255;
            }
            else if (colorComponent < 0)
            {
                step *= -1;
                colorComponent = 0;
            }

            return (colorComponent, step);
        }

        public Color GetRedColorGradientEffect()
        {
            _red.component += _red.step;

            _red = ChangeStepDirection(_red.component, _red.step);

            return Color.FromArgb(_red.component, _green.component, _blue.component);
        }

        public void Reset()
        {
            _blue.component = 0;
            _green.component = 0;
            _red.component = 0;
        }
    }
}
