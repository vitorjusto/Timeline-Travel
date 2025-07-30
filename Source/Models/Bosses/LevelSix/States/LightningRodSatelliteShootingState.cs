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
        private float _homingProjectileCowldown = 100;
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

        public bool Process(double delta)
        {
            PunishPlayer(delta);

            _node.Position = new Vector2(x: _node.Position.X, y: _ySpeed.Update(delta));

            return false;
        }

        private void PunishPlayer(double delta)
        {
            if(Math.Abs(_player.Position.X - _node.Position.X) < 200)
            {
                _homingProjectileCowldown = 200;
                return;
            }
            
            if(_homingProjectileCowldown > 0)
            {
                _homingProjectileCowldown-= (float)(delta * 60);
                return;
            }

            _projectileManager.AddProjectile(new DHomingProjectile(_node.Position.X, _node.Position.Y -175, 5));

            _homingProjectileCowldown = 100;
        }
    }
}