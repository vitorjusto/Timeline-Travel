using Godot;
using Shooter.Source.Factories;
using Shooter.Source.Interfaces;

public partial class PowerUpManager : Node2D
{
	private int _hpPoints = 0;
	private int _bulletPoints = 0;

    private static PowerUpManager _manager;

    public override void _Ready()
    {
        _manager = this;
    }

	public void AddEnemyDefeated(IEnemy node)
	{
		var boundy = node.GetBoundy();

		_bulletPoints += boundy.BulletPoints;
		_hpPoints += boundy.HpUpPoints;

		if(_bulletPoints > 30)
			AddBulletUp(boundy.Position);

		if(_hpPoints > 60)
			AddHpUp(boundy.Position);
	}

    public static void AddHpUp(Vector2 position)
    {
        _manager.CallDeferred("add_child",PowerUpFactory.GetPowerUp("HpUp", position));
		_manager._hpPoints = 0;
    }

    public static void AddBulletUp(Vector2 position)
    {
        _manager.CallDeferred("add_child",PowerUpFactory.GetPowerUp("BulletUp", position));
		_manager._bulletPoints = 0;
    }

	public void ClearAllChild()
	{
		foreach(var node in GetChildren())
		{
			node.QueueFree();
		}
	}
}
