using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSniper : IEnemyDummy
    {
        private int _x;
        public DSniper(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Sniper.tscn");

            var instance = (Sniper)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}