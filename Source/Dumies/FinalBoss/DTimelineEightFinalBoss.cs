using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DTimelineEightFinalBoss : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DTimelineEightFinalBoss(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/TimelineEightFinalBoss.tscn");

            var instance = (TimelineEightFinalBoss)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}