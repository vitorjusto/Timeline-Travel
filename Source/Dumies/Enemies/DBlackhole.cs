using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DBlackHole : IEnemyDummy
    {
        private int _x;
        private bool _isWhiteHole;

        public DBlackHole(int x, bool isWhiteHole)
        {
            _x = x;
            _isWhiteHole = isWhiteHole;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Blackhole.tscn");

            var instance = (Blackhole)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.SetBlackholeType(_isWhiteHole);
            
            return instance;
        }
    }
}