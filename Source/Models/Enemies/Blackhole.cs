using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Blackhole : CharacterBody2D, IEnemy
{
	public int Speed = 6;
	private bool _isWhiteHole;
	public void SetBlackholeType(bool isWhiteHole)
	{
		_isWhiteHole = isWhiteHole;

		GetNode<BlackHoleAnimation>("BlackHoleAnimation").UpdateAnimation(_isWhiteHole);
	}

    public void ToggleBlackHoleType()
    {
        SetBlackholeType(!_isWhiteHole);
    }

    public override void _Process(double delta)
	{
		MoveEnemy();

		AtractPlayer();
	}

    private void AtractPlayer()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

		player.SetSpeed((float)Math.Sin(angle) * (5) * (_isWhiteHole? -1: 1), (float)Math.Cos(angle) * (5) * (_isWhiteHole? -1: 1));
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

    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
