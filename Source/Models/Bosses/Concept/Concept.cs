using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Concept : Node2D, IEnemy, INonExplodable, ICustomBossPosition
{
	
	private int _speed = -3;
    private bool _isDestroing = false;
    private int _time = 0;

	private int _hp = 3;

	private int _damageAnimation = 0;

    private EnemySpawner _enemySpawner;
    private ConceptHead _conceptHead;
    [Export]
	public bool AutoEndLevel = true;
    private bool _musicStopped;

    public override void _Ready()
	{
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        _conceptHead = GetNode<ConceptHead>("ConceptHead");
	}

    public override void _Process(double delta)
    {
        if(_conceptHead.IsExploding && AutoEndLevel && !_musicStopped)
        {
            
            if(!_enemySpawner.isBossRush)
                AudioManager.Stop();
                
            _musicStopped = true;
        }
    }

	public void Destroy()
	{

	}

	public bool IsImortal()
	{
		return true;
	}

	public void OnConceptPartOnPartDestroyed()
	{
		_hp--;

		if(_hp == 0)
		{
			EmitSignal("OnAllBodyPartDestroyed");
		}else if(_hp == 1)
		{
			EmitSignal("OnActivateHeadShooting");

		}
	}

	public void OnHeadDestroyed()
	{
		EmitSignal("OnConceptDestroyed");
		
		if(AutoEndLevel)
		{
			_enemySpawner.EndLevel();
			_enemySpawner.RemoveEnemy(this);
		}

	}

    public EnemyBoundy GetBoundy()
    {
        return new(); 
    }

    public Vector2 GetPosition()
    {
        return GetNode<Node2D>("ConceptHead").Position;
    }

    [Signal]
	public delegate void OnAllBodyPartDestroyedEventHandler();
	
	[Signal]
	public delegate void OnActivateHeadShootingEventHandler();

	[Signal]
	public delegate void OnConceptDestroyedEventHandler();
}
