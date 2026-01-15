using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies.FinalBoss
{
    public class DGigantBomb: IEnemyDummy
    {
        private Vector2 _position;
        private readonly float _xSpeed;

		public DGigantBomb(Vector2 position, float xSpeed)
        {
            _position = position;
            _xSpeed = xSpeed;
        }

        public Node2D GetInstance()
        {
            var instance = (GigantBomb)GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/GigantBomb.tscn").Instantiate();

            instance.Position = _position;
            instance.XSpeed = _xSpeed;

            return instance;
        
        }
        
    }
}