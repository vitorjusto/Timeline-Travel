using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Projectiles;
public class DStrongProjectile : IProjectileDummy
{
	public float X;
	public float Y;
	public float XSpeed;
	public float YSpeeed;

	public DStrongProjectile(float x, float y, float xSpeed, float ySpeeed)
	{
		X = x;
		Y = y;
		XSpeed = xSpeed;
		YSpeeed = ySpeeed;
	}

	public Node2D GetInstance()
	{
		Node2D instance;

		if(GameManager.IsSpecialMode)
			instance = LoaderManager.GetObjectPool<Node2D>("res://Scenes/Projectiles/EnemyProjectiles/SpecialProjectile.tscn");
		else
			instance = LoaderManager.GetObjectPool<Node2D>("res://Scenes/Projectiles/EnemyProjectiles/StrongProjectile.tscn");

		((IEnemyProjectile)instance).SetPosition(X, Y);
		((IEnemyProjectile)instance).SetSpeed(XSpeed, YSpeeed);

		return instance;
	}
}
