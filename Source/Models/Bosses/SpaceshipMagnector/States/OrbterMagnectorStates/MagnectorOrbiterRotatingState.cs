using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.OrbterMagnectorStates
{
    public class MagnectorOrbiterRotatingState : IState
    {
        private MacnectOrbiter _node;
        private Player _player;
        private float _time;
        private float _ytime = 3.333f;
        private int _xspeedModifier = 1;
        private int _yspeedModifier = 1;

        public MagnectorOrbiterRotatingState(MacnectOrbiter node, float time, float ytime, int xspeedModifier, int yspeedModifier)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
            _time = time;
            _ytime = ytime;
            _xspeedModifier = xspeedModifier;
            _yspeedModifier = yspeedModifier;
        }
        public IState NextState()
        {
            return new MagnectorOrbiterWaitingState(this, _node);
        }

        public bool Process()
        {

		    float xspeed = (-15 * (_time * _time)) + (_time * 100f);
		    xspeed *= _xspeedModifier; 
		    _time += 0.1f;
    
		    //Caso altere o A ou o B, faça |B/A| e coloca aqui
		    if(_time > 6.666)
		    {
		    	_time = 0;
		    	_xspeedModifier *= (-1);
		    }
    
		    float yspeed = (-15 * (_ytime * _ytime)) + (_ytime * 100f);
		    yspeed *= _yspeedModifier; 
		    _ytime += 0.1f;
    
		    if(_ytime > 6.666)
		    {
		    	_ytime = 0;
		    	_yspeedModifier *= (-1);
		    }
    
            _node.Position = new Vector2(x:_player.Position.X + xspeed, y: _player.Position.Y + yspeed);

            return false;
        }
    }
}