using System;

namespace Shooter.Source.Models.Misc
{
    public class WaveSpeed
    {
        public float Speed;
	    private float _time = 0f;
        private float _SpeedModifier = 3;
        private float _velocity;
        private float _distance;
	    private float _originalPosition = 0;
        private int _startCooldown;
        public WaveSpeed(float velocity, float distance, float originalPosition, int startCooldown = 0, bool reverseDirection = false)
        {
            _velocity = velocity;
            _distance = distance;
            _originalPosition = originalPosition;
            _startCooldown = startCooldown;

            if(reverseDirection)
                _SpeedModifier *= -1;
        }

        public float Update(double delta)
        {
            if(_startCooldown > 0)
            {
                _startCooldown--;
                return _originalPosition;
            }
            //se você quiser aumentar a distancia, altere o B (30), se você quiser aumentar a velocidade altere o A (-6)
		    Speed = (_velocity * (_time * _time)) + (_time * _distance);

		    Speed *= _SpeedModifier * (float)(delta * 60); 
            Speed += _originalPosition;
		    _time += 0.1f * (float)(delta * 60);

		    if(_time > Math.Abs(_distance/_velocity))
		    {
			    _time = 0.0f;
			    _SpeedModifier *= -1;
		    }

            return Speed;
        }
    }
}