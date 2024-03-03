using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipMagnectorBoss.States.OrbterMagnectorStates;
using Shooter.Source.Models.Misc;

public partial class MacnectOrbiter : CharacterBody2D, IEnemy
{

	public int Speed = 10;
	private bool _isRotating = false;
	public int NotifiersOffScreen = 4;

	[Export]
	public ESpawnPosition SpawnPosition;

	private IState _state;

    public bool OnWall = true;

    public override void _Ready()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		enemySpawner.AddEnemy(this);

		_state = new MagnectorOrbterEntreringState(this);
	}

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		
		if(_state.Process())
			_state = _state.NextState();

    }

	public bool IsImortal()
	{
		return true;
	}


    public void Destroy()
    {

    }

	public void OnScreenExited()
	{
		NotifiersOffScreen++;
		OnWall = NotifiersOffScreen != 0;
	}

	public void OnScreenEntered()
	{
		NotifiersOffScreen--;
	}

	public void OnShieldDestroyed()
	{
		_state = _state.NextState();
	}
}
