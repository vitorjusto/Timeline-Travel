using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

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
	public QuickTimer _shootingCooldown = new(100);
	private bool _allowShoot = true;
    private DamageAnimationPlayer _damageAnimator;
    private bool _active;

	public int _hp = 20;
	public override void _Ready()
	{
		_active = false;
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}

	public override void _Process(double delta)
	{
        if(!_active)
            return;

		if(_hp <= 0)
		{
			EmitSignal("OnOrbiterDestroyed", this);
		}

		if(_shootingCooldown.Process(delta))
			Shoot();

		Move(delta);

		_damageAnimator.Process(delta);

	}

    private void Move(double delta)
    {
		_time += 0.1f * (float)(delta * 60);
        float xspeed = (-15 * (_time * _time)) + (_time * 100f);
		xspeed *= _xspeedModifier; 
    
		if(_time > 6.666)
		{
			_time = 0;
			_xspeedModifier *= (-1);
		}
    
		_ytime += 0.1f * (float)(delta * 60);
		float yspeed = (-15 * (_ytime * _ytime)) + (_ytime * 100f);
		yspeed *= _yspeedModifier; 
    
		if(_ytime > 6.666)
		{
			_ytime = 0;
			_yspeedModifier *= (-1);
		}
    
        Position = new Vector2(x:xspeed, y: yspeed);
    }

    private void Shoot()
    {
		if(_allowShoot)
			EmitSignal("OnShooting", this);
	}

    public void Destroy()
    {
		_damageAnimator.PlayDamageAnimation();
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
		_active = true;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	public void ChangeShooting(bool state)
	{
		_allowShoot = state;
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
