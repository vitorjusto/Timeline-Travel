using Godot;
using Shooter.Source.Factories;

public partial class PowerUpManager : Node2D
{
	private int _enemiesDefeated = 0;
	private int _currentCicle = 1;
	private int _maxCicle = 2;

	public void AddEnemyDefeated(Node2D node)
	{
		_enemiesDefeated++;

		if(_enemiesDefeated == 15)
			AddPowerUp(node.Position);
	}

    private void AddPowerUp(Vector2 position)
    {
		if(_currentCicle == 1)
			CallDeferred("add_child",PowerUpFactory.GetPowerUp("BulletUp", position));
		if(_currentCicle == 2)
			CallDeferred("add_child",PowerUpFactory.GetPowerUp("HpUp", position));

		_currentCicle++;

		if(_currentCicle > _maxCicle)
			_currentCicle = 1;
		
		_enemiesDefeated = 0;
    }

	public void ClearAllChild()
	{
		foreach(var node in GetChildren())
		{
			node.QueueFree();
		}
	}
}
