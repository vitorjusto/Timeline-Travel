using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies.EnemiesPart
{
    public class DLazerPart: IEnemyDummy
    {
        private float _x;
        private float _y;
        public DLazerPart(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/EnemiesPart/LazerPart.tscn");

            var instance = (LazerPart)scene.Instantiate();

            instance.Position = new Vector2(_x, _y);

            return instance;
        }
    }
}