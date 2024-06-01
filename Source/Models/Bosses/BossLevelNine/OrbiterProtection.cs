using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public partial class OrbiterProtection : Node2D, IEnemy
{
	[Export]
	public float _time;
	[Export]
    public float _ytime = 3.333f;
	[Export]
    public int _xspeedModifier = 1;
	[Export]
    public int _yspeedModifier = 1;
	public int _shootingCooldown = 100;

	public int _hp = 10;
	public override void _Ready()
	{
		SetProcess(false);
	}

	public override void _Process(double delta)
	{
		if(_hp == 0)
		{
			EmitSignal("OnOrbiterDestroyed", this);
		}

		_shootingCooldown--;

		if(_shootingCooldown == 0)
			Shoot();

		Move();

	}

    private void Move()
    {
        float xspeed = (-15 * (_time * _time)) + (_time * 100f);
		xspeed *= _xspeedModifier; 
		_time += 0.1f;
    
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
    
        Position = new Vector2(x:xspeed, y: yspeed);
    }

    private void Shoot()
    {
        _shootingCooldown = 100;

		EmitSignal("OnShooting", this);
	}

    public void Destroy()
    {
        _hp--;
    }

	[Signal]
	public delegate void OnOrbiterDestroyedEventHandler(Node2D node);

	[Signal]
	public delegate void OnShootingEventHandler(Node2D node);

    public bool IsImortal()
    {
        return true;
    }

	public void OnActivated()
	{
		SetProcess(true);
	}
}
