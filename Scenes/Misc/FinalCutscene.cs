using Godot;
using System;

public partial class FinalCutscene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

    public void OnFirstSceneEnded()
    {
        var scene = GD.Load<PackedScene>("res://Scenes/Misc/FinalEndings/FinalEndingScene2.tscn");

        var instance = (Node2D)scene.Instantiate();

        AddChild(instance);

        GetNode("FinalEndingScene").CallDeferred("queue_free");
    }
}
