using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.LevelSeven.States
{
    public class SpringSeasoningAdpterState : IState
    {
        private ProjectileManager _projectiles;
        private Node2D _node;
        private int _time;

        public SpringSeasoningAdpterState(Node2D node)
        {
            _node = node;
            _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 20)
                Shoot();

            _time++;
            return false;
        }

        private void Shoot()
        {
            var player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    var angle = Math.Atan2(_node.Position.X - player.Position.X, _node.Position.Y - player.Position.Y);

            _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
			_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));

            _time = 0;
        }
    }
}