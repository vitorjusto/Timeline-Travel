using System;
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
        private AnimatedSprite2D _sprite;

        public ConceptMovingState(Node2D node)
        {
            _node = node;
            _ySpeed = new WaveSpeed(-2, 10, _node.Position.Y);
            _sprite = _node.GetNode<AnimatedSprite2D>("HeadSprite");
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            MoveEnemy();
            
            _sprite.Scale = new Vector2(Math.Abs(_sprite.Scale.X) * (_speed > 0? -1: 1), _sprite.Scale.Y);

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