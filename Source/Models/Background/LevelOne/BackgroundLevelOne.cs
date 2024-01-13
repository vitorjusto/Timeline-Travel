using Godot;
using System;

public partial class BackgroundLevelOne : Node2D, IBackground
{
	private int _time;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    public void PauseBackground(bool isPaused)
    {

    }

}
