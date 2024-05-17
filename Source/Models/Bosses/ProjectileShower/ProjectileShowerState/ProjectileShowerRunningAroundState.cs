using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.ProjectileShowerState
{
    public class ProjectileShowerRunningAroundState : IState
    {
        private ProjectileShower _node;
        private int _speed = 6;
        private WaveSpeed _ySpeed;

        public ProjectileShowerRunningAroundState(ProjectileShower node)
        {
            _node = node;
            _ySpeed = new WaveSpeed(-4, 10, _node.Position.Y);
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            _node.Position = new Vector2(x: _node.Position.X + _speed, y: _ySpeed.Update());

		    if(_node.Position.X - 100 <= 0 && _speed < 0)
			    _speed *= -1;
		    else if(_node.Position.X + 100 >= _node.GetViewport().GetWindow().Size.X && _speed > 0)
			    _speed *= -1;

            return false;
        }
    }
}