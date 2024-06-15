using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using System;

public partial class ShootPoint : Node2D
{
	[Export]
	public Node2D NodeOrigin;

	[Export]
	public EEnemyProjectileType ProjectileType;

	[Export]
	public int Timer;
	private int _currentTime;

	[Export]
	public float ExtraAngle;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		_currentTime++;
		if(_currentTime == Timer)
			Shoot();
	}

	private void Shoot()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X + NodeOrigin.Position.X - player.Position.X, Position.Y + NodeOrigin.Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
		{
			projectiles.AddProjectile(new DNormalProjectile(Position.X + NodeOrigin.Position.X, Position.Y + NodeOrigin.Position.Y, (float)Math.Sin(angle + ExtraAngle) * (-3), (float)Math.Cos(angle + ExtraAngle) * (-3)));
		}
		else if(ProjectileType == EEnemyProjectileType.Light)
		{
			projectiles.AddProjectile(new DLightProjectile(Position.X + NodeOrigin.Position.X, Position.Y + NodeOrigin.Position.Y, (float)Math.Sin(angle + ExtraAngle) * (-3), (float)Math.Cos(angle + ExtraAngle) * (-3)));
		}
		else if(ProjectileType == EEnemyProjectileType.Strong)
		{
			projectiles.AddProjectile(new DStrongProjectile(Position.X + NodeOrigin.Position.X, Position.Y + NodeOrigin.Position.Y, (float)Math.Sin(angle + ExtraAngle) * (-3), (float)Math.Cos(angle + ExtraAngle) * (-3)));	
		}
		else if(ProjectileType == EEnemyProjectileType.Homing)
			projectiles.AddProjectile(new DHomingProjectile(Position.X + NodeOrigin.Position.X, Position.Y + NodeOrigin.Position.Y));	

		_currentTime = 0;
	}
}
