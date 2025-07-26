using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BackInTimeTransitionState : IState
    {
        private AnimatedSprite2D _aniEntreringPortal;
        
        private Node2D _boss;
        private Panel _foregroundPanel;
        private byte _foregroundPanelOpacity = 0;
        private int _timer = 0;

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
                MakeTransition();
            else
                _timer++;
            
            return _timer > 20;
        }

        private void MakeTransition()
        {
            _aniEntreringPortal.Scale *= new Vector2(1.01f, 1.01f);

            _foregroundPanelOpacity += 3;
            _foregroundPanel.Modulate = Color.Color8(255, 255, 255, _foregroundPanelOpacity);
        }
    }
}