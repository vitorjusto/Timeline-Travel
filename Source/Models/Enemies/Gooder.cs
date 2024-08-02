using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

public partial class Gooder : CharacterBody2D, IEnemy
{
	private int _yspeed = 2;
	private int _xspeed = 6;
	private int _time = 0;
	private bool _isAngry = false;
	public bool Walk = false;
	private float _speedModifier = 5;
	public int MaxTimer = 900;
    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {	
		if(_isAngry)
			DoAngryBehavior();
		else
			DoNormalBehavior();

		_time++;
    }

	private void DoNormalBehavior()
	{
		if(_time < 50)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _yspeed);

		}else if(_time > MaxTimer)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _yspeed);
		}else if(Walk)
		{
			Position = new Vector2(x: Position.X + _xspeed, y: Position.Y);

			if(Position.X > 1412 || Position.X < 32)
				_xspeed *= -1;
		}
	}

	private void DoAngryBehavior()
	{
		if(_time < 500)
		{
			FollowPlayer();

			if(_time % 20 == 0)
			{
				Shoot();
			}
		}else
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        	enemySpawner.RemoveEnemy(this);
		}
	}

	private void Shoot()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
				
		projectiles.AddProjectile(new DNormalProjectile(Position.X + 2, Position.Y + 26, (float)Math.Sin(angle) * (-5), (float)Math.Cos(angle) * (-5)));
	}

	private void FollowPlayer()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
			
		var xspeed = (float)Math.Sin(angle) * (-_speedModifier);
		var yspeed = (float)Math.Cos(angle) * (-_speedModifier);

		Position = new Vector2(x: Position.X + xspeed, y: Position.Y + yspeed);
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
		if(_isAngry)
		{
			_time -= 10;
			_speedModifier+= 0.5f;
			return;
		}

		_isAngry = true;
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Angry");
		_time = 0;
		
    }

    public EnemyBoundy GetBoundy()
    {
        return new(2, 2, Position);
    }
}
