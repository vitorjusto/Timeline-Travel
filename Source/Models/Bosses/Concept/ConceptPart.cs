using Godot;
using Shooter.Source.Interfaces;
using System;

public partial class ConceptPart : CharacterBody2D, IEnemy
{

	private int _hp = 7;
    private int _speed = -4;

    public override void _Ready()
    {
        Position = new Vector2(x: Position.X + GetViewport().GetWindow().Size.X, y: Position.Y);
    }

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X + _speed, y: Position.Y);

		if(Position.X - 64 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 64 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
        _hp--;

		if(_hp == 0)
		{
			EmitSignal("OnPartDestroyed");
			QueueFree();
		}
    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnPartDestroyedEventHandler();
}
