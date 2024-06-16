using Godot;
using Shooter.Source.Dumies.Enemies.FinalBoss;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class BombThrower : Node2D, IEnemy
{
    private int _hp = 100;
	private int _timer;
    private EnemySpawner _enemySpawner;
    private IState _state;

    public void Destroy()
    {
        _hp--;

        if(_hp == 0)
        {
            _state = new Exploding(this, removeEnemy: false);
        }

    }

    public bool IsImortal()
    {
        return true;
    }

    public override void _Ready()
    {
        _enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
    } 

    public override void _Process(double delta)
	{
        if(_state is not null)
        {
            if(_state.Process())
            {
                EmitSignal("OnDestroyed");
                QueueFree();
            }
            
            return;
        }

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
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
    public delegate void OnDestroyedEventHandler();
}
