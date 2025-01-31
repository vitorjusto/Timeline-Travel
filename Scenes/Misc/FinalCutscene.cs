using Godot;
using System;

public partial class FinalCutscene : Node2D
{
    public void OnFirstSceneEnded()
    {
        var scene = GD.Load<PackedScene>("res://Scenes/Misc/FinalEndings/FinalEndingScene2.tscn");

        var instance = (Node2D)scene.Instantiate();

        AddChild(instance);

        GetNode("FinalEndingScene").CallDeferred("queue_free");
    }
}
