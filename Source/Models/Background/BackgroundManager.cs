using Godot;
using Shooter.Source.Factories.Levels;

public partial class BackgroundManager : Node2D
{
	private Node2D _currentBackground;
	public override void _Ready()
	{
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		_currentBackground = LevelsFactory.GetBackground(enemySpawner.CurrentLevel);

		AddChild(_currentBackground);
	}

	public void SetNewBackgroundLevel(int level)
	{
		_currentBackground.QueueFree();
		_currentBackground = LevelsFactory.GetBackground(level);

		AddChild(_currentBackground);
	}
}
