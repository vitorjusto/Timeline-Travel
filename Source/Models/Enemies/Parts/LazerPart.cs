using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
public partial class LazerPart : CharacterBody2D, IEnemy, INonExplodable
{

	private int _speed = 1;

	private int _time = 0;
	public int MaxTimer = 200; 
    public override void _Process(double delta)
	{
		if(_time > MaxTimer)
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        	enemySpawner.RemoveEnemy(this);
		}
		_time++;
	}

	public bool IsImortal()
	{
		return true;
	}


    public void Destroy()
    {
        
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
