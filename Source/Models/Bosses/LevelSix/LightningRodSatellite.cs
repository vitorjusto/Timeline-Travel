using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.LevelSix.States;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using System;

public partial class LightningRodSatellite : CharacterBody2D, IEnemy
{
	public IState _state;
    public int _hp = 200;

    public override void _Ready()
    {
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
    }
    public override void _PhysicsProcess(double delta)
	{
        if(_state.Process())
            _state = _state.NextState();
	}

	public void Destroy()
    {
        _hp--;

        if(_hp == 190)
            _state = _state.NextState();
        if(_hp == 100)
            _state = _state.NextState();
        
        if(_hp == 0)
            _state = _state.NextState();
        
    }

    public bool IsImortal()
    {
        return true;
    }
}



