using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

public partial class Follower : CharacterBody2D, IEnemy
{

	private float _xspeed = 1;
	private float _yspeed = 1;
	private int _speed = 10;
	private int _time = 0;
	public EEnemyProjectileType ProjectileType;
	public int _cicle = 1;


    public override void _Process(double delta)
	{
		Update();
		Position = new Vector2(x: Position.X +_xspeed, y: Position.Y + _yspeed);
	}

    private void Update()
    {
		if(_cicle > 5)
			return;

		if(_time == 0)
		{
			FollowPlayer();
		}else if(_time == 50)
		{
			_xspeed = 0;
			_yspeed = 0;
		}else if(_time == 60)
		{
			ShootProjectile();
		}else if(_time == 69)
		{
			_cicle++;
			_time = -1;
			
			if(_cicle > 5)
				FollowPlayer();
		}

		_time++;
    }

	private void FollowPlayer()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
			
		_xspeed = (float)Math.Sin(angle) * (-_speed);
		_yspeed = (float)Math.Cos(angle) * (-_speed);
	}

	private void ShootProjectile()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		else if(ProjectileType == EEnemyProjectileType.Light)
			projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		else if(ProjectileType == EEnemyProjectileType.Strong)
			projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));		
		else if(ProjectileType == EEnemyProjectileType.Homing)
			projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 10));		

	}

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}


    public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

    public EnemyBoundy GetBoundy()
    {
        return new(1, 1, Position);
    }
}