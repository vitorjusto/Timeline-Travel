using Godot;
using Shooter.Source.Factories;
using System;

public partial class PowerUpManager : Node2D
{
	
	private int _enemiesDefeated = 0;
	private int _currentCicle = 1;
	private int _maxCicle = 2;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddEnemyDefeated(Node2D node)
	{
		_enemiesDefeated++;

		if(_enemiesDefeated == 10)
			AddPowerUp(node.Position);
	}

    private void AddPowerUp(Vector2 position)
    {
		if(_currentCicle == 1)
			CallDeferred("add_child",PowerUpFactory.GetPowerUp("HpUp", position));
		if(_currentCicle == 2)
			CallDeferred("add_child",PowerUpFactory.GetPowerUp("BulletUp", position));

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
