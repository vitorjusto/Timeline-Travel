using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCrusader: IEnemyDummy
    {
        private readonly int _x;
        private readonly float _speed;
        public DCrusader(int x, float speed)
        {
            _x = x;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Crusader.tscn");

            var instance = (Crusader)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            instance.SetSpeed(_speed);

            return instance;
        }
    }
}