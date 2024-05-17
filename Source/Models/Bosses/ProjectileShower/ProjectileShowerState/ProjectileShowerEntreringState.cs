using Godot;
using shooter.Source.Models.Bosses.ProjectileShowerState;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.ProjectileShowerState
{
    public class ProjectileShowerEntreringState : IState
    {
        private ProjectileShower _node;
        private int _speed = 10;

        public ProjectileShowerEntreringState(ProjectileShower node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new ProjectileShowerStandState(_node);
        }

        public bool Process()
        {
            _node.Position = new Vector2(_node.Position.X, _node.Position.Y + _speed);

            return _node.Position.Y > 100;
        }
    }
}