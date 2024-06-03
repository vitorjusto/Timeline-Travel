using Godot;

public partial class FirstStateBase : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	[Signal]
	public delegate void OnFinishedStateEventHandler();

	public void OnFinalPowerUpGet()
	{
		EmitSignal("OnFinishedState");
	}
}
