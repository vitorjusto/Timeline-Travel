using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.SpaceshipMagnectorStates;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States
{
    public class MagnectorShootingPlayerState : IState
    {
        private Node2D _node;
        private int _speed = 5;
        private int _time = 0;
        private MagnectorIdleState _idleState;
        public MagnectorShootingPlayerState(Node2D node, MagnectorIdleState idleState)
        {
            _node = node;
            _idleState = idleState;
        }

        public IState NextState()
        {
            return new MagnectorShootingAndAtractingState(this, _node);
        }

        public bool Process()
        {

            if(_time == 40)
            {
                ShootProjectile();
                _time = 0;
            }
            
            _time++;
            _idleState.Process();
            
            return false;
        }

        private void ShootProjectile()
        {
            var player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
		    var angle = Math.Atan2(_node.Position.X - player.Position.X, _node.Position.Y - player.Position.Y);
		    var projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
        }
    }
}