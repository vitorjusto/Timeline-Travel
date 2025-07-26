using Godot;
using Shooter.Source.Interfaces;

public class DimentionalStarshipGoingInvisibleState : IState
{
    private Node2D _node;
    private byte _opacity = 250;

    public DimentionalStarshipGoingInvisibleState(Node2D node)
    {
        _node = node;
        MakeInvisible();
    }

    public IState NextState()
    {
        return new DimantionalStarshipMovingState(_node);
    }

    public bool Process(double delta)
    {
        _opacity -= GameManager.IsSpecialMode?(byte)25:(byte)10;
        _node.GetNode<Node2D>("AnimatedSprite2D").Modulate = Color.Color8(255, 255, 255, _opacity);
        _node.GetNode<Node2D>("LevelThreeLight").Modulate = Color.Color8(255, 255, 255, _opacity);

        return _opacity == 0;
    }

    private void MakeInvisible()
    {
        _node.GetNode<Node2D>("AnimatedSprite2D").Modulate = Color.Color8(255, 255, 255, 250);
        _node.GetNode<Node2D>("LevelThreeLight").Modulate = Color.Color8(255, 255, 255, 250);

        _node.GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
        _node.GetNode<CollisionShape2D>("CollisionShape2D2").Disabled = true;
        _node.GetNode<CollisionShape2D>("CollisionShape2D3").Disabled = true;
    }

}