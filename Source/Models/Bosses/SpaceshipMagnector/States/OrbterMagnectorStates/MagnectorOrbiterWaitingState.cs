using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.OrbterMagnectorStates
{
    public class MagnectorOrbiterWaitingState : IState
    {
        private MagnectorOrbiterRotatingState _rotatingState;
        private MacnectOrbiter _node;
        private float _time;

        public MagnectorOrbiterWaitingState(MagnectorOrbiterRotatingState rotatingState, MacnectOrbiter node)
        {
            _rotatingState = rotatingState;
            _node = node;
        }

        public IState NextState()
        {
            return new MagnectorOrbiterFollowingPlayerState(_node);
        }

        public bool Process(double delta)
        {
            if((int)_node.SpawnPosition * 50 >= _time)
                return true;

            _rotatingState.Process(delta);
            
            _time+= (float)(delta * 60);
            return false;
        }
    }
}