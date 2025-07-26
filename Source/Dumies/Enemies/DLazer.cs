using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DLazer : IEnemyDummy
    {
        private readonly int _x;
        private readonly int _maxTimer;

        public DLazer(int x, int maxTimer)
        {
            _x = x;
            _maxTimer = maxTimer;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Lazer.tscn");

            var instance = (Lazer)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.MaxTime = _maxTimer;

            return instance;
        }
    }
}