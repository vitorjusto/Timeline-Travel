using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.Concept.States;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class ConceptHead : CharacterBody2D, IEnemy
{

	private int _hp = 20;
	private bool _forceFieldDestroyed = false;
    private bool _shooting = false;
	public int _time = 0;
    private ProjectileManager _projectiles;
	private IState _state;
    private DamageAnimationPlayer _damageAnimator;
    private AnimatedSprite2D _headSprite;
    public EDashStatus _dashStatus = EDashStatus.NotDashing;

    public override void _Ready()
    {
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		_state = new ConceptMovingState(this);

		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("HeadSprite"));
    }
    public override void _Process(double delta)
	{
		if(_state.Process())
			EmitSignal("OnHeadDestroyed");

		_damageAnimator.Process();

		if(_shooting && _state is not Exploding)
			Shoot();
	}

    private void Shoot()
    {
		if(_time == 250)
		{
			_time = 0;
        	_projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y));
		}

		_time++;
    }

	public void Destroy()
    {
		if(!_forceFieldDestroyed)
			return;
		
		_hp--;
		_damageAnimator.PlayDamageAnimation();
		
		if(_hp == 0)
		{
			_state = new Exploding(this, removeEnemy: false);
		}
    }

    public bool IsImortal()
    	=> true;

	[Signal]
	public delegate void OnHeadDestroyedEventHandler();

	public void OnAllBodyPartDestroyed()
	{
		_state = new ConceptDashingState(this);
		_forceFieldDestroyed = true;

		GetNode<Node2D>("ForceField").CallDeferred("queue_free");
		GetNode<Node2D>("CollisionForceField").CallDeferred("queue_free");
		GetNode<CollisionShape2D>("CollisionHead").SetDeferred("disabled", false);
	}

	public void OnActivateHeadShooting()
		=> _shooting = true;

    public EnemyBoundy GetBoundy()
    	=> new();
}