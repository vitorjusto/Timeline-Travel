using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.ProjectileShowerState;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class ProjectileShower : Node2D, IEnemy
{
	private IState _state;
	public int Hp = 200;
	public bool IsExploding => _state is Exploding;
	private DamageAnimationPlayer _damageAnimator;
    private int _alreadExplodedCount = 0;
    public int Speed = 6;

	public override void _Ready()
	{
		_state = new ProjectileShowerEntreringState(this);
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("BigBoss"));
	}

	public override void _Process(double delta)
	{
		if(_state.Process(delta))
		{
			_state = _state.NextState();

			if(_state == null && Hp > 0)
				ShowSmallBoss();

		}

		_damageAnimator.Process(delta);
	}

    private void ShowSmallBoss()
    {
        GetNode<Node2D>("SmallBoss").Visible = true;
        GetNode<CollisionShape2D>("SmallBossCollision").Disabled = false;

		GetNode<Node2D>("BigBoss").Visible = false;
        GetNode<CollisionShape2D>("BigBossCollision").Disabled = true;

		_state = new ProjectileShowerRunningAroundState(this);
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("SmallBoss"));
    }

    public void Destroy()
    {
		if(IsExploding)
			return;

        Hp--;

		if(Hp == 30 && _alreadExplodedCount == 0)
			_state = new Exploding(this, new Vector2(650, 200), removeEnemy: false);
		else if(Hp == 0)
		{
			_state = new Exploding(this, 32, !GameManager.IsSpecialMode || _alreadExplodedCount == 4);
			GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").RemoveAllProjectiles();

            if(GameManager.IsSpecialMode)
            {
                _alreadExplodedCount++;
                Hp = 200;
                Speed += 3;
            }
		}
		else
			_damageAnimator.PlayDamageAnimation();
    }

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
