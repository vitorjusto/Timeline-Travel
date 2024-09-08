using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Orbiter : CharacterBody2D, IEnemy
{

	private int _speed = 10;
	private bool _isRotating = false;

	private int _xspeedModifier = 1;
	private int _yspeedModifier = 1;

	private float _time = 0;
	private float _ytime = 2f;

	private int _semiRotation = 0;
	private bool _selfDestructing = false;

	public override void _Ready()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		Position = new Vector2(x: player.Position.X, y: 1000);
	}

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		if(_selfDestructing)
		{
			Position = new Vector2(x: player.Position.X, y: Position.Y + _speed * 3);
		}
		else if(_isRotating)
		{
			Rotate();
		}else
		{
			
			Position = new Vector2(x: player.Position.X, y: Position.Y - _speed);
			
			if(Position.Y - player.Position.Y < 150)
				_isRotating = true;
		}
    }

	public void Rotate()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		float xspeed = (-30 * (_time * _time)) + (_time * 120f);
		xspeed *= _xspeedModifier; 
		_time += 0.1f;

		//Caso altere o A ou o B, faça |B/A| e coloca aqui
		if(_time > 4)
		{
			_time = 0;
			_xspeedModifier *= (-1);
			_semiRotation++;
		}

		float yspeed = (-30 * (_ytime * _ytime)) + (_ytime * 120f);
		yspeed *= _yspeedModifier; 
		_ytime += 0.1f;

		if(_ytime > 4)
		{
			_ytime = 0;
			_yspeedModifier *= (-1);
		}

        Position = new Vector2(x:player.Position.X + xspeed, y: player.Position.Y + yspeed);
		
		_selfDestructing = _semiRotation == 7;
	}

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}


    public void Destroy()
    {
        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
    }

    public EnemyBoundy GetBoundy()
    {
        return new(2, 0, Position);
    }
}
