using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class SpaceScrap : CharacterBody2D, IEnemy
{

	public float XSpeed;
	public float YSpeed;
    public override void _PhysicsProcess(double delta)
	{
		Position += new Vector2(XSpeed, YSpeed);
	}

    public void OnScreenExited()
    {
        Destroy();
    }

	public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemySpawner.RemoveEnemy(this);
    }

    public bool IsImortal()
    {
        return false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}
