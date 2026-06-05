using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DFinalStage : IEnemyDummy
{
    private readonly INextStateFinalBoss _nextState;

    public DFinalStage(INextStateFinalBoss nextState)
        => _nextState = nextState;
		
    public Node2D GetInstance()
    {
		var instance = LoaderManager.GetObjectPool<FinalStage>("res://Scenes/Bosses/FinalBoss/FinalStage.tscn");
        instance.SetNextState(_nextState);

        return instance;
    }
}