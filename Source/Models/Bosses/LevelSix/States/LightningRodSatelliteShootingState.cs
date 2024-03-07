using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteShootingState : IState
    {
        private Node2D _node;
        private ProjectileManager _projectileManager;
        private Player _player;
        private int _time = 0;
        private int _homingProjectileCowldown = 100;

        public LightningRodSatelliteShootingState(Node2D node)
        {
            _node = node;
            _projectileManager = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return new LightningRodSatelliteMovingAroundState(this, _node);
        }

        public bool Process()
        {
            if(_time == 20)
                Shoot();
            
            PunishPlayer();

            _time++;
            return false;
        }

        private void PunishPlayer()
        {
            if(Math.Abs(_player.Position.X - _node.Position.X) < 200)
            {
                _homingProjectileCowldown = 200;
                return;
            }
            
            if(_homingProjectileCowldown > 0)
            {
                _homingProjectileCowldown--;
                return;
            }

            _projectileManager.AddProjectile(new DHomingProjectile(_node.Position.X, _node.Position.Y));

            _homingProjectileCowldown = 100;
        }

        private void Shoot()
        {
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X + 120, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X + 160, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X + 200, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X + 240, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X + 280, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X - 120, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X - 160, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X - 200, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X - 240, _node.Position.Y + 100, 0, 3));
            _projectileManager.AddProjectile(new DNormalProjectile(_node.Position.X - 280, _node.Position.Y + 100, 0, 3));

            _time = 0;
        }
    }
}