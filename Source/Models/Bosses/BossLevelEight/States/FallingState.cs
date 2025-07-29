using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class FallingState : IState
    {
        private Node2D _node;
        private QuickTimer _timer = new(65);
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
                FallingAnimation(delta);
            else
                return EndingFall(delta);

            return false;
        }

        private bool EndingFall(double delta)
        {
            _node.Position += new Vector2(0, _ySpeed) * (float)(delta * 60);

            return _node.Position.Y > 1200;
        }

        private void FallingAnimation(double delta)
        {
            if(_ySpeed > -2)
                _ySpeed-= 2;
            
            if(_timer.Process(delta))
            {
                _ySpeed = 20;
                _timesFells++;
            }

            _node.Position += new Vector2(0, _ySpeed) * (float)(delta * 60);
        }
    }
}