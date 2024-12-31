using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DTimelineThree : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DTimelineThree(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/Timelinethree.tscn");

            var instance = (Timelinethree)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}