using Godot;
using Shooter.Source.Interfaces;
using System;

public partial class MovingBlackHole : Node2D, IEnemy
{
    private Player _player;

    public override void _Ready()
	{
		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + 4);

		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - _player.Position.X, Position.Y - _player.Position.Y);

		_player.SetSpeed((float)Math.Sin(angle) * (3), (float)Math.Cos(angle) * (3) );
	}

    public void Destroy()
    {
        
    }

    public bool IsImortal()
    {
        return true;
    }

	public void OnScreenExited()
	{
		var enemiesManager = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemiesManager.RemoveEnemy(this);
	}
}
