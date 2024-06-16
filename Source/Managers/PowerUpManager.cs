using Godot;
using Shooter.Source.Factories;
using Shooter.Source.Interfaces;

public partial class PowerUpManager : Node2D
{
	private int _hpPoints = 0;
	private int _bulletPoints = 0;

	public void AddEnemyDefeated(IEnemy node)
	{
		var boundy = node.GetBoundy();

		_bulletPoints += boundy.BulletPoints;
		_hpPoints += boundy.HpUpPoints;

		if(_bulletPoints > 20)
			AddBulletUp(boundy.Position);

		if(_hpPoints > 50)
			AddHpUp(boundy.Position);
	}

    private void AddHpUp(Vector2 position)
    {
        CallDeferred("add_child",PowerUpFactory.GetPowerUp("HpUp", position));
		_hpPoints = 0;
    }

    private void AddBulletUp(Vector2 position)
    {
        CallDeferred("add_child",PowerUpFactory.GetPowerUp("BulletUp", position));
		_bulletPoints = 0;
    }

	public void ClearAllChild()
	{
		foreach(var node in GetChildren())
		{
			node.QueueFree();
		}
	}
}
