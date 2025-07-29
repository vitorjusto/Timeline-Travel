using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class EnteringState : IState
    {
        private Node2D _node;

        public EnteringState(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new ShootingBlackholeState(_node);
        }

        public bool Process(double delta)
        {
            _node.Position += new Vector2(0, 5) * (float)(delta * 60);

            return _node.Position.Y > 130;
        }
    }
}