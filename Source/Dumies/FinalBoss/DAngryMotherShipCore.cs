using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.FinalBoss
{
    public class DAngryMotherShipCore : IEnemyDummy
    {
        private int _removeProtectorId;

        private INextStateFinalBoss _nextState;

        public DAngryMotherShipCore(INextStateFinalBoss nextState, int RemoveProtectorId = 0)
        {
            _removeProtectorId = RemoveProtectorId;
            _nextState = nextState;
        }
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/FinalBoss/angryMotherShipCore.tscn");

            var instance = (angryCoreBase)scene.Instantiate();

            instance.RemoveProtector(_removeProtectorId);
            instance.AddNextState(_nextState);

            return instance;
        }
    }
}