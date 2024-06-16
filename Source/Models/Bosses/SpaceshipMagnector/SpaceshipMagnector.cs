using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class SpaceshipMagnector : Node2D, IEnemy
{
    private EnemySpawner _enemySpawner;
	private IState _state;
	private int _shieldHp = 4;
    private bool _isAtracting;
    private int _hp = 20;
    public override void _Ready()
	{
		Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, y: -1000);
		int spawnPosition = (int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 6;

		_state = new MagnectorEntreringState(this);
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
			_state = _state.NextState();
	}

    public void Destroy()
    {
        if(_isAtracting || _shieldHp > 0)
            return;

        _hp--;

        if(_hp == 0)
            _state = new Exploding(this);
    }

    public bool IsImortal()
    {
        return true;
    }

    internal void OnEnemyDestroyed()
    {
       	_shieldHp--;

		if(_shieldHp == 2)
			_state = _state.NextState();

		if(_shieldHp > 0)
			return;

		GetNode<Node2D>("ForceField").QueueFree();
		GetNode<Node2D>("CollisionShape2D2").QueueFree();
		EmitSignal("ShieldDestroyed");

		_state = _state.NextState();

    }

    public void StartAtracting()
    {
        GetNode<Node2D>("AtractingAnimation").Visible = true;
        _isAtracting = true;
    }

    public void StopAtracting()
    {
        GetNode<Node2D>("AtractingAnimation").Visible = false;
        _isAtracting = false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void ShieldDestroyedEventHandler();
}
