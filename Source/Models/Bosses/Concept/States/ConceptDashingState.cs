using System;
using System.Collections.Generic;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelEight.States;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.Concept.States
{
    public class ConceptDashingState : IState
    {
        private Player _player;
        private ProjectileManager _projectiles;
        private Node2D _node;
        private List<RegularShootPoint> _shootingPoints;

        public ConceptDashingState(Node2D node)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            _ySpeed = new WaveSpeed(-6, 30, _node.Position.Y, reverseDirection: true);

			_sprite = _node.GetNode<AnimatedSprite2D>("HeadSprite");

			
            _shootingPoints = new List<RegularShootPoint>();

            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint"));
            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint2"));
            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint3"));
            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint4"));
            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint5"));
            _shootingPoints.Add(_node.GetNode<RegularShootPoint>("RegularShootPoint6"));
        }

        public EDashStatus _dashStatus = EDashStatus.NotDashing;
        public WaveSpeed _ySpeed;
        private AnimatedSprite2D _sprite;
        private int _xSpeed = 8;

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            Dash();

			AnimateHead();

            return false;
        }

        private void AnimateHead()
        {
            if(_node.Position.X > _player.Position.X)
				_sprite.Scale = new Vector2(Math.Abs(_sprite.Scale.X), _sprite.Scale.Y);
			else
				_sprite.Scale = new Vector2(Math.Abs(_sprite.Scale.X) * -1, _sprite.Scale.Y);
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
                    ShootProjectile();

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

        private void ShootProjectile()
        {
            _shootingPoints[0].Shoot();
            _shootingPoints[1].Shoot();
            _shootingPoints[2].Shoot();
            _shootingPoints[3].Shoot();
            _shootingPoints[4].Shoot();
            _shootingPoints[5].Shoot();
        }
    }
}