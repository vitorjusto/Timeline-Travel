using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

public partial class Sniper : CharacterBody2D, IEnemy
{

	private int _speed = 9;

	private int _time = 0;

	public EEnemyProjectileType ProjectileType;
    public override void _Process(double delta)
	{
		MoveEnemy();

		_time++;
	}

    private void MoveEnemy()
    {
		if(_time < 15)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _speed);

		}else if(_time == 35)
		{
			ShootProjectile();
		}
		else if(_time > 50)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _speed);
		}
    }

	private void ShootProjectile()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		else if(ProjectileType == EEnemyProjectileType.Light)
			projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		else if(ProjectileType == EEnemyProjectileType.Strong)
			projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));		
		else if(ProjectileType == EEnemyProjectileType.Homing)
			projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 41));		

	}

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public void Destroy()
	{
        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
	}

	public bool IsImortal()
	{
		return false;
	}

    public EnemyBoundy GetBoundy()
    {
        return new(2, 1, Position);
    }
}
