using Godot;
using Shooter.Source.Dumies.Enemies.FinalBoss;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class BombThrower : Node2D, IEnemy
{
    private int _hp = 400;
	private int _timer;
    private EnemySpawner _enemySpawner;
    private IState _state;
    private DamageAnimationPlayer _damageAnimator;
    private WaveSpeed _yspeed;

    public void Destroy()
    {
        _hp--;

        if(_hp == 0)
        {
            _state = new Exploding(this, removeEnemy: false);
            _damageAnimator.PlayDefaultAnimation();
            EmitSignal("OnDestroyed");

        }else if(_hp > 0)
        {
            _damageAnimator.PlayDamageAnimation();
        }
    }

    public bool IsImortal()
    {
        return true;
    }

    public override void _Ready()
    {
        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
        _enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        _yspeed = new WaveSpeed(-2, 10, Position.Y);
    } 

    public override void _Process(double delta)
	{
        if(_state is not null)
        {
            if(_state.Process(delta))
            {
                QueueFree();
            }
            
            return;
        }

        _damageAnimator.Process(delta);

        _timer++;

		if(_timer == 60)
        {
            var bombPosition = Position - new Vector2(0, 30);
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, 0));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, 6));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, 3));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, -6));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, -3));

        }else if(_timer == 120)
        {
            var bombPosition = Position - new Vector2(0, 30);

            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, 3));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, 1.5f));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, -3));
            _enemySpawner.AddEnemy(new DGigantBomb(bombPosition, -1.5f));

            _timer = 0;
        }

        Position = new Vector2(Position.X, _yspeed.Update(delta));
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
    public delegate void OnDestroyedEventHandler();
}