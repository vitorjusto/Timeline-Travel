using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.Concept.States
{
    public class ConceptDashingState : IState
    {
        private Player _player;
        private ProjectileManager _projectiles;
        private Node2D _node;

        public ConceptDashingState(Node2D node)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            _ySpeed = new WaveSpeed(-6, 30, _node.Position.Y, reverseDirection: true);
        }

        public EDashStatus _dashStatus = EDashStatus.NotDashing;
        public WaveSpeed _ySpeed;
        private int _xSpeed = 8;

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            Dash();

            return false;
        }

        private void Dash()
        {
		    var xSpeed = 0;
		    float yPosition = 0;

			if(Math.Abs(_node.Position.X - _player.Position.X) < 64 && _dashStatus == EDashStatus.NotDashing)
				_dashStatus = EDashStatus.Dashing;

		    if(_dashStatus == EDashStatus.Dashing)
		    {
		    	yPosition = 16 + _node.Position.Y;

		    	if(_node.Position.Y + 96 >= _node.GetViewport().GetWindow().Size.Y)
		    	{
		    		_projectiles.AddProjectile(new DNormalProjectile(_node.Position.X, _node.Position.Y - 96, 0, -3));
		    		_projectiles.AddProjectile(new DNormalProjectile(_node.Position.X - 96, _node.Position.Y - 96, -3, -3));
		    		_projectiles.AddProjectile(new DNormalProjectile(_node.Position.X + 96, _node.Position.Y - 96, 3, -3));
		    		_projectiles.AddProjectile(new DNormalProjectile(_node.Position.X - 48, _node.Position.Y - 96, -1.5f, -3));
		    		_projectiles.AddProjectile(new DNormalProjectile(_node.Position.X + 48, _node.Position.Y - 96, 1.5f, -3));
		    		_dashStatus = EDashStatus.GoingToOriginalPosition;
		    	}
		    }
		    else if(_dashStatus == EDashStatus.GoingToOriginalPosition)
		    {
		    	yPosition = -16 + _node.Position.Y;

		    	if(yPosition <=160)
		    	{
		    		_dashStatus = EDashStatus.NotDashing;
		    		_ySpeed = new WaveSpeed(-6, 30, _node.Position.Y, reverseDirection: true);
		    		yPosition = _ySpeed.Update();
		    	}
		    }
		    else if(_node.Position.X < _player.Position.X)
		    {
		    	xSpeed = _xSpeed;
		    	yPosition = _ySpeed.Update();
		    }
		    else if(_node.Position.X > _player.Position.X)
		    {
		    	xSpeed = _xSpeed * -1;
		    	yPosition = _ySpeed.Update();
		    }

		    _node.Position = new Vector2(x: _node.Position.X + xSpeed, y: yPosition);
        }
    }
}