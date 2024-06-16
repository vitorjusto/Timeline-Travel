using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class ConceptHead : CharacterBody2D, IEnemy
{

	private int _hp = 20;
    private int _speed = -4;
	private WaveSpeed _ySpeed;
	private bool _forceFieldDestroyed = false;
	private bool _dashing = false;
    private bool _isDestroyng;
    private bool _shooting = false;
	public int _time = 0;
    private EnemySpawner _enemySpawner;
    private ProjectileManager _projectiles;

	public EDashStatus _dashStatus = EDashStatus.NotDashing;

    public override void _Ready()
    {
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		_ySpeed = new WaveSpeed(-2, 10, Position.Y);
    }
    public override void _Process(double delta)
	{
		if(_isDestroyng)
			DestroyAnimation();
		else if(_forceFieldDestroyed)
			Dash();
		else			
			MoveEnemy();

		if(_shooting)
			Shoot();
	}

    private void Dash()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var xSpeed = 0;
		float yPosition = 0;

		if(Math.Abs(Position.X - player.Position.X) < 64 || _dashStatus == EDashStatus.Dashing)
		{
			yPosition = 16 + Position.Y;
			_dashStatus = EDashStatus.Dashing;

			if(Position.Y + 96 >= GetViewport().GetWindow().Size.Y)
			{
				_projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y - 96, 0, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X - 96, Position.Y - 96, -3, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X + 96, Position.Y - 96, 3, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X - 48, Position.Y - 96, -1.5f, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X + 48, Position.Y - 96, 1.5f, -3));
				_dashStatus = EDashStatus.GoingToOriginalPosition;
			}
		}
		else if(_dashStatus == EDashStatus.GoingToOriginalPosition)
		{
			yPosition = -16 + Position.Y;

			if(yPosition <=160)
			{
				_dashStatus = EDashStatus.NotDashing;
				_ySpeed = new WaveSpeed(-6, 30, Position.Y, reverseDirection: true);
				yPosition = _ySpeed.Update();
			}
		}
		else if(Position.X < player.Position.X)
		{
			xSpeed = Math.Abs(_speed) * 2;
			yPosition = _ySpeed.Update();
		}
		else if(Position.X > player.Position.X)
		{
			xSpeed = Math.Abs(_speed) * -2;
			yPosition = _ySpeed.Update();
		}

		Position = new Vector2(x: Position.X + xSpeed, y: yPosition);
    }


    private void Shoot()
    {
		if(_time == 200)
		{
			_time = 0;
        	_projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y));
		}

		_time++;
    }


    private void DestroyAnimation()
    {
		_enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)));

		if(_time == 300)
		{
			EmitSignal("OnHeadDestroyed");
		}

		_time++;
    }

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X + _speed, y: _ySpeed.Update());

		if(Position.X - 64 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 64 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
		if(_forceFieldDestroyed)
			_hp--;
		
		if(_hp == 0)
		{
			_isDestroyng = true;
			_time = 0;
		}
    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnHeadDestroyedEventHandler();

	public void OnAllBodyPartDestroyed()
	{
		_forceFieldDestroyed = true;

		_ySpeed = new WaveSpeed(-6, 30, Position.Y, reverseDirection: true);

		GetNode<Node2D>("ForceField").CallDeferred("queue_free");
		GetNode<Node2D>("CollisionForceField").CallDeferred("queue_free");
		GetNode<CollisionShape2D>("CollisionHead").SetDeferred("disabled", false);

	}

	public void OnActivateHeadShooting()
	{
		_shooting = true;
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}