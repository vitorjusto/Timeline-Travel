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

	public override void _Ready()
	{
		GetNode<RegularShootPoint>("RegularShootPoint").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint2").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint3").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint4").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint5").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint6").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint7").ProjectileType = ProjectileType;
		GetNode<RegularShootPoint>("RegularShootPoint8").ProjectileType = ProjectileType;

		GetNode<RegularShootPoint>("RegularShootPoint").Speed = new Vector2(-Speed, 0);
		GetNode<RegularShootPoint>("RegularShootPoint2").Speed = new Vector2(-Speed, Speed);
		GetNode<RegularShootPoint>("RegularShootPoint3").Speed = new Vector2(0, Speed);
		GetNode<RegularShootPoint>("RegularShootPoint4").Speed = new Vector2(Speed, Speed);
		GetNode<RegularShootPoint>("RegularShootPoint5").Speed = new Vector2(Speed, 0);
		GetNode<RegularShootPoint>("RegularShootPoint6").Speed = new Vector2(Speed, -Speed);
		GetNode<RegularShootPoint>("RegularShootPoint7").Speed = new Vector2(0, -Speed);
		GetNode<RegularShootPoint>("RegularShootPoint8").Speed = new Vector2(-Speed, -Speed);


		if(ProjectileType == EEnemyProjectileType.Strong)
		{
			GetNode<RegularShootPoint>("RegularShootPoint").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint2").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint3").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint4").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint5").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint6").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint7").Speed *= 2;
			GetNode<RegularShootPoint>("RegularShootPoint8").Speed *= 2;
		}
	}

    public override void _Process(double delta)
	{
		MoveEnemy();

	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + Speed);
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
