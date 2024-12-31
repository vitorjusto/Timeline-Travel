using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.FinalBoss.States
{
    public class FinalPowerUpGetTransitionState : IState
    {
        public Panel _transitionPanel;
        private Player _player;
        private byte _opacity; 
        private int _timer; 

        public FinalPowerUpGetTransitionState(Panel transitionPanel)
        {
            _transitionPanel = transitionPanel;
            _player = _transitionPanel.GetTree().Root.GetNode<Player>("/root/Main/Player");
            _player.ResetTargetCount();
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_timer < 150)
            {
                _opacity += (byte)(_opacity < 254? 2: 0);
                _transitionPanel.Modulate = Color.Color8(255, 255, 255, _opacity);
                _timer++;
            }else
            {
                _player.SetDefaultLimit();
                return true;
            }

            return false;
        }
    }
}