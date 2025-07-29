using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.FinalBoss.States
{
    public class FinalPowerUpGetTransitionState : IState
    {
        public Panel _transitionPanel;
        private Player _player;
        private float _opacity; 
        private float _timer; 
        private AudioStreamPlayer _audioStreamPlayer;
        public FinalPowerUpGetTransitionState(Panel transitionPanel, AudioStreamPlayer audioStreamPlayer)
        {
            _transitionPanel = transitionPanel;
            _player = _transitionPanel.GetTree().Root.GetNode<Player>("/root/Main/Player");
            _player.ResetTargetCount();
            _audioStreamPlayer = audioStreamPlayer;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            if(_timer < 150)
            {
                _audioStreamPlayer.VolumeDb -= 0.5f * (float)(delta * 60);

                _opacity += 2 * (float)(delta * 60);

                _transitionPanel.Modulate = Color.Color8(255, 255, 255, (byte)Math.Clamp(_opacity, 0, 255));
                _timer+= (float)(delta * 60);
            }else
            {
                _audioStreamPlayer.Stop();
                _audioStreamPlayer.VolumeDb = 0;
                _player.SetDefaultLimit();
                return true;
            }

            return false;
        }
    }
}