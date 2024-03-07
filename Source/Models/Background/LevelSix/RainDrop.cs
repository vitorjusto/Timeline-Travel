using Godot;

public partial class RainDrop : Sprite2D
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X - 2, Position.Y + 20);

		if(Position.Y > 950)
			QueueFree();
	}

	public void OnScreenExited()
	{
		QueueFree();
	}
}
