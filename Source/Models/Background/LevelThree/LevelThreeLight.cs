using Godot;

public partial class LevelThreeLight : Node2D
{
	public Node2D LightOwner;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		try
		{
			Position = LightOwner.Position;

		}catch
		{
			QueueFree();
		}
	}

	public void ShrinkLight()
	{
		Scale = new Vector2(0.45f, 0.45f);
	}
}
