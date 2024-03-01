using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnector.States
{
    public class MagnectorShootingPlayerState : IState
    {
        private Node2D _node;
        private float _xspeed;
        private float _yspeed;
        private int _speed = 5;
        private int _time = 0;
        public MagnectorShootingPlayerState(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {

            if(_time == 40)
            {
                ShootProjectile();
                _time = 0;
            }
            
            _node.Position = new Vector2(_node.Position.X + _xspeed, _node.Position.Y + _yspeed);
            _time++;
            
            return false;
        }

        private void ShootProjectile()
        {
            var player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    var angle = Math.Atan2(_node.Position.X - player.Position.X, _node.Position.Y - player.Position.Y);
		    var projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
        }

        private void FollowPlayer()
	    {
		    var player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    var angle = Math.Atan2(_node.Position.X - player.Position.X, _node.Position.Y - player.Position.Y);
			
		    _xspeed = (float)Math.Sin(angle) * (-_speed);
		    _yspeed = (float)Math.Cos(angle) * (-_speed);
	    }
    }
}