using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

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
            var instance = LoaderManager.GetEnemy<GigantBomb>("FinalBoss/GigantBomb");

            instance.Position = _position;
            instance.XSpeed = _xSpeed;

            return instance;
        
        }
        
    }
}