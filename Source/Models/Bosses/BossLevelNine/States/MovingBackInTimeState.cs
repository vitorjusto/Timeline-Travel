using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class MovingBackInTimeState : IState
    {
        private Node2D _boss;
        private WaveSpeed _ySpeed;
        private int _xspeed = 8;

        public MovingBackInTimeState(Node2D boss)
        {
            _boss = boss;
            _ySpeed = new WaveSpeed(-4, 20, _boss.Position.Y);
            _boss.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("default");
        }

        public IState NextState()
        {
            return new Exploding(_boss);
        }

        public bool Process(double delta)
        {
            _boss.Position = new Vector2(_boss.Position.X + _xspeed, _ySpeed.Update(delta));

            if(_boss.Position.X < 100 || _boss.Position.X > 1300)
                _xspeed *= -1;

            return false;
        }
    }
}