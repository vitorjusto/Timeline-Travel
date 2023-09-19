using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DLazer : IEnemyDummy
    {
        private int _x;
        public DLazer(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Lazer.tscn");

            var instance = (Lazer)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}