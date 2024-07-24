using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteShootingState : IState
    {
        private LightningRodSatellite _node;
        private ProjectileManager _projectileManager;
        private Player _player;
        private int _time = 0;
        private int _homingProjectileCowldown = 100;
        private WaveSpeed _ySpeed;

        public LightningRodSatelliteShootingState(LightningRodSatellite node)
        {
            _node = node;
            _projectileManager = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
            _node.StartShooting();

            _ySpeed = new WaveSpeed(-1, 2, _node.Position.Y);

        }

        public IState NextState()
        {
            return new LightningRodSatelliteMovingAroundState(this, _node);
        }

        public bool Process()
        {
            PunishPlayer();

            _node.Position = new Vector2(x: _node.Position.X, y: _ySpeed.Update());

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

            _projectileManager.AddProjectile(new DHomingProjectile(_node.Position.X, _node.Position.Y -175, 5));

            _homingProjectileCowldown = 100;
        }
    }
}