using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DBlackHole : IEnemyDummy
    {
        private readonly int _x;
        private readonly int _y;
        private readonly bool _isWhiteHole;
        private readonly int _speed;

		public DBlackHole(int x, bool isWhiteHole, int speed)
        {
            _x = x;
            _y = -30;
            _isWhiteHole = isWhiteHole;
            _speed = speed;
        }

        public DBlackHole(int x, int y, bool isWhiteHole)
        {
            _x = x;
            _y = y;
            _isWhiteHole = isWhiteHole;
            _speed = 6;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Blackhole>("Blackhole");

            instance.Position = new Vector2(_x, _y);
            instance.Speed = _speed;

            instance.SetBlackholeType(_isWhiteHole);
            
            return instance;
        }
    }
}