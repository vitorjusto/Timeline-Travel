using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States
{
    public class MagnectorEntreringState : IState
    {
        private int _speed = 5;
        private QuickTimer _time = new(220);
        private Node2D _node;

        public MagnectorEntreringState(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new MagnectorIdleState(_node);
        }

        public bool Process(double delta)
        {
            _node.Position += new Vector2(x: 0, _speed) * (float)(delta * 60);

            return _time.Process(delta);
        }
    }
}