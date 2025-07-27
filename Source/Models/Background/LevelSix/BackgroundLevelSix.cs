using System;
using Godot;
using Shooter.Source.Models.Misc;

public partial class BackgroundLevelSix : Node2D
{
	private Panel _panel;
    private Node2D _rainDropParallax;
    private PackedScene _dropScene;
    private float _time = 0;
    private readonly QuickTimer _lightingTimer = new(6);
	private int _cycle = 0;
	private bool _lightOn = false;
	private int _lightningCycle = 0;
	private readonly QuickTimer _rainDropTimer = new(1);

    public override void _Ready()
	{
		_panel = GetNode<Panel>("ParallaxBackground/ParallaxLayer2/Panel2");
		_rainDropParallax = GetNode<Node2D>("ParallaxBackground/RainDropParallax");

        _dropScene = GD.Load<PackedScene>("res://Scenes/Background/RainDrop.tscn");
		SetCycle();
	}

    private void SetCycle()
    {
        _cycle = new Random().Next(100, 900);
    }

    public override void _Process(double delta)
	{
		if(_time > _cycle)
			MakeLightning(delta);
		
		if(_rainDropTimer.Process(delta))
		{
			MakeRainDrop();
			MakeRainDrop();
			MakeRainDrop();
		}

		_time+= (float)(delta * 60);
	}

    private void MakeRainDrop()
    {
        var instance = (Node2D)_dropScene.Instantiate();
        instance.Position = new Vector2(new Random().Next(30, 1500), -30);

		_rainDropParallax.AddChild(instance);
    }

    private void MakeLightning(double delta)
    {
        if(!_lightingTimer.Process(delta))
			return;
		
		_lightOn = !_lightOn;
		_panel.Visible = _lightOn;
		_lightningCycle++;

		if(_lightningCycle < 6)
			return;
			
		_time = 0;
        _lightingTimer.Reset();
        _lightningCycle = 0;
		SetCycle();
    }

}
