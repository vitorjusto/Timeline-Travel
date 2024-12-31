using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DFinalStage : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DFinalStage(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/FinalStage.tscn");

            var instance = (FinalStage)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}