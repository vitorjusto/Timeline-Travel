using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States
{
    public class MagnectorIdleState : IState
    {
        private Node2D _node;
        private WaveSpeed _speed;
        public MagnectorIdleState(Node2D node)
        {
            _node = node;
            _speed = new WaveSpeed(-1, 7, _node.Position.Y);
        }
        public IState NextState()
        {
            return new MagnectorShootingPlayerState(_node, this);
        }

        public bool Process()
        {
            _node.Position = new Vector2(_node.Position.X, _speed.Update());

            return false;
        }
    }
}