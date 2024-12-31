using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DTimelineTwoFourBoss : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DTimelineTwoFourBoss(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/TimelineTwoFourBoss.tscn");

            var instance = (TimelineTwoFourBoss)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}