using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnector.States
{
    public class MagnectorEntreringState : IState
    {
        private int _speed = 5;
        private int _time = 0;
        private Node2D _node;

        public MagnectorEntreringState(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new MagnectorIdleState(_node);
        }

        public bool Process()
        {
            _node.Position = new Vector2(x: _node.Position.X, _node.Position.Y + _speed);
            _time++;

            return _time > 220;
        }
    }
}