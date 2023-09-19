using System.Text.RegularExpressions;
using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Enemies.EnemiesPart;

public partial class Lazer : CharacterBody2D, IEnemy
{

	private int _xspeed = 1;
	private int _yspeed = 2;
	private float _time = 0;
	private bool _isShooting = false;
    public override void _Process(double delta)
	{
		if(_isShooting )
			Shoot();
		else
			MoveEnemy();
	}

    private void MoveEnemy()
    {
		if(_time < 50)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _yspeed);

		}else if(_time > 300)
		{
			_isShooting = true;
			_time = 0;
		}else
		{

			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

			_xspeed = Position.X > player.Position.X? -5: 5;

			if(Math.Abs(Position.X - player.Position.X) > 5)
				Position = new Vector2(x: Position.X + _xspeed, y: Position.Y);

		}

		_time++;
    }

	private void Shoot()
	{
		_time++;

		if(_time < 50)
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        	enemySpawner.AddEnemy(new DLazerPart(Position.X, Position.Y + (20 * _time)));

		}else if(_time > 201)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _yspeed);
		}


	}

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return _isShooting && _time < 201;
	}


    public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }
}
