using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.SpaceshipPredador
{
    public class EnteringScreen : IState
    {
        private Node2D _node;
        private QuickTimer _time = new(50);

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
            _node.Position += new Vector2(x: 0, y: 5) * (float)(delta * 60);

            return _time.Process(delta);
        }
    }
}