using System;

namespace Shooter.Source.Models.Misc
{
    public class WaveSpeed
    {
        public float Speed;
	    private float _time = 0f;
        private float _SpeedModifier;
        private float _velocity;
        private float _distance;
	    private float _originalPosition = 0;
        public WaveSpeed(float speedModifier, float velocity, float distance, float originalPosition)
        {
            _SpeedModifier = speedModifier;
            _velocity = velocity;
            _distance = distance;
            _originalPosition = originalPosition;
        }

        public float Update()
        {
            //se você quiser aumentar a distancia, altere o B (30), se você quiser aumentar a velocidade altere o A (-6)
		    Speed = (_velocity * (_time * _time)) + (_time * _distance);

		    Speed *= _SpeedModifier; 
            Speed += _originalPosition;
            
		    _time += 0.1f;

		    if(_time > Math.Abs(_distance/_velocity))
		    {
			    _time = 0;
			    _SpeedModifier *= (-1);
		    }

            return Speed;
        }
    }
}