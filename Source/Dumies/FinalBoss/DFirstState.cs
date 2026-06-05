using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DFistState : IEnemyDummy
{
    private readonly INextStateFinalBoss _nextState;

    public DFistState(INextStateFinalBoss nextState)
        => _nextState = nextState;
    public Node2D GetInstance()
    {
		var instance = LoaderManager.GetObjectPool<FirstStateBase>("res://Scenes/Bosses/FinalBoss/FirstState.tscn");
        instance.SetNextState(_nextState);

        return instance;
    }
}