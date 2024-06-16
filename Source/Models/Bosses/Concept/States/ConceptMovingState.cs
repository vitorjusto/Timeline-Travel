using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.Concept.States
{
    public class ConceptMovingState : IState
    {
        private Node2D _node;
        private int _speed = -4;
        private WaveSpeed _ySpeed;
        public ConceptMovingState(Node2D node)
        {
            _node = node;
            _ySpeed = new WaveSpeed(-2, 10, _node.Position.Y);
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            MoveEnemy();

            return false;
        }

        private void MoveEnemy()
        {
            _node.Position = new Vector2(x: _node.Position.X + _speed, y: _ySpeed.Update());

		    if(_node.Position.X - 64 <= 0 && _speed < 0)
			    _speed *= -1;
		    else if(_node.Position.X + 64 >= _node.GetViewport().GetWindow().Size.X && _speed > 0)
			    _speed *= -1;
        }
    }
}