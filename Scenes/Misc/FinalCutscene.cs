using Godot;
using System;

public partial class FinalCutscene : Node2D
{
	public override void _Ready()
	{
       if(SaveManager.Data.GameMode == EGameMode.Normal && !SaveManager.Data.SpecialModeUnlocked)
        {
            GD.Print("special mode");
            SaveManager.Data.SpecialModeUnlocked = true;
            SaveManager.Save();
        }else if(SaveManager.Data.GameMode == EGameMode.Special && !SaveManager.Data.BossRushUnlocked)
        {
            GD.Print("boss Rush");
            SaveManager.Data.BossRushUnlocked = true;
            SaveManager.Save();
        }
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
