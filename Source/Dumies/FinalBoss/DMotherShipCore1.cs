using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.FinalBoss;
public class DMotherShipCore1 : IEnemyDummy
{
	private readonly int _removePuncherId;

	private readonly INextStateFinalBoss _nextState;

	public DMotherShipCore1(INextStateFinalBoss nextState, int RemovePuncherId = 0)
	{
		_removePuncherId = RemovePuncherId;
		_nextState = nextState;
	}
	public Node2D GetInstance()
	{
		var instance = LoaderManager.GetObjectPool<MotherShipCore1Base>("res://Scenes/Bosses/FinalBoss/MotherShipCore1.tscn");
		instance.RemovePuncher(_removePuncherId);
		instance.AddNextState(_nextState);

		return instance;
	}
}