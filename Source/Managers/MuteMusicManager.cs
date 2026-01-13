namespace Shooter.Source.Managers
{
    public class MuteMusicManager
    {
        private MuteMusicManager()
        {}

        private static MuteMusicManager _manager;
        private bool _isGameMuted = false;

        public static bool ToggleMute()
        {
            if(_manager is null)
                _manager = new();

            _manager._isGameMuted = !_manager._isGameMuted;
            return _manager._isGameMuted;
        }

        public static bool GetIsGameMute()
        {
            if(_manager is null)
                _manager = new();
                
            return _manager._isGameMuted;
        }
    }
}