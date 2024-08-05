using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpaceScrap: IEnemyDummy
    {
        private float _xSpeed;
        private float _ySpeed;
        private int _xPosition;
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
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/SpaceScrap.tscn");

            var instance = (SpaceScrap)scene.Instantiate();

            instance.XSpeed = _xSpeed;
            instance.YSpeed = _ySpeed;

            instance.Position = new Vector2(_xPosition, -32);

            instance.UpdateType(SpaceScrapType);

            return instance;
        }
    }
}