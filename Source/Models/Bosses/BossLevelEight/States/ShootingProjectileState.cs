using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class ShootingProjectileState : IState
    {
        private Node2D _node;
        private IState _blackholeState;
        private ProjectileManager _projectiles;
        private Player _player;
        private int _timer;

        public ShootingProjectileState(Node2D node, IState blackholeState)
        {
            _node = node;
            _blackholeState = blackholeState;
            _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            if(_blackholeState is FallingState)
                return null;

            _blackholeState = new FallingState(_node);
            return this;
        }

        public bool Process()
        {
            if(_blackholeState.Process())
                return true;

            _timer++;

            if(_timer < 50)
                return false;
            
		    var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);

            _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-2), (float)Math.Cos(angle) * (-2)));
		    _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.3) * (-2), (float)Math.Cos(angle - 0.3) * (-2)));
		    _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.3) * (-2), (float)Math.Cos(angle + 0.3) * (-2)));
		    _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.6) * (-2), (float)Math.Cos(angle + 0.6) * (-2)));
		    _projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.6) * (-2), (float)Math.Cos(angle - 0.6) * (-2)));

            _timer = 0;

            return false;
        }
    }
}