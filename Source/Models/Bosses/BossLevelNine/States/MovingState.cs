using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class MovingState : IState
    {
        private Node2D _boss;
        private WaveSpeed _ySpeed;

        public MovingState(Node2D boss)
        {
            _boss = boss;
            _ySpeed = new WaveSpeed(-1, 10, _boss.Position.Y);
        }

        public IState NextState()
        {
            return new MovingBackInTimeState(_boss);
        }

        public bool Process(double delta)
        {
            _boss.Position = new Vector2(_boss.Position.X, _ySpeed.Update(delta));

            return false;
        }
    }
}