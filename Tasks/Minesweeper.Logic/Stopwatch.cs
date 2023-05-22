using System;
using System.Threading;

namespace Academits.Karetskas.Minesweeper.Logic
{
    public sealed class Stopwatch
    {
        private Timer? _timer;

        public TimeSpan TimeCounter { get; private set; }

        public event Action<TimeSpan>? TimeUpdate;

        public Stopwatch()
        {
            _timer = null;
            TimeCounter = TimeSpan.Zero;
        }

        public void Start()
        {
            const int hundredMilliseconds = 100;

            _timer = new Timer(_ =>
            {
                TimeUpdate?.Invoke(TimeCounter);

                TimeCounter += TimeSpan.FromMilliseconds(100);
            }, null, 0, hundredMilliseconds);
        }

        public void Stop()
        {
            if (_timer is null)
            {
                return;
            }

            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            TimeUpdate?.Invoke(TimeCounter);
        }

        public void Reset()
        {
            TimeCounter = TimeSpan.Zero;

            TimeUpdate?.Invoke(TimeCounter);
        }
    }
}
