using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public partial class Sniper : CharacterBody2D, IEnemy
{

	private int _speed = 3;

	private int _time = 0;

    public override void _Process(double delta)
	{
		MoveEnemy();

		_time++;
	}

    private void MoveEnemy()
    {
		if(_time < 50)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _speed);

		}else if(_time == 90)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
			projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		}
		else if(_time > 120)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _speed);
		}
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
}
