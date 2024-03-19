using Godot;
using System;

public partial class LeafContainer : Node2D
{
	public int _time = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_time == 20)
			AddLeaf();

		_time++;
	}

    private void AddLeaf()
    {
        var scene = GD.Load<PackedScene>("res://Scenes/Background/Leaf.tscn");

        var instance = (Node2D)scene.Instantiate();
        instance.Position = new Vector2(new Random().Next(30, 3000), -30);

		AddChild(instance);
		_time = 0;
    }
}
