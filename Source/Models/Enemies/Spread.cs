using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;

public partial class Spread : CharacterBody2D, IEnemy
{
	public int Speed;
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
        
        if(_time % 80 == 0)
        {
            ShootProjectile(0, 1);
            _time = 1;
        }
        else if(_time % 80 == 10)
            ShootProjectile(-1, 1);
        else if(_time % 80 == 20)
            ShootProjectile(-1, 0);
        else if(_time % 80 == 30)
            ShootProjectile(-1, -1);
        else if(_time % 80 == 40)
           	ShootProjectile(0, -1);
        else if(_time % 80 == 50)
            ShootProjectile(1, -1);
        else if(_time % 80 == 60)
            ShootProjectile(1, 0);
        else if(_time % 80 == 70)
            ShootProjectile(1, 1);
    }

	private void ShootProjectile(float xspeed, float yspeed)
	{
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		if(ProjectileType == EEnemyProjectileType.Normal)
			projectiles.AddProjectile(new DNormalProjectile(Position.X + (xspeed * 30), Position.Y + (yspeed * 30), xspeed * (4), yspeed * (4)));
		else if(ProjectileType == EEnemyProjectileType.Light)
			projectiles.AddProjectile(new DLightProjectile(Position.X + (xspeed * 30), Position.Y + (yspeed * 30), xspeed * (6), yspeed * (6)));
		else if(ProjectileType == EEnemyProjectileType.Strong)
			projectiles.AddProjectile(new DStrongProjectile(Position.X + (xspeed * 30), Position.Y + (yspeed * 30), xspeed * (3), yspeed * (3)));		
		

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
