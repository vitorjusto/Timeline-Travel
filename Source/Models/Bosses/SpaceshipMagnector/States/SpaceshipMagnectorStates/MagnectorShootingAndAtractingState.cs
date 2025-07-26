
using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.SpaceshipMagnectorStates
{
    public class MagnectorShootingAndAtractingState : IState
    {
        private SpaceshipMagnector _node;
        private Player _player;
        private IState _idleState;
        private int _time;
        private bool _isAtracting;
        public MagnectorShootingAndAtractingState(Node2D node, IState idleState )
        {
            _node = (SpaceshipMagnector)node;

            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");

            _idleState = idleState;

        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            if(_time == 200)
            {
                _isAtracting = true;
                _node.StartAtracting();
            }else if(_time == 260)
            {
                _isAtracting = false;
                _node.StopAtracting();
                _time = 0;

            }else if(_isAtracting)
            {
			    var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);
			    _player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );
            }else
            {
                _idleState.Process(delta);
            }

            _time++;
            return false;
        }
    }
}