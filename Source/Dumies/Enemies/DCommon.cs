using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCommon : IEnemyDummy
    {
        private int _x;
        public DCommon(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Common.tscn");

            var instance = (Common)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}