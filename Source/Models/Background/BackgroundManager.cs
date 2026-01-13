using Godot;
using Shooter.Source.Factories.Levels;
using Shooter.Source.Managers;

public partial class BackgroundManager : Node2D
{
	private static BackgroundManager _manager;
	public static BackgroundManager GetManager()
		=> _manager;

	private Node2D _currentBackground;

	public override void _Ready()
	{
		_manager = this;
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		_currentBackground = LevelsFactory.GetBackground(enemySpawner.CurrentLevel);

		if(_currentBackground is not null)
			AddChild(_currentBackground);
	}

	public void SetNewBackgroundLevel(int level)
	{
		_currentBackground?.QueueFree();
		_currentBackground = LevelsFactory.GetBackground(level);

		AddChild(_currentBackground);
	}
}