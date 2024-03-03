
using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.SpaceshipMagnectorStates
{
    public class MagnectorShootingAndAtractingState : IState
    {
        private MagnectorShootingPlayerState _shootingState;
        private SpaceshipMagnector _node;
        private Player _player;
        private int _time;
        private bool _isAtracting;
        public MagnectorShootingAndAtractingState(MagnectorShootingPlayerState shootingState, Node2D node)
        {
            _shootingState = shootingState;
            _node = (SpaceshipMagnector)node;

            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 100)
            {
                _isAtracting = true;
                _node.StartAtracting();
            }else if(_time == 160)
            {
                _isAtracting = false;
                _node.StopAtracting();
                _time = 0;

            }else if(!_isAtracting)
            {
                _shootingState.Process();
            }else
            {
			    var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);
			    _player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );
            }

            _time++;
            return false;
        }
    }
}