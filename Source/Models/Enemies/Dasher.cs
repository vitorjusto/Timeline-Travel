using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Dasher : CharacterBody2D, IEnemy
{

	private int _speed = 3;
	private float _xspeed = 0;
	private float _yspeed = 0;
	private bool _targetHid;

	private int _time = 0;

    public override void _Ready()
    {
        GetNode<Node2D>("ReinforcedDasher").Visible = GameManager.IsSpecialMode;
    }

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

		}else if(_time < 139)
		{
			Animate();
		}
		else if(_time == 139)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			_xspeed = (float)Math.Sin(angle) * (-20);
			_yspeed = (float)Math.Cos(angle) * (-20);
			
			player.HideTarget();
			_targetHid = true;
		}
		else if(_time > 140)
		{
			Position = new Vector2(x: Position.X + _xspeed, y: Position.Y + _yspeed);
		}
    }

    private void Animate()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var speed = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));

		GetNode<Node2D>("Dasher").Rotation = 90;
		GetNode<Node2D>("ReinforcedDasher").Rotation = 90;
		Rotation = speed.Angle();
    }

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public void Destroy()
	{
        if(GameManager.IsSpecialMode)
            return;

        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
		
		if(!_targetHid)
			GetTree().Root.GetNode<Player>("/root/Main/Player").HideTarget();
	}

	public bool IsImortal()
	{
		return GameManager.IsSpecialMode;
	}

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}