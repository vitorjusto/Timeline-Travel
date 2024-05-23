using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpaceScrap: IEnemyDummy
    {
        private float _xSpeed;
        private float _ySpeed;
        private int _xPosition;

        public DSpaceScrap(float xSpeed, float ySpeed, int xPosition)
        {
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _xPosition = xPosition;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/SpaceScrap.tscn");

            var instance = (SpaceScrap)scene.Instantiate();

            instance.XSpeed = _xSpeed;
            instance.YSpeed = _ySpeed;

            instance.Position = new Vector2(_xPosition, -32);

            return instance;
        }
    }
}