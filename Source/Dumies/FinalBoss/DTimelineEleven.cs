using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DTimelineEleven : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DTimelineEleven(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/TimelineEleven.tscn");

            var instance = (TimelineEleven)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}