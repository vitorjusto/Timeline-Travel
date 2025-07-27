using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
public partial class FinalAngryCore : Node2D, IEnemy
{

	private int _hp = 420;
	private WaveSpeed _ySpeed;
    private DamageAnimationPlayer _damageAnimator;

	public override void _Ready()
	{
		_ySpeed = new WaveSpeed(-2, 10, Position.Y);
        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D")); 
	}

    public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, _ySpeed.Update(delta));
        _damageAnimator.Process(delta);
	}

	public void Destroy()
    {
        _hp--;

		if(_hp == 0)
			EmitSignal("OnDestroyed", this);
        else if(_hp > 0)
            _damageAnimator.PlayDamageAnimation();
    }

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void OnDestroyedEventHandler(Node2D node);
}