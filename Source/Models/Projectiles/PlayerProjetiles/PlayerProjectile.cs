using Godot;
using Shooter.Source.Interfaces;

public partial class PlayerProjectile : Area2D
{
	private int _ySpeed = -20;
	private int _xSpeed = 0;
    private Player _player;

    public override void _Ready()
	{
		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(x: _xSpeed, y: _ySpeed) * (float)(delta * 60);
	}

	public void SetPosition(float x, float y)
	{
		Position = new Vector2(x, y);
	}

	public void SetSpeed(int xSpeed, int ySpeed)
	{
		_ySpeed = ySpeed;
		_xSpeed = xSpeed;
	}

	public void OnScreenExited()
	{
		QueueFree();
	}

	public void OnBodyEntered(Node2D node)
	{
		if(node is IEnemy)
		{
			var enemy = (IEnemy)node;

			enemy.Destroy();

			if(!enemy.IsImortal() && !_player.GetFinalPowerUp)
				GetTree().Root.GetNode<PowerUpManager>("/root/Main/PowerUpManager").AddEnemyDefeated(enemy);
			
			QueueFree();

		}
	}
}
