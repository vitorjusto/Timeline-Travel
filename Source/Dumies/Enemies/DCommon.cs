using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCommon : IEnemyDummy
    {
        private readonly int _x;
        private readonly int _speed;
        public DCommon(int x, int speed)
        {
            _x = x;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Common.tscn");

            var instance = (Common)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.Speed = _speed;

            instance.Hp = GameManager.IsSpecialMode?10:1;

            return instance;
        }
    }
}