using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DTimelineTwoFourBoss : IEnemyDummy
{
	private readonly INextStateFinalBoss _nextState;

	public DTimelineTwoFourBoss(INextStateFinalBoss nextState)
		=> _nextState = nextState;
	public Node2D GetInstance()
	{
		var instance = LoaderManager.GetObjectPool<TimelineTwoFourBoss>("res://Scenes/Bosses/FinalBoss/TimelineTwoFourBoss.tscn");
		instance.SetNextState(_nextState);
		

		return instance;
	}
}
