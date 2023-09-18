using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;

public partial class Spreader : CharacterBody2D, IEnemy
{
	private int _speed = 1;
	private int _time = 0;
	public EEnemyProjectileType ProjectileType;
    public override void _Process(double delta)
	{
		MoveEnemy();

	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + _speed);

		_time += 1;
        
        if(_time % 30 == 0)
        {
            ShootProjectile(0, 1);
			ShootProjectile(-1, 1);
            ShootProjectile(-1, 0);
            ShootProjectile(-1, -1);
           	ShootProjectile(0, -1);
            ShootProjectile(1, -1);
            ShootProjectile(1, 0);
            ShootProjectile(1, 1);

            _time = 0;
        }

		
    }

	private void ShootProjectile(float xspeed, float yspeed)
	{
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, xspeed * (4.5f), yspeed * (4.5f)));
		else if(ProjectileType == EEnemyProjectileType.Light)
			projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, xspeed * (5), yspeed * (5)));
		else if(ProjectileType == EEnemyProjectileType.Strong)
			projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y, xspeed * (4), yspeed * (4)));		
		

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
