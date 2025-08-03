using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Bosses.LevelOne.Entities;
using Shooter.Source.Models.Misc;

public partial class BlackHoleGenerator : CharacterBody2D, IEnemy
{

	private int _speed = 3;
    private bool _isDestroing = false;
    private float _time = 0;
	private bool _walking = false;
	private int _hp = 2;
	public EEnemyProjectileType ProjectileType;

    private EnemySpawner _enemySpawner;
	private BlackholeManager _blackholeManager;
    private float _explosionCooldown;

    public override void _Ready()
	{
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		_blackholeManager = new(this,
								GetNode<BlackHoleGeneratorPart>("BlackholePartLeft"),
								GetNode<BlackHoleGeneratorPart>("BlackholePartRight"),
								GetNode<Node2D>("LeftArm"),
								GetNode<Node2D>("RightArm"));
	}

    public override void _Process(double delta)
	{
		if(_isDestroing)
			DestroyAnimation(delta);
		else if(_walking)
		{
			WalkEnemy(delta);
			_blackholeManager.Update();
		}
		else
			MoveEnemy(delta);

		_time+= (float)(delta * 60);
	}

    private void DestroyAnimation(double delta)
    {
        if(_explosionCooldown <= 0)
        {
		    _enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)));
            _explosionCooldown += 10;
        }else
        {
            _enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)), makeSound: false);
            _explosionCooldown-= (float)(delta * 60);
        }

		GetNode<ShootPoint>("ShootPoint").Active = false;
		GetNode<ShootPoint>("ShootPoint2").Active = false;
		GetNode<ShootPoint>("ShootPoint3").Active = false;
		GetNode<ShootPoint>("ShootPoint4").Active = false;
		GetNode<ShootPoint>("ShootPoint5").Active = false;
		GetNode<ShootPoint>("ShootPoint6").Active = false;

		if(_time >= 300)
		{
			_enemySpawner.EndLevel();
			_enemySpawner.RemoveEnemy(this);
		}
    }

    private void WalkEnemy(double delta)
	{
		Position += new Vector2(x: _speed, y: 0) * (float)(delta * 60);

		if(Position.X > 1212 || Position.X < 232)
			_speed *= -1;
	}

    private void MoveEnemy(double delta)
    {
		if(_time < 100)
		{
        	Position = new Vector2(x: 722, y:  Position.Y + (_speed * (float)(delta * 60)));

		}else
		{
			GetNode<ShootPoint>("ShootPoint").Active = true;
			GetNode<ShootPoint>("ShootPoint2").Active = true;
			GetNode<ShootPoint>("ShootPoint3").Active = true;
			GetNode<ShootPoint>("ShootPoint4").Active = true;
			GetNode<ShootPoint>("ShootPoint5").Active = true;
			GetNode<ShootPoint>("ShootPoint6").Active = true;

			_walking = true;
			_time = 0;
		}

    }

	public void Destroy()
	{

	}

	public bool IsImortal()
	{
		return true;
	}

	public void OnDestroyArm(BlackHoleGeneratorPart part)
	{
		_hp--;

		_blackholeManager.RemovePart(part);

		if(_hp == 0)
		{
			_enemySpawner.RemoveAllEnemies();
			_isDestroing = true;

            if(!_enemySpawner.isBossRush)
                AudioManager.Stop();
			_time = 0;
		}

	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}