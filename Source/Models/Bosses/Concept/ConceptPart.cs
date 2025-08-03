using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class ConceptPart : CharacterBody2D, IEnemy
{

	private int _hp = GameManager.IsSpecialMode?200:40;
    private int _speed = GameManager.IsSpecialMode?-6:-4;
    private ProjectileManager _projectiles;
    private WaveSpeed _ySpeed;
    private AnimatedSprite2D _aniSprite;
    [Export]
    public int StartWaveSpeedCooldown;
    private DamageAnimationPlayer _damageAnimator;

    public override void _Ready()
    {
        _ySpeed = new WaveSpeed(-2, 10, Position.Y, StartWaveSpeedCooldown);

        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));

        _hp = GetTree().Root.GetNode<Player>("/root/Main/Player").GetFinalPowerUp?200:40;
    }

    public override void _Process(double delta)
	{
        _damageAnimator.Process(delta);
		MoveEnemy(delta);
	}

    private void MoveEnemy(double delta)
    {
        Position = new Vector2(x: Position.X + (_speed * (float)(delta * 60)), y: _ySpeed.Update(delta));

		if(Position.X - 64 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 64 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
        _hp--;
        _damageAnimator.PlayDamageAnimation();

		if(_hp == 0)
		{
			EmitSignal("OnPartDestroyed");
			QueueFree();
            var enemy = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            enemy.AddExplosion(Position);
		}
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
	public delegate void OnPartDestroyedEventHandler();
}
