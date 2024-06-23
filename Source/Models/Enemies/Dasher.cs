using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Dasher : CharacterBody2D, IEnemy
{

	private int _speed = 3;
	private float _xspeed = 0;
	private float _yspeed = 0;


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

		}else if(_time == 51)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			player.ShowTarget();
		}
		else if(_time == 139)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			_xspeed = (float)Math.Sin(angle) * (-20);
			_yspeed = (float)Math.Cos(angle) * (-20);
			
			player.HideTarget();
		}
		else if(_time > 140)
		{
			Position = new Vector2(x: Position.X + _xspeed, y: Position.Y + _yspeed);
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
		GetTree().Root.GetNode<Player>("/root/Main/Player").HideTarget();
	}

	public bool IsImortal()
	{
		return false;
	}

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}
