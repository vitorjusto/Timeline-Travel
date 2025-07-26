using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DLighting : IEnemyDummy
    {
        private readonly int _x;
        public DLighting(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Lighting.tscn");

            var instance = (Lighting)scene.Instantiate();

            instance.Position = new Vector2(_x, y: 150);

            return instance;
        }
    }
}