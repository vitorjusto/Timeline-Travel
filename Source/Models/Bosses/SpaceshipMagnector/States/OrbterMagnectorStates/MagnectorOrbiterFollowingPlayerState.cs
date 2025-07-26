using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.OrbterMagnectorStates
{
    public class MagnectorOrbiterFollowingPlayerState : IState
    {
        private MacnectOrbiter _node;
        private Player _player;
        private int _time = 0;
        public float XSpeed = 0;
        public float YSpeed = 0;
        private ProjectileManager _projectiles;

        public MagnectorOrbiterFollowingPlayerState(MacnectOrbiter node)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");

		    var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);

            XSpeed = (float)Math.Sin(angle) * (10);
            YSpeed = (float)Math.Cos(angle) * (10);

            _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
        }

        public IState NextState()
        {
            throw new System.NotImplementedException();
        }

        public bool Process(double delta)
        {
            _node.Position = new Vector2(_node.Position.X + XSpeed, _node.Position.Y + YSpeed);

            if(_node.NotifiersOffScreen > 0 && _node.OnWall)
            {
                YSpeed = 0;
                XSpeed = 0;
            }

            _time++;

            if(_time == 150)
            {
                Shoot();
            }

            if(_time == 280)
                _player.ShowTarget();

            if(_time == 300)
            {
                var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);

                XSpeed = (float)Math.Sin(angle) * (-10);
                YSpeed = (float)Math.Cos(angle) * (-10);
                _player.HideTarget();
                _node.OnWall = false;
                _time = 0;
            }

            return false;
        }

        private void Shoot()
        {
            var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);
		    
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
        }
    }
}