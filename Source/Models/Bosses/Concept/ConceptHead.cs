using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public partial class ConceptHead : CharacterBody2D, IEnemy
{

	private int _hp = 20;
    private int _speed = -4;
	private bool _forceFieldDestroyed = false;
	private bool _dashing = false;
    private bool _isDestroyng;
    private bool _shooting = false;
	public int _time = 0;
    private EnemySpawner _enemySpawner;
    private ProjectileManager _projectiles;


    public override void _Ready()
    {
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
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
		var ySpeed = 0;

		if(Math.Abs(Position.X - player.Position.X) < 64 || _dashing)
		{
			ySpeed = 16;
			_dashing = true;

			if(_dashing && Position.Y + 96 >= GetViewport().GetWindow().Size.Y)
			{
				_projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y - 96, 0, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X - 96, Position.Y - 96, -3, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X + 96, Position.Y - 96, 3, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X - 48, Position.Y - 96, -1.5f, -3));
				_projectiles.AddProjectile(new DNormalProjectile(Position.X + 48, Position.Y - 96, 1.5f, -3));
				_dashing = false;
			}
		}
		else if(!_dashing && Position.Y > 160)
			ySpeed = -16;
		else if(Position.X < player.Position.X)
			xSpeed = Math.Abs(_speed) * 2;
		else if(Position.X > player.Position.X)
			xSpeed = Math.Abs(_speed) * -2;



		Position = new Vector2(x: Position.X + xSpeed, y: Position.Y+ ySpeed);
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
        Position = new Vector2(x: Position.X + _speed, y: Position.Y);

		if(Position.X - 96 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 96 >= GetViewport().GetWindow().Size.X && _speed > 0)
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

		GetNode<Node2D>("ForceField").CallDeferred("queue_free");
		GetNode<Node2D>("CollisionForceField").CallDeferred("queue_free");
		GetNode<CollisionShape2D>("CollisionHead").SetDeferred("disabled", false);

	}

	public void OnActivateHeadShooting()
	{
		_shooting = true;
	}
}