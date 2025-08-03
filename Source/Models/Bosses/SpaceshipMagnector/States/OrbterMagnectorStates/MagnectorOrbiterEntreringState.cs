using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.OrbterMagnectorStates
{
    public class MagnectorOrbterEntreringState : IState
    {
        private MacnectOrbiter _node;
        private Player _player;
        private float _time;
        private float _ytime = 3.333f;
        private int _xspeedModifier = 1;
        private int _yspeedModifier = 1;
        private float _playerDistance = 2000;

        public MagnectorOrbterEntreringState(MacnectOrbiter node)
        {
            _node = node;
            _player = node.GetTree().Root.GetNode<Player>("/root/Main/Player");

            if(_node.SpawnPosition == EDirection.Up)
		    {
                _xspeedModifier = -1;
			    _yspeedModifier = -1;
		    	_node.Position = new Vector2(x: _player.Position.X, y: _player.Position.Y - _playerDistance);
		    }else if(_node.SpawnPosition == EDirection.Left)
		    {
                _yspeedModifier = -1;
				_ytime = 0;
				_time = 3.3f;
		    	_node.Position = new Vector2(x: _player.Position.X - _playerDistance, y: _player.Position.Y);

		    }else if(_node.SpawnPosition == EDirection.Right)
		    {
                _xspeedModifier = -1;
				_ytime = 0;
				_time = 3.3f;
		    	_node.Position = new Vector2(x: _player.Position.X + _playerDistance, y: _player.Position.Y);
		    }else if(_node.SpawnPosition == EDirection.Down)
		    {
		    	_node.Position = new Vector2(x: _player.Position.X, y: _player.Position.Y + _playerDistance);
		    }
        }

        public IState NextState()
        {
            return new MagnectorOrbiterRotatingState(_node, _time, _ytime, _xspeedModifier, _yspeedModifier);
        }

        public bool Process(double delta)
        {
			_playerDistance -= _node.Speed * (float)(delta * 60);

            if(_node.SpawnPosition == EDirection.Up)
			{

				_node.Position = new Vector2(x: _player.Position.X, y: _player.Position.Y - _playerDistance);
				
				if(_node.Position.Y > _player.Position.Y - 150)
                    return true;

			}else if(_node.SpawnPosition == EDirection.Down)
			{
				_node.Position = new Vector2(x: _player.Position.X, y: _player.Position.Y + _playerDistance);
				
				if(_node.Position.Y - _player.Position.Y < 150)
                    return true;

			}else if(_node.SpawnPosition == EDirection.Left)
			{
				_node.Position = new Vector2(x: _player.Position.X - _playerDistance, y: _player.Position.Y);
				
				if(_node.Position.X > _player.Position.X - 150)
                    return true;

			}else if(_node.SpawnPosition == EDirection.Right)
			{
				_node.Position = new Vector2(x: _player.Position.X + _playerDistance, y: _player.Position.Y);
				
				if(_node.Position.X - _player.Position.X < 150)
				    return true;
			}


            return false;
        }
    }
}