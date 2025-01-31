using Godot;

public partial class ModeUnclocked : Node2D
{
    private int _timer;
	public override void _Process(double delta)
	{
        _timer++;
        if(_timer > 250)
            GetTree().ChangeSceneToFile("res://Scenes/TitleScreen.tscn");
	}
}
