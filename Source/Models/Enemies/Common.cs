using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Common : CharacterBody2D, IEnemy
{
	public int Speed = 1;

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + Speed);
    }

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}

    public void Destroy()
    {
        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
    }

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}