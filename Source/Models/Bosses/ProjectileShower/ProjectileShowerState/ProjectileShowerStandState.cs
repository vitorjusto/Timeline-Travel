using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace shooter.Source.Models.Bosses.ProjectileShowerState
{
    public class ProjectileShowerStandState : IState
    {   
        private ProjectileShower _node;
        private WaveSpeed _speed;

        public ProjectileShowerStandState(ProjectileShower node)
        {
            _node = node;
            _speed = new WaveSpeed(-1, 6, _node.Position.Y);
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            return false;
        }
    }
}