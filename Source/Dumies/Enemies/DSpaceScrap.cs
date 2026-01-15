using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpaceScrap: IEnemyDummy
    {
        private readonly float _xSpeed;
        private readonly float _ySpeed;
        private readonly int _xPosition;
        public ESpaceScrapType SpaceScrapType;

		public DSpaceScrap(float xSpeed, float ySpeed, int xPosition, ESpaceScrapType spaceScrapType)
        {
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _xPosition = xPosition;
            SpaceScrapType = spaceScrapType;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<SpaceScrap>("SpaceScrap");

            instance.XSpeed = _xSpeed;
            instance.YSpeed = _ySpeed;

            instance.Position = new Vector2(_xPosition, -32);

            instance.UpdateType(SpaceScrapType);

            return instance;
        }
    }
}