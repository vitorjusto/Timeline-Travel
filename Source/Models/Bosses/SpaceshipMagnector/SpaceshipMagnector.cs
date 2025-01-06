using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States;
using Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.SpaceshipMagnectorStates;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class SpaceshipMagnector : Node2D, IEnemy
{
    private EnemySpawner _enemySpawner;
	private IState _state;
	private int _shieldHp = 4;
    private bool _isAtracting;
    private int _hp = GameManager.IsSpecialMode?500:20;
    private DamageAnimationPlayer _damageAnimator;

    private int _warningTimer = 120;
    public override void _Ready()
	{
        GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("NoDash");
		Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, y: -1000);
		int spawnPosition = (int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 6;

		_state = new MagnectorEntreringState(this);

        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
			_state = _state.NextState();

        ProcessNoDashWarning();
        if(!_isAtracting)
            _damageAnimator.Process();
	}

    private void ProcessNoDashWarning()
    {
        if(_warningTimer < 0)
            return;

        if(_warningTimer == 0)
        {
            GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
        }

        _warningTimer--;
    }

    public void Destroy()
    {
        if(_isAtracting || _shieldHp > 0)
            return;

        _hp--;
		_damageAnimator.PlayDamageAnimation();

        if(_hp > 0)
            return;

        _state = new Exploding(this);
        GetNode<ShootPoint>("ShootPoint").Active = false;
        GetNode<ShootPoint>("ShootPoint2").Active = false;
        GetNode<ShootPoint>("ShootPoint3").Active = false;
    }

    public bool IsImortal()
    {
        return true;
    }

    internal void OnEnemyDestroyed()
    {
       	_shieldHp--;

		if(_shieldHp == 2)
        {
			GetNode<ShootPoint>("ShootPoint").Active = true;
            GetNode<ShootPoint>("ShootPoint2").Active = true;
            GetNode<ShootPoint>("ShootPoint3").Active = true;
        }

		if(_shieldHp > 0)
			return;

		GetNode<Node2D>("ForceField").QueueFree();
		GetNode<Node2D>("CollisionShape2D2").QueueFree();
		EmitSignal("ShieldDestroyed");

		_state = new MagnectorShootingAndAtractingState(this, _state);

    }

    public void StartAtracting()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Atracting");
        _isAtracting = true;
        GetNode<ShootPoint>("ShootPoint").Active = false;
        GetNode<ShootPoint>("ShootPoint2").Active = false;
        GetNode<ShootPoint>("ShootPoint3").Active = false;
    }

    public void StopAtracting()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("default");
        _isAtracting = false;
        GetNode<ShootPoint>("ShootPoint").Active = true;
        GetNode<ShootPoint>("ShootPoint2").Active = true;
        GetNode<ShootPoint>("ShootPoint3").Active = true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void ShieldDestroyedEventHandler();
}
