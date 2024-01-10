using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Curver : CharacterBody2D, IEnemy
{
	private int _speed = 3;
	private WaveSpeed _xSpeed;
	private float _time = 0f;

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x:_xSpeed.Update(), y: Position.Y + _speed);
    }

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}

	public void SetPosition(float x)
	{
		_xSpeed = new WaveSpeed(3, -6, 30, x);
		Position = new Vector2(x, y: -30);
	}

    public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }
}
