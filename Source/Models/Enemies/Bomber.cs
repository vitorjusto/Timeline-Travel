using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

public partial class Bomber : CharacterBody2D, IEnemy
{

	private int _speed = 6;
	private int _time = 0;


    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		if(_time < 100)
		{
        	var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			var x = Position.X + (float)Math.Sin(angle) * _speed * -1;
			var y = Position.Y + (float)Math.Cos(angle) * _speed * -1;
			Position = new Vector2(x ,y );
		}else
		{
			Destroy();
		}

		_time++;
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
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, -5));


		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
	}

    public EnemyBoundy GetBoundy()
    {
        throw new NotImplementedException();
    }
}
