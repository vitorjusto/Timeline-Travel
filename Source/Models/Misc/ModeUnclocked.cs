using Godot;

public partial class ModeUnclocked : Node2D
{
    private double _timer;
	public override void _Process(double delta)
	{
        _timer+= delta * 60;
        if(_timer > 250)
            GetTree().ChangeSceneToFile("res://Scenes/TitleScreen.tscn");
	}
}
