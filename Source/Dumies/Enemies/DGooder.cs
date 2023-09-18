using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DGooder : IEnemyDummy
    {
        private int _x;
        private bool _walk;
        public DGooder(int x, bool walk)
        {
            _x = x;
            _walk = walk;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Gooder.tscn");

            var instance = (Gooder)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.Walk = _walk;

            return instance;
        }
    }
}