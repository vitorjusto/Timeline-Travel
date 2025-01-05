using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCommon : IEnemyDummy
    {
        private int _x;
        private int _speed;
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

            instance.Hp = GameManager.IsSpecialMode?5:1;

            return instance;
        }
    }
}