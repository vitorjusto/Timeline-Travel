using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Common : CharacterBody2D, IEnemy
{
	public int Speed = 1;
    private DamageAnimationPlayer _damageAnimator;
    public int Hp = 1;

    public override void _Ready()
    {
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
    }

    public override void _Process(double delta)
	{
		MoveEnemy();
		_damageAnimator.Process();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + Speed);
    }

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}

    public void Destroy()
    {
        Hp--;

        if(Hp <= 0)
            EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
        
        _damageAnimator.PlayDamageAnimation();
    }

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}