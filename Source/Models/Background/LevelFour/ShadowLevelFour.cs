using Godot;
using System;

public partial class ShadowLevelFour : Node2D
{
	public Node2D ShadowOwner {get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		try
		{

			Position = ShadowOwner.Position;
		}catch(Exception)
		{
			QueueFree();
		}
	}

}
