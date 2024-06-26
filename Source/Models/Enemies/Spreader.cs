using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

public partial class Spreader : CharacterBody2D, IEnemy
{
	public int Speed = 1;
	private int _time = 0;
	public EEnemyProjectileType ProjectileType;
    public override void _Process(double delta)
	{
		MoveEnemy();

	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + Speed);

		_time += 1;
        
        if(_time % 50 == 0)
        {
            ShootProjectile(0, Speed);
			ShootProjectile(-Speed, Speed);
            ShootProjectile(-Speed, 0);
            ShootProjectile(-Speed, -Speed);
           	ShootProjectile(0, -Speed);
            ShootProjectile(Speed, -Speed);
            ShootProjectile(Speed, 0);
            ShootProjectile(Speed, Speed);

            _time = 0;
        }

    }

	private void ShootProjectile(float xspeed, float yspeed)
	{
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, xspeed, yspeed));
		else if(ProjectileType == EEnemyProjectileType.Light)
			projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, xspeed, yspeed));
		else if(ProjectileType == EEnemyProjectileType.Strong)
			projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y, xspeed * (2), yspeed * (2)));		
		

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

    public EnemyBoundy GetBoundy()
    {
        return new(2, 3, Position);
    }
}
