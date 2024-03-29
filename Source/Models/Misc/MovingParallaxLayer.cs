using Godot;

public partial class MovingParallaxLayer : ParallaxLayer
{
	[Export]
	public float XSpeed;
	[Export]
	public float YSpeed;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.MotionOffset = new Vector2(
    		x: this.MotionOffset.X + XSpeed,
    		y: this.MotionOffset.Y + YSpeed
		);
	}

	public void SetSpeed(float xSpeed, float ySpeed)
	{
		XSpeed = xSpeed;
		YSpeed = ySpeed;
	}
}
