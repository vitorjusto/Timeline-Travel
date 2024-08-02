using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DGooder : IEnemyDummy
    {
        private int _x;
        private bool _walk;
        private int _maxTimer;

        public DGooder(int x, bool walk, int maxTimer = 900)
        {
            _x = x;
            _walk = walk;
            _maxTimer = maxTimer;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Gooder.tscn");

            var instance = (Gooder)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.Walk = _walk;
            instance.MaxTimer = _maxTimer;
            return instance;
        }
    }
}