using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;

public partial class RegularShootPoint : Node2D
{
	[Export]
	public EEnemyProjectileType ProjectileType;

	[Export]
	public Node2D Parent;
	[Export]
	public Vector2 Speed;

	public override void _Ready()
	{
	}

	
	public override void _Process(double delta)
	{
	}

	public void Shoot()
	{
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
		{
			projectiles.AddProjectile(new DNormalProjectile(Position.X + Parent.Position.X, Position.Y + Parent.Position.Y, Speed.X, Speed.Y));
		}
		else if(ProjectileType == EEnemyProjectileType.Light)
		{
			projectiles.AddProjectile(new DLightProjectile(Position.X + Parent.Position.X, Position.Y + Parent.Position.Y, Speed.X, Speed.Y));
		}
		else if(ProjectileType == EEnemyProjectileType.Strong)
		{
			projectiles.AddProjectile(new DStrongProjectile(Position.X + Parent.Position.X, Position.Y + Parent.Position.Y, Speed.X, Speed.Y));	
		}
		else if(ProjectileType == EEnemyProjectileType.Homing)
			projectiles.AddProjectile(new DHomingProjectile(Position.X + Parent.Position.X, Position.Y + Parent.Position.Y));	

	}
}
