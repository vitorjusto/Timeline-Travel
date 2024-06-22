using Godot;
using Shooter.Source.Interfaces;

public class DimentionalStarshipGoingInvisibleState : IState
{

    private Node2D _node;

    public DimentionalStarshipGoingInvisibleState(Node2D node)
    {
        _node = node;
    }

    public IState NextState()
    {
        return new DimantionalStarshipMovingState(_node);
    }

    public bool Process()
    {
        MakeInvisible();

        return true;
    }

    private void MakeInvisible()
    {
        _node.Visible = false;
        _node.GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
        _node.GetNode<CollisionShape2D>("CollisionShape2D2").Disabled = true;
        _node.GetNode<CollisionShape2D>("CollisionShape2D3").Disabled = true;
    }

}