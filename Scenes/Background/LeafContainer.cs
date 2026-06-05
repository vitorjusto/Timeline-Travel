using Godot;
using Shooter.Source.Models.Misc;
using System;
using TimelineTravel.Source.Managers;

namespace Shooter.Scenes.Background;
public partial class LeafContainer : Node2D
{
	public QuickTimer _time = new(20);

	public override void _Process(double delta)
	{
		if(_time.Process(delta))
			AddLeaf();
	}

    private void AddLeaf()
    {
		var instance = LoaderManager.GetObjectPool<Node2D>("res://Scenes/Background/Leaf.tscn");
        instance.Position = new Vector2(new Random().Next(30, 3000), -30);

		AddChild(instance);
    }
}
