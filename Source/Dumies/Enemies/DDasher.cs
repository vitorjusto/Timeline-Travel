using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DDasher : IEnemyDummy
    {
        private int _x;
        public DDasher(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Dasher.tscn");

            var instance = (Dasher)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}