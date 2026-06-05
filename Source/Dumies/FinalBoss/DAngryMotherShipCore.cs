using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DAngryMotherShipCore : IEnemyDummy
{
    private readonly int _removeProtectorId;

    private readonly INextStateFinalBoss _nextState;

    public DAngryMotherShipCore(INextStateFinalBoss nextState, int RemoveProtectorId = 0)
    {
        _removeProtectorId = RemoveProtectorId;
        _nextState = nextState;
    }

    public Node2D GetInstance()
    {
		var instance = LoaderManager.GetObjectPool<angryCoreBase>("res://Scenes/Bosses/FinalBoss/angryMotherShipCore.tscn");

        instance.RemoveProtector(_removeProtectorId);
        instance.AddNextState(_nextState);

        return instance;
    }
}