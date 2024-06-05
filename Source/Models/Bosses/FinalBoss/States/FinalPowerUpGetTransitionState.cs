using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.FinalBoss.States
{
    public class FinalPowerUpGetTransitionState : IState
    {
        public Panel _transitionPanel;
        private Player _player;
        private byte _opacity; 

        public FinalPowerUpGetTransitionState(Panel transitionPanel)
        {
            _transitionPanel = transitionPanel;
            _player = _transitionPanel.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_opacity < 255)
            {
                _opacity += 1;
                _transitionPanel.Modulate = Color.Color8(255, 255, 255, _opacity);
            }else
            {
                _player.SetDefaultLimit();
                return true;
            }

            return false;
        }
    }
}