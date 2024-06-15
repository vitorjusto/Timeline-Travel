using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;

public partial class Shoter : CharacterBody2D, IEnemy
{

	private int _speed = 3;
	private int _timeShooted = 0;
	private int _time = 0;

	public EEnemyProjectileType ProjectileType;
    public override void _Process(double delta)
	{
		MoveEnemy();

		_time++;
	}

    private void MoveEnemy()
    {
		if(_timeShooted == 15)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _speed);
			return;
		}

		if(_time < 50)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _speed);

		}else if(_time == 100)
		{
			ShootProjectile();
			_time = 50;
			_timeShooted++;
		}
    }

	private void ShootProjectile()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
		{
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
			projectiles.AddProjectile(new DNormalProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
			projectiles.AddProjectile(new DNormalProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
			projectiles.AddProjectile(new DNormalProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
			projectiles.AddProjectile(new DNormalProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
		}
		else if(ProjectileType == EEnemyProjectileType.Light)
		{
			projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
			projectiles.AddProjectile(new DLightProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
			projectiles.AddProjectile(new DLightProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
			projectiles.AddProjectile(new DLightProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
			projectiles.AddProjectile(new DLightProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
		}
		else if(ProjectileType == EEnemyProjectileType.Strong)
		{
			projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));	
			projectiles.AddProjectile(new DStrongProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
			projectiles.AddProjectile(new DStrongProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
			projectiles.AddProjectile(new DStrongProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
			projectiles.AddProjectile(new DStrongProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));	
		}
		else if(ProjectileType == EEnemyProjectileType.Homing)
			projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 36));		

	}

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public void Destroy()
	{
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
	}

	public bool IsImortal()
	{
		return false;
	}
}
