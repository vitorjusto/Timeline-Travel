using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies.FinalBoss
{
    public class DGigantBomb: IEnemyDummy
    {
        private Vector2 _position;
        private float _xSpeed;

        public DGigantBomb(Vector2 position, float xSpeed)
        {
            _position = position;
            _xSpeed = xSpeed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/GigantBomb.tscn");

            var instance = (GigantBomb)scene.Instantiate();

            instance.Position = _position;
            instance.XSpeed = _xSpeed;

            return instance;
        
        }
        
    }
}