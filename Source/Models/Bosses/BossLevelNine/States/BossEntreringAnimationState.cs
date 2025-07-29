using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BossEntreringAnimationState : IState
    {
        private AnimatedSprite2D _aniEntreringPortal;
        private QuickTimer _timer = new(50);
        private int _currentAnimationFrame = 0;
        private FourDWarMachine _boss;

        public BossEntreringAnimationState(AnimatedSprite2D aniEntreringPortal, FourDWarMachine boss)
        {
            _aniEntreringPortal = aniEntreringPortal;
            _boss = boss;
        }

        public IState NextState()
        {
            return new BossShownUpState(_boss);
        }

        public bool Process(double delta)
        {
            if(_timer.Process(delta))
                AnimationNextFrame();

            return _currentAnimationFrame == 4;
        }

        private void AnimationNextFrame()
        {
            _currentAnimationFrame++;

            _aniEntreringPortal.Play($"EntranceAnimation{_currentAnimationFrame}");
        }
    }
}