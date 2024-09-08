using Godot;
using System;

public partial class TitleScreen : Node2D
{
	private Node2D _indicator;
    private bool _makeStartAnimation;
	private int _timer;

    public override void _Ready()
	{
		_indicator = GetNode<Node2D>("Indicator");
	}

	public override void _Process(double delta)
	{
		if(_makeStartAnimation)
		{
			StartAnimation();
			return;
		}
			
		if(GetNode<Node2D>("ControlsScreen").Visible)
		{
			if(Input.IsActionJustPressed("Enter"))
				GetNode<Node2D>("ControlsScreen").Visible = false;
			
			return;
		}

		if(Input.IsActionJustPressed("move_down"))
		{
			_indicator.Position += new Vector2(0, 60);

			if(_indicator.Position.Y > 670)
				_indicator.Position = new Vector2(515, 610);
			
		}else if(Input.IsActionJustPressed("move_up"))
		{
			_indicator.Position -= new Vector2(0, 60);

			if(_indicator.Position.Y < 610)
				_indicator.Position = new Vector2(515, 670);
				
		}else if(Input.IsActionJustPressed("Enter"))
		{
			if(_indicator.Position.Y == 670)
				GetNode<Node2D>("ControlsScreen").Visible = true;
			else if(_indicator.Position.Y == 610)
				_makeStartAnimation = true;
		}

	}

    private void StartAnimation()
    {
		if(_timer % 10 == 0)
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;

		if(_timer == 100)
			GetNode<Panel>("BlackScreen").Visible = true;
		
		if(_timer == 120)
			GetTree().ChangeSceneToFile("res://Scenes/main.tscn");
			
		_timer++;
    }
}
