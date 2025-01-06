using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.ProjectileShowerState
{
    public class ProjectileShowerRunningAroundState : IState
    {
        private ProjectileShower _node;
        private WaveSpeed _ySpeed;
        private int _speedModifier = 1;

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
            _node.Position = new Vector2(x: _node.Position.X + (_node.Speed * _speedModifier), y: _ySpeed.Update());

		    if(_node.Position.X - 100 <= 0 && (_node.Speed * _speedModifier) < 0)
			    _speedModifier *= -1;
		    else if(_node.Position.X + 100 >= _node.GetViewport().GetWindow().Size.X && (_node.Speed * _speedModifier) > 0)
			    _speedModifier *= -1;

            return false;
        }
    }
}