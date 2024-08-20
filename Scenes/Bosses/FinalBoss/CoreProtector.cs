using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class CoreProtector : CharacterBody2D, IEnemy
{
	private int _hp = 100;
	private bool _canTakeDamage = true;
    private DamageAnimationPlayer _damageAnimator;
    private bool _destroyed;

    public override void _Ready()
	{
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}
	public override void _Process(double delta)
	{
		_damageAnimator.Process();
	}

    public void Destroy()
    {
		if(_canTakeDamage)
        	_hp--;

		if(_hp <= 0)
		{
			if(!_destroyed)
			{
				GetNode<Node2D>("ChequerAtackContainer").CallDeferred("queue_free");
				EmitSignal("OnProtectorDestoyed", this);

        		GetNode<RegularShootPoint>("RegularShootPoint").Active = false;
        		GetNode<RegularShootPoint>("RegularShootPoint2").Active = false;

				_destroyed = true;
			}

		}else
		{
			_damageAnimator.PlayDamageAnimation();
		}
    }

    public bool IsImortal()
    {
        return true;
    }

	public void OnOtherProtectorDestroyed(Node2D node)
	{
		_canTakeDamage = false;

        GetNode<RegularShootPoint>("RegularShootPoint").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint2").Active = false;

		GetNode<ChequerActackContainer>("ChequerAtackContainer").Active = false;
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    public void EnableProtector()
    {
        GetNode<RegularShootPoint>("RegularShootPoint").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint2").Active = true;
		_canTakeDamage = true;

		GetNode<ChequerActackContainer>("ChequerAtackContainer").Active = true;
    }

    [Signal]
	public delegate void OnProtectorDestoyedEventHandler(Node2D node);
}
