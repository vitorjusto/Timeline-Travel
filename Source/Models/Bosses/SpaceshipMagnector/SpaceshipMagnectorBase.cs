using Godot;

public partial class SpaceshipMagnectorBase : Node2D, ICustomBossPosition
{
    public Vector2 GetPosition()
    {        
        return GetNode<Node2D>("SpaceshipMagnector").Position;
    }
}