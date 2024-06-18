using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.Concept.States;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class ConceptHead : CharacterBody2D, IEnemy
{

	private int _hp = 60;
	private bool _forceFieldDestroyed = false;
	private IState _state;
    private DamageAnimationPlayer _damageAnimator;
    private ShootPoint _shootingPoint;

    public override void _Ready()
    {

		_state = new ConceptMovingState(this);

		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("HeadSprite"));
		_shootingPoint = GetNode<ShootPoint>("ShootPoint");
    }
    public override void _Process(double delta)
	{
		if(_state.Process())
			EmitSignal("OnHeadDestroyed");

		_damageAnimator.Process();
	}

	public void Destroy()
    {
		if(!_forceFieldDestroyed)
			return;
		
		_hp--;
		_damageAnimator.PlayDamageAnimation();
		
		if(_hp == 0)
		{
			_shootingPoint.Active = false;
			_state = new Exploding(this, removeEnemy: false);
			var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

			projectiles.RemoveAllProjectiles();
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
		=> _shootingPoint.Active = true;

    public EnemyBoundy GetBoundy()
    	=> new();
}