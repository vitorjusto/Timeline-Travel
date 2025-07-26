using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class FallingState : IState
    {
        private Node2D _node;
        private int _timer;
        private int _ySpeed;
        private int _timesFells;

        public FallingState(Node2D node)
        {
            _node = node;
            _ySpeed = 20;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            if(_timesFells < 2)
                FallingAnimation();
            else
                return EndingFall();

            return false;
        }

        private bool EndingFall()
        {
            _node.Position += new Vector2(0, _ySpeed);

            return _node.Position.Y > 1200;
        }

        private void FallingAnimation()
        {
            _timer++;

            if(_ySpeed > -2)
                _ySpeed-= 2;
            
            if(_timer == 65)
            {
                _timer = 0;
                _ySpeed = 20;
                _timesFells++;
            }

            _node.Position += new Vector2(0, _ySpeed);
        }
    }
}