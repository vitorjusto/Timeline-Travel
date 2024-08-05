using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DBlackHole : IEnemyDummy
    {
        private int _x;
        private int _y;
        private bool _isWhiteHole;
        private int _speed;

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
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Blackhole.tscn");

            var instance = (Blackhole)scene.Instantiate();

            instance.Position = new Vector2(_x, _y);
            instance.Speed = _speed;

            instance.SetBlackholeType(_isWhiteHole);
            
            return instance;
        }
    }
}