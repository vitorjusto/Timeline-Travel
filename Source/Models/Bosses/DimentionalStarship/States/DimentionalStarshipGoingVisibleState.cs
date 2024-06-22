using System;
using Godot;
using Shooter.Source.Interfaces;

public class DimentionalStarshipGoingVisibleState : IState
{
    private Node2D _node;
    private Player _player;
    private bool _playerOnRight => _node.Position.X - _player.Position.X < 0;
    public DimentionalStarshipGoingVisibleState(Node2D node)
    {
        _node = node;
        _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
    }

    public IState NextState()
    {
        return new DimentionalStarshipShootingState(_node);
    }

    public bool Process()
    {
        var animatedSprite = _node.GetNode<Node2D>("AnimatedSprite2D");

        animatedSprite.Visible = true;

        animatedSprite.Scale = GetValuePlayerSide(animatedSprite.Scale);
        animatedSprite.Position = GetValuePlayerSide(animatedSprite.Position);

        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D"));
        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D2"));
        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D3"));

        PositionShootingPoint();

        return true;
    }

    private void PositionShootingPoint()
    {
        _node.GetNode<ShootPoint>("ShootPoint").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint").Position);
        _node.GetNode<ShootPoint>("ShootPoint2").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint2").Position);
        _node.GetNode<ShootPoint>("ShootPoint3").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint3").Position);
        _node.GetNode<ShootPoint>("ShootPoint4").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint4").Position);
        _node.GetNode<ShootPoint>("ShootPoint5").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint5").Position);
        _node.GetNode<ShootPoint>("ShootPoint6").Position = GetValuePlayerSide(_node.GetNode<ShootPoint>("ShootPoint6").Position);
    }

    private void EnableCollision(CollisionShape2D collisionShape2D)
    {
        collisionShape2D.Disabled = false;
        collisionShape2D.Position = GetValuePlayerSide(collisionShape2D.Position);
    }

    private Vector2 GetValuePlayerSide(Vector2 position)
    {
        var x = Math.Abs(position.X) * (_playerOnRight? -1: 1);
        return new Vector2(x, position.Y);
    }

    
}