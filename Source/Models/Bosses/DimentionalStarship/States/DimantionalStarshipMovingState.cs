using System;
using Godot;
using Shooter.Source.Interfaces;

public class DimantionalStarshipMovingState : IState
{

    private Node2D _node;
    private int _viewPortHeight => (int)ProjectSettings.GetSetting("display/window/size/viewport_height") - 100;
    private int _viewPortWidth => (int)ProjectSettings.GetSetting("display/window/size/viewport_width") - 100;
    private Player _player;
    private int _time;

    public DimantionalStarshipMovingState(Node2D node)
    {
        _node = node;
        _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");

    }

    public IState NextState()
    {
        return new DimentionalStarshipGoingVisibleState(_node);
    }

    public bool Process()
    {
        Move();
        _time++;

        return _time > 100;
    }

    private void Move()
    {
        while(true)
        {
	        var height = new Random().Next(100, _viewPortHeight);
	        var width = new Random().Next(100, _viewPortWidth);

            var diference = Math.Abs(_player.Position.X - width) + Math.Abs(_player.Position.Y - height);

            if(diference > 200)
            {
	            _node.Position = new Vector2(width, height);
                break;
            }
        }

    }

}