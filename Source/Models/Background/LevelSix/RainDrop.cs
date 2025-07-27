using Godot;

public partial class RainDrop : Sprite2D
{
	public override void _Process(double delta)
	{
		Position += new Vector2(- 2, 20) * (float)(delta * 60);

		if(Position.Y > 950)
			QueueFree();
	}

	public void OnScreenExited()
	{
		QueueFree();
	}
}
