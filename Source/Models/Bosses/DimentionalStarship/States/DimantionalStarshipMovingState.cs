using System;
using Godot;
using Shooter.Source.Interfaces;

public class DimantionalStarshipMovingState : IState
{

    private Node2D _node;
    private int _viewPortHeight => (int)ProjectSettings.GetSetting("display/window/size/viewport_height") - 400;
    private int _viewPortWidth => (int)ProjectSettings.GetSetting("display/window/size/viewport_width") - 300;

    private Vector2 _goToPosition;
    private Vector2 _speed;
    private int _speedModifier = GameManager.IsSpecialMode?-10:-6;

    public DimantionalStarshipMovingState(Node2D node)
    {
        _node = node;
        _goToPosition = new Vector2(new Random().Next(200, _viewPortWidth), new Random().Next(100, _viewPortHeight));

        var angle = Math.Atan2(_node.Position.X - _goToPosition.X, _node.Position.Y - _goToPosition.Y);

        _speed = new Vector2((float)Math.Sin(angle) * (_speedModifier), (float)Math.Cos(angle) * (_speedModifier));
    }

    public IState NextState()
    {
        return new DimentionalStarshipGoingVisibleState(_node);
    }

    public bool Process()
    {
        _node.Position += _speed;

        return Math.Abs(_goToPosition.X - _node.Position.X) < 20 && (Math.Abs(_goToPosition.Y- _node.Position.Y) < 20);
    }

}