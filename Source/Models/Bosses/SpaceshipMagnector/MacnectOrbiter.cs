using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class MacnectOrbiter : CharacterBody2D, IEnemy
{

	private int _speed = 10;
	private bool _isRotating = false;

	public ESpawnPosition SpawnPosition;

	private int _xspeedModifier = 1;
	private int _yspeedModifier = 1;

	private float _time = 0;
	private float _ytime = 3.333f;
	private int _playerDistance = 2000; 


	public override void _Ready()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");


		if(SpawnPosition == ESpawnPosition.Up)
		{
			_xspeedModifier = -1;
			_yspeedModifier = -1;

			Position = new Vector2(x: player.Position.X, y: player.Position.Y - _playerDistance);
		}else if(SpawnPosition == ESpawnPosition.Left)
		{
			_yspeedModifier = -1;
			Position = new Vector2(x: player.Position.X - _playerDistance, y: player.Position.Y);
		}else if(SpawnPosition == ESpawnPosition.Right)
		{
			_xspeedModifier = -1;
			Position = new Vector2(x: player.Position.X + _playerDistance, y: player.Position.Y);
		}else if(SpawnPosition == ESpawnPosition.Down)
		{
			Position = new Vector2(x: player.Position.X, y: player.Position.Y + _playerDistance);
		}
	}

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		
		if(_isRotating)
		{
			Rotate();
		}else
		{
			if(SpawnPosition == ESpawnPosition.Up)
			{

				Position = new Vector2(x: player.Position.X, y: player.Position.Y - _playerDistance);
				
				if(Position.Y > player.Position.Y - 150)
					_isRotating = true;

			}else if(SpawnPosition == ESpawnPosition.Down)
			{
				Position = new Vector2(x: player.Position.X, y: player.Position.Y + _playerDistance);
				
				if(Position.Y - player.Position.Y < 150)
					_isRotating = true;

			}else if(SpawnPosition == ESpawnPosition.Left)
			{
				Position = new Vector2(x: player.Position.X - _playerDistance, y: player.Position.Y);
				
				if(Position.X > player.Position.X - 150)
				{
					_isRotating = true;
					_ytime = 0;
					_time = 3.3f;
				}

			}else if(SpawnPosition == ESpawnPosition.Right)
			{
				Position = new Vector2(x: player.Position.X + _playerDistance, y: player.Position.Y);
				
				if(Position.X - player.Position.X < 150)
				{
					_isRotating = true;
					_ytime = 0;
					_time = 3.3f;
				}

			}

			_playerDistance -= _speed;
		}
    }

	public void Rotate()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		float xspeed = (-15 * (_time * _time)) + (_time * 100f);
		xspeed *= _xspeedModifier; 
		_time += 0.1f;

		//Caso altere o A ou o B, faça |B/A| e coloca aqui
		if(_time > 6.666)
		{
			_time = 0;
			_xspeedModifier *= (-1);
		}

		float yspeed = (-15 * (_ytime * _ytime)) + (_ytime * 100f);
		yspeed *= _yspeedModifier; 
		_ytime += 0.1f;

		if(_ytime > 6.666)
		{
			_ytime = 0;
			_yspeedModifier *= (-1);
		}

        Position = new Vector2(x:player.Position.X + xspeed, y: player.Position.Y + yspeed);
	}

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return true;
	}


    public void Destroy()
    {

    }
}
