using Godot;
using Shooter.Source.Interfaces;

public class DimentionalStarshipGoingVisibleState : IState
{
    private Node2D _node;

    public DimentionalStarshipGoingVisibleState(Node2D node)
    {
        _node = node;
    }

    public IState NextState()
    {
        return new DimentionalStarshipShootingState(_node);
    }

    public bool Process()
    {
        _node.Visible = true;

        _node.GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
        _node.GetNode<CollisionShape2D>("CollisionShape2D2").Disabled = false;
        _node.GetNode<CollisionShape2D>("CollisionShape2D3").Disabled = false;

        return true;
    }
}