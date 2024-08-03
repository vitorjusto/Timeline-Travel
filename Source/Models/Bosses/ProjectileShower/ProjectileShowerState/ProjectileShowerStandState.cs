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
            _speed = new WaveSpeed(-1, 3, _node.Position.Y);
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            _node.Position = new Vector2(_node.Position.X, _speed.Update());
            return false;
        }
    }
}