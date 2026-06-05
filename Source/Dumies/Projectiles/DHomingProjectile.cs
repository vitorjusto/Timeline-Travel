using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Projectiles;

public class DHomingProjectile : IProjectileDummy
{
	public float X;
	public float Y;
	private readonly float _speedModifier;

	public DHomingProjectile(float x, float y, float speedModifier = 3)
	{
		X = x;
		Y = y;
		_speedModifier = speedModifier;
	}

	public Node2D GetInstance()
	{
		var instance = LoaderManager.GetObjectPool<HomingProjectile>("res://Scenes/Projectiles/EnemyProjectiles/HomingProjectile.tscn");

		instance.SetPosition(X, Y);
		instance.SpeedModifier = GameManager.IsSpecialMode?_speedModifier*3:_speedModifier;
		
		return instance;
	}
}
