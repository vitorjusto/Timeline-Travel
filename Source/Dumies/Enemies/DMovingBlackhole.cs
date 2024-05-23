using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DMovingBlackhole : IEnemyDummy
    {
        private int _x;
        private int _y;

        public DMovingBlackhole(int x, int y)
        {
            _x = x;
            _y = y;
        }
         
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelEight/MovingBlackHole.tscn");

            var instance = (MovingBlackHole)scene.Instantiate();

            instance.Position = new Vector2(_x, _y);

            return instance;
        }
    }
}