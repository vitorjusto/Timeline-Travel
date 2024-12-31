using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DMotherShipCore1 : IEnemyDummy
    {
        private int _removePuncherId;

        private INextStateFinalBoss _nextState;

        public DMotherShipCore1(INextStateFinalBoss nextState, int RemovePuncherId = 0)
        {
            _removePuncherId = RemovePuncherId;
            _nextState = nextState;
        }
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/MotherShipCore1.tscn");

            var instance = (MotherShipCore1Base)scene.Instantiate();

            instance.RemovePuncher(_removePuncherId);
            instance.AddNextState(_nextState);

            return instance;
        }
    }
}