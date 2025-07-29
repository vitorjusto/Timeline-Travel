namespace Shooter.Source.Models.Misc
{
    public class QuickTimer
    {
        public double Time => _timer;
        private double _timer;
        private int _maxTimer;
        private bool _disabled;

        public QuickTimer(int maxTimer)
        {
            _maxTimer = maxTimer;
        }

        public bool Process(double delta)
        {
            if(_disabled)
                return false;

            _timer+= delta * 60;

            if(_timer < _maxTimer)
                return false;

            _timer -= _maxTimer;
            return true;
        }

        public void Reset()
            => _timer = 0;

        public void Stop()
            => _disabled = true;
    }
}