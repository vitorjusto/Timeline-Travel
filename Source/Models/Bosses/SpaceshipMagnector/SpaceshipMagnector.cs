using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipMagnector.States;

public partial class SpaceshipMagnector : Node2D, IEnemy
{
    private EnemySpawner _enemySpawner;
	private IState _state;
    public override void _Ready()
	{
		Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, y: -1000);

		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		_enemySpawner.AddEnemy(new DMacnectOrbiter(ESpawnPosition.Up));
		_enemySpawner.AddEnemy(new DMacnectOrbiter(ESpawnPosition.Down));
		_enemySpawner.AddEnemy(new DMacnectOrbiter(ESpawnPosition.Left));
		_enemySpawner.AddEnemy(new DMacnectOrbiter(ESpawnPosition.Right));
	
		int spawnPosition = (int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 6;

		_enemySpawner.AddEnemy(new DMagnectGenerator(spawnPosition, 0));
		_enemySpawner.AddEnemy(new DMagnectGenerator(spawnPosition * 2, 1));
		_enemySpawner.AddEnemy(new DMagnectGenerator(spawnPosition * 4, 2));
		_enemySpawner.AddEnemy(new DMagnectGenerator(spawnPosition * 5, 3));

		_state = new MagnectorEntreringState(this);
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
			_state = _state.NextState();
	}

    public void Destroy()
    {
        
    }

    public bool IsImortal()
    {
        return true;
    }

}
