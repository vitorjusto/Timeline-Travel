using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BossEntreringAnimationState : IState
    {
        private AnimatedSprite2D _aniEntreringPortal;
        private int _timer = 0;
        private int _currentAnimationFrame = 0;
        private Node2D _boss;

        public BossEntreringAnimationState(AnimatedSprite2D aniEntreringPortal, Node2D boss)
        {
            _aniEntreringPortal = aniEntreringPortal;
            _boss = boss;
        }

        public IState NextState()
        {
            return new BossShownUpState(_boss);
        }

        public bool Process()
        {
            _timer++;
            if(_timer > 50)
                AnimationNextFrame();

            return _currentAnimationFrame == 4;
        }

        private void AnimationNextFrame()
        {
            _currentAnimationFrame++;

            _aniEntreringPortal.Play($"EntranceAnimation{_currentAnimationFrame}");
            _timer = 0;
        }
    }
}