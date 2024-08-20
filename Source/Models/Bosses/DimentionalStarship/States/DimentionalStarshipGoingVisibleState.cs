using System;
using Godot;
using Shooter.Source.Interfaces;

public class DimentionalStarshipGoingVisibleState : IState
{
    private Node2D _node;
    private Player _player;
    private bool _playerOnRight => _node.Position.X - _player.Position.X < 0;
    private byte _opacity;
    public DimentionalStarshipGoingVisibleState(Node2D node)
    {
        _node = node;
        _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        MakeBossVisible();
    }

    public IState NextState()
    {
        return new DimentionalStarshipShootingState(_node);
    }

    public bool Process()
    {
        var animatedSprite = _node.GetNode<Node2D>("AnimatedSprite2D");
        animatedSprite.Modulate = Color.Color8(255, 255, 255, _opacity);

        _node.GetNode<Node2D>("LevelThreeLight").Modulate = Color.Color8(255, 255, 255, _opacity);

        _opacity += 10;

        return _opacity == 250;
    }

    private void MakeBossVisible()
    {
        var animatedSprite = _node.GetNode<Node2D>("AnimatedSprite2D");

        animatedSprite.Visible = true;
        animatedSprite.Modulate = Color.Color8(255, 255, 255, 0);

        animatedSprite.Scale = GetValuePlayerSide(animatedSprite.Scale);
        animatedSprite.Position = GetValuePlayerSide(animatedSprite.Position);

        _node.GetNode<Node2D>("LevelThreeLight").Modulate = Color.Color8(255, 255, 255, _opacity);
        _node.GetNode<Node2D>("LevelThreeLight").Position = GetValuePlayerSide(_node.GetNode<Node2D>("LevelThreeLight").Position);

        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D"));
        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D2"));
        EnableCollision(_node.GetNode<CollisionShape2D>("CollisionShape2D3"));

        PositionShootingPoint();
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