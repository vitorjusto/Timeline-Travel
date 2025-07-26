using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.LevelSix.States;
using Shooter.Source.Models.Misc;
using System;

public partial class LightningRodSatellite : CharacterBody2D, IEnemy
{
	public IState _state;
    public int _hp;
    private int MaxHp = GameManager.IsSpecialMode?5000:500;
    private DamageAnimationPlayer _damageAnimator;

    public override void _Ready()
    {
        _hp = MaxHp;
        Position = Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, y: -300);
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.AddEnemy(new DLighting(100));
        enemySpawner.AddEnemy(new DLighting(200));
        enemySpawner.AddEnemy(new DLighting(300));
        enemySpawner.AddEnemy(new DLighting(400));
        enemySpawner.AddEnemy(new DLighting(500));
        enemySpawner.AddEnemy(new DLighting(600));
        enemySpawner.AddEnemy(new DLighting(900));
        enemySpawner.AddEnemy(new DLighting(1000));
        enemySpawner.AddEnemy(new DLighting(1100));
        enemySpawner.AddEnemy(new DLighting(1200));
        enemySpawner.AddEnemy(new DLighting(1300));
        enemySpawner.AddEnemy(new DLighting(1400));
        _state = new LightningRodSatelliteEnteringState(this);

        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
    }
    public override void _Process(double delta)
	{
        if(_state.Process(delta))
            _state = _state.NextState();
        
        _damageAnimator.Process();
	}

	public void Destroy()
    {
        if(_hp < 0)
            return;

        _damageAnimator.PlayDamageAnimation();

        _hp--;

        if(_hp == (MaxHp - (GameManager.IsSpecialMode?200:100)))
            _state = _state.NextState();
        if(_hp == (MaxHp  - (GameManager.IsSpecialMode?750:400)))
            _state = _state.NextState();
        
        if(_hp == 0)
        {
            StopShooting();
            _state = _state.NextState();
        }
        
    }

    public void StartShooting()
    {
        GetNode<RegularShootPoint>("RegularShootPoint").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint2").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint3").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint4").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint5").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint6").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint7").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint8").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint9").Active = true;
        GetNode<RegularShootPoint>("RegularShootPoint10").Active = true;
    }

    public void StopShooting()
    {
        GetNode<RegularShootPoint>("RegularShootPoint").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint2").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint3").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint4").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint5").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint6").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint7").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint8").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint9").Active = false;
        GetNode<RegularShootPoint>("RegularShootPoint10").Active = false;
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