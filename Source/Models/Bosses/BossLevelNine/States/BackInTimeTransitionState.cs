using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BackInTimeTransitionState : IState
    {
        private AnimatedSprite2D _aniEntreringPortal;
        
        private Node2D _boss;
        private Panel _foregroundPanel;
        private float _foregroundPanelOpacity = 0;
        private QuickTimer _timer = new(20);

        public BackInTimeTransitionState(AnimatedSprite2D aniEntreringPortal, Node2D boss, Panel foregroundPanel)
        {
            _aniEntreringPortal = aniEntreringPortal;
            _boss = boss;
            _foregroundPanel = foregroundPanel;
        }

        public IState NextState()
        {
            _aniEntreringPortal.Visible = false;
            _foregroundPanel.Modulate = Color.Color8(255, 255, 255, 0);

            return new BackInTimeState(_boss);
        }

        public bool Process(double delta)
        {
            if(_foregroundPanelOpacity < 255)
                MakeTransition(delta);
            else
                return _timer.Process(delta);
            
            return false;
        }

        private void MakeTransition(double delta)
        {
            _aniEntreringPortal.Scale *= new Vector2(1.01f, 1.01f) * (float)(delta * 60);

            _foregroundPanelOpacity += (float)(delta * 120);
            _foregroundPanel.Modulate = Color.Color8(255, 255, 255, (byte)Math.Clamp(_foregroundPanelOpacity, 0, 255));
        }
    }
}