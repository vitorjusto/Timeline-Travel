using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipPredador
{
    public class EnteringScreen : IState
    {
        private Node2D _node;
        private int _time = 0;

        public EnteringScreen(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new MovingAround(_node);
        }

        public bool Process(double delta)
        {
            _node.Position = new Vector2(x: _node.Position.X, y: _node.Position.Y + 5);
			_time++;

            return _time == 50;
        }
    }
}