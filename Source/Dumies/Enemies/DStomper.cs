using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DStomper : IEnemyDummy
    {        
        private readonly int _x;
        public DStomper(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Stomper.tscn");

            var instance = (Stomper)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
        
    }
}