using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnector.States
{
    public class MagnectorIdleState : IState
    {
        private Node2D _node;

        public MagnectorIdleState(Node2D node)
        {
            _node = node;
        }
        public IState NextState()
        {
            return new MagnectorShootingPlayerState(_node);
        }

        public bool Process()
        {
            //TODO: do an idle animation

            return false;
        }
    }
}