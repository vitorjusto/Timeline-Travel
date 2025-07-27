using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelEight.States;
using Shooter.Source.Models.Misc;

public partial class BlackholeGeneratorV2 : Node2D, IEnemy, ICustomBossPosition
{
	public IState State;
	private int _armHp = 2;
	private int _hp = GameManager.IsSpecialMode? 300: 100;
	private DamageAnimationPlayer _damageAnimator;
	public override void _Ready()
	{
		this.Position = new Vector2(722, -200);
		State = new EnteringState(this);

		GetNode<BlackholeGeneratorV2Part>("BlackholeGeneratorV2Part").Boss = this;
		GetNode<BlackholeGeneratorV2Part>("BlackholeGeneratorV2Part2").Boss = this;

		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}
    public override void _Process(double delta)
	{
		if(State.Process(delta))
		{
			State = State.NextState();
			if(State is null)
				SetBlackholeState();
		}

		_damageAnimator.Process(delta);

	}

    private void SetBlackholeState()
    {
        GetNode<Node2D>("BlackholeAnimation").Visible = true;
		State = new BlackHoleState(this);
    }

    public void Destroy()
    {
        if(_armHp > 0)
			return;

		_hp--;
		if(_hp == 0)
			State.NextState();
		else
			_damageAnimator.PlayDamageAnimation();	

    }

    public bool IsImortal()
    {
        return true;
    }
	
	public void OnPartDestroyed(Node2D node)
	{
		if(node.Position.X > 0)
			GetNode<Node2D>("RightArm").CallDeferred("queue_free");
		else
			GetNode<Node2D>("LeftArm").CallDeferred("queue_free");

		var enemiesManager = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemiesManager.RemoveEnemy(node);

		enemiesManager.AddExplosion(node.Position + this.Position);

		_armHp--;

		if(_armHp == 0)
		{
			State = State.NextState();
			GetNode<Node2D>("ForceField").Visible = false;
			GetNode<Node2D>("ForceFieldCollision").CallDeferred("queue_free");
		}
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    public Vector2 GetPosition()
    {
        return new Vector2(Position.X, -15);
    }
}
