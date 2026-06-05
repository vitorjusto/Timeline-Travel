using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;

public class DTimelineThree : IEnemyDummy
{
	private readonly INextStateFinalBoss _nextState;

	public DTimelineThree(INextStateFinalBoss nextState)
		=> _nextState = nextState;

	public Node2D GetInstance()
	{
		var instance = LoaderManager.GetObjectPool<Timelinethree>("res://Scenes/Bosses/FinalBoss/Timelinethree.tscn");
		instance.SetNextState(_nextState);

		return instance;
	}
}