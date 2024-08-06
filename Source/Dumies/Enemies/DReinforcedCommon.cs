using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DReinforcedCommon : IEnemyDummy
    {
        private int _x;
        private int _speed;
        public DReinforcedCommon(int x, int speed)
        {
            _x = x;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/ReinforcedCommon.tscn");

            var instance = (ReinforcedCommon)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.Speed = _speed;

            return instance;
        }
    }
}