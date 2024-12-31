using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DFistState : IEnemyDummy
    {
        private INextStateFinalBoss _nextState;

        public DFistState(INextStateFinalBoss nextState)
            => _nextState = nextState;
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/FirstState.tscn");

            var instance = (FirstStateBase)scene.Instantiate();
            instance.SetNextState(_nextState);

            return instance;
        }
    }
}