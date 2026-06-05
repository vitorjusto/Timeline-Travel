using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DTimelineEightFinalBoss : IEnemyDummy
{
	private readonly INextStateFinalBoss _nextState;

	public DTimelineEightFinalBoss(INextStateFinalBoss nextState)
		=> _nextState = nextState;
	
	public Node2D GetInstance()
	{
		var instance = LoaderManager.GetObjectPool<TimelineEightFinalBoss>("res://Scenes/Bosses/FinalBoss/TimelineEightFinalBoss.tscn");
		instance.SetNextState(_nextState);

		return instance;
	}
}