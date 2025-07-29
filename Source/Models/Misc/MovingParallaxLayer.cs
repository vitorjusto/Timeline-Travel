using Godot;

public partial class MovingParallaxLayer : ParallaxLayer
{
	[Export]
	public float XSpeed;
	[Export]
	public float YSpeed;
	public override void _Process(double delta)
	{
		this.MotionOffset = new Vector2(
    		x: this.MotionOffset.X + (XSpeed * (float)(delta * 60)),
    		y: this.MotionOffset.Y + (YSpeed * (float)(delta * 60))
		);
	}

	public void SetSpeed(float xSpeed, float ySpeed)
	{
		XSpeed = xSpeed;
		YSpeed = ySpeed;
	}
}
