using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Levels;
using System;
using System.Collections.Generic;

public partial class FinalStage : Node2D
{
	private int _timer = 0;
    private EnemySpawner _enemyManager;
	
	private IState _state;
    private Node2D _boss;
    private INextStateFinalBoss _nextState;
    private bool _bossDestroing;

    public override void _Ready()
	{
		_enemyManager = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		GetNode<AnimationPlayer>("ParallaxBackground/ParallaxBackground/Panel/AnimationPlayer").Stop();
	}

	public override void _Process(double delta)
	{
		GetNode<AnimationPlayer>("ParallaxBackground/ParallaxBackground/Panel/AnimationPlayer").Play();
		if(_state is not null)
		{
			if(_state.Process() && !_bossDestroing)
			{
                _nextState.OnNextState();
				_boss.QueueFree();
                _bossDestroing = true;
			}
			return;
		}
		_timer++;

		if(_timer > 150)
			AddEnemies();
	}

	private void AddEnemies()
    {
		List<EnemySection> enemies;
		var enemySection = new Random().Next(0, 11);

		if(enemySection == 0)
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
            };
		}else if(enemySection == 1)
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(30, false, new DBomber(100)),
                new EnemySection(30, false, new DBomber(200)),
                new EnemySection(30, false, new DBomber(300)),
                new EnemySection(30, false, new DBomber(400)),
                new EnemySection(30, false, new DBomber(500)),
                new EnemySection(30, false, new DBomber(600)),
                new EnemySection(30, false, new DBomber(700)),
                new EnemySection(30, false, new DBomber(800)),
                new EnemySection(30, false, new DBomber(900)),
                new EnemySection(30, false, new DBomber(1000)),
                new EnemySection(30, false, new DBomber(1100)),
                new EnemySection(30, false, new DBomber(1200)),
                new EnemySection(30, false, new DBomber(1300)),
                new EnemySection(30, false, new DBomber(1400)),
            };
		}else if(enemySection == 2)
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(10, false, new DCommon(100, 5),
											new DCommon(150, 5),
											new DCommon(200, 5),
											new DCommon(250, 5),
											new DCommon(300, 5),
											new DCommon(350, 5),
											new DCommon(400, 5),
											new DCommon(450, 5),
											new DCommon(500, 5),
											new DCommon(550, 5),
											new DCommon(600, 5),
											new DCommon(650, 5),
											new DCommon(700, 5),
											new DCommon(750, 5),
											new DCommon(800, 5),
											new DCommon(850, 5),
											new DCommon(900, 5),
											new DCommon(950, 5),
											new DCommon(1000, 5),
											new DCommon(1050, 5),
											new DCommon(1100, 5),
											new DCommon(1150, 5),
											new DCommon(1200, 5),
											new DCommon(1250, 5),
											new DCommon(1300, 5),
											new DCommon(1350, 5),
											new DCommon(1400, 5)),
            };
		}else if(enemySection == 3)
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(100, false, new DCrusader(100, 5),
											new DCrusader(150, 5),
											new DCrusader(200, 5),
											new DCrusader(250, 5),
											new DCrusader(300, 5),
											new DCrusader(350, 5),
											new DCrusader(400, 5),
											new DCrusader(450, 5),
											new DCrusader(500, 5),
											new DCrusader(800, 5),
											new DCrusader(850, 5),
											new DCrusader(900, 5),
											new DCrusader(950, 5),
											new DCrusader(1000, 5),
											new DCrusader(1050, 5),
											new DCrusader(1100, 5),
											new DCrusader(1150, 5),
											new DCrusader(1200, 5),
											new DCrusader(1250, 5),
											new DCrusader(1300, 5),
											new DCrusader(1350, 5),
											new DCrusader(1400, 5)),

				new EnemySection(10, false, new DCrusader(600, 5),
											new DCrusader(650, 5),
											new DCrusader(700, 5),
											new DCrusader(750, 5))
			};
		}else if(enemySection == 4)
		{
			enemies = new List<EnemySection>()
            {
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
				new EnemySection(10, false, new DDasher(100)),
			};
		}else if(enemySection == 5)
		{
			enemies = new List<EnemySection>()
            {
				new EnemySection(10, false, new DFollower(100, EEnemyProjectileType.Light),
											new DFollower(500, EEnemyProjectileType.Normal),
											new DFollower(1400, EEnemyProjectileType.Strong)),
			};
		}else if(enemySection == 6)
		{
			enemies = new List<EnemySection>()
            {
				new EnemySection(10, false,
							new DReinforcedCommon(250, 5),
							new DReinforcedCommon(300, 5),
							new DReinforcedCommon(350, 5),
							new DReinforcedCommon(400, 5),
							new DReinforcedCommon(450, 5),
							new DReinforcedCommon(500, 5),
							new DReinforcedCommon(550, 5),
							new DReinforcedCommon(600, 5),
							new DReinforcedCommon(650, 5),
							new DReinforcedCommon(700, 5),
							new DReinforcedCommon(750, 5),
							new DReinforcedCommon(800, 5),
							new DReinforcedCommon(850, 5),
							new DReinforcedCommon(900, 5),
							new DReinforcedCommon(950, 5),
							new DReinforcedCommon(1000, 5),
							new DReinforcedCommon(1050, 5),
							new DReinforcedCommon(1100, 5),
							new DReinforcedCommon(1150, 5),
							new DReinforcedCommon(1200, 5),
							new DReinforcedCommon(1250, 5)),
            };
		}else if(enemySection == 7)
		{
			enemies = new List<EnemySection>()
            {
                new(30, false, new DLazer(100, 200)),
                new(30, false, new DLazer(200, 200)),
                new(30, false, new DLazer(300, 200)),
                new(30, false, new DLazer(400, 200)),
                new(30, false, new DLazer(500, 200)),

                new(30, false, new DLazer(1300, 200)),
                new(30, false, new DLazer(1200, 200)),
                new(30, false, new DLazer(1100, 200)),
                new(30, false, new DLazer(1000, 200)),
                new(30, true, new DLazer(900, 200)),
            };
		}else if(enemySection == 8)
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(40, false,
											new DShoter(100, EEnemyProjectileType.Normal),
											new DShoter(1300, EEnemyProjectileType.Normal)),
            };
		}else if(enemySection == 9)
		{
			enemies = new List<EnemySection>()
            {
            	new EnemySection(20, false, new DSniper(100, EEnemyProjectileType.Light),
							new DSniper(200, EEnemyProjectileType.Light),
							new DSniper(300, EEnemyProjectileType.Light),
							new DSniper(400, EEnemyProjectileType.Light),
							new DSniper(500, EEnemyProjectileType.Light),
							new DSniper(600, EEnemyProjectileType.Light),
							new DSniper(700, EEnemyProjectileType.Light),
							new DSniper(800, EEnemyProjectileType.Light),
							new DSniper(900, EEnemyProjectileType.Light),
							new DSniper(1000, EEnemyProjectileType.Light),
							new DSniper(1100, EEnemyProjectileType.Light),
							new DSniper(1200, EEnemyProjectileType.Light),
							new DSniper(1300, EEnemyProjectileType.Light),
							new DSniper(1400, EEnemyProjectileType.Light)),
				
				new EnemySection(20, false, new DSniper(100, EEnemyProjectileType.Light),
							new DSniper(200, EEnemyProjectileType.Light),
							new DSniper(300, EEnemyProjectileType.Light),
							new DSniper(400, EEnemyProjectileType.Light),
							new DSniper(500, EEnemyProjectileType.Light),
							new DSniper(600, EEnemyProjectileType.Light),
							new DSniper(700, EEnemyProjectileType.Light),
							new DSniper(800, EEnemyProjectileType.Light),
							new DSniper(900, EEnemyProjectileType.Light),
							new DSniper(1000, EEnemyProjectileType.Light),
							new DSniper(1100, EEnemyProjectileType.Light),
							new DSniper(1200, EEnemyProjectileType.Light),
							new DSniper(1300, EEnemyProjectileType.Light),
							new DSniper(1400, EEnemyProjectileType.Light)),
				
				new EnemySection(20, false, new DSniper(100, EEnemyProjectileType.Light),
							new DSniper(200, EEnemyProjectileType.Light),
							new DSniper(300, EEnemyProjectileType.Light),
							new DSniper(400, EEnemyProjectileType.Light),
							new DSniper(500, EEnemyProjectileType.Light),
							new DSniper(600, EEnemyProjectileType.Light),
							new DSniper(700, EEnemyProjectileType.Light),
							new DSniper(800, EEnemyProjectileType.Light),
							new DSniper(900, EEnemyProjectileType.Light),
							new DSniper(1000, EEnemyProjectileType.Light),
							new DSniper(1100, EEnemyProjectileType.Light),
							new DSniper(1200, EEnemyProjectileType.Light),
							new DSniper(1300, EEnemyProjectileType.Light),
							new DSniper(1400, EEnemyProjectileType.Light)),
            };
		}else if(enemySection == 9)
		{			
			enemies = new List<EnemySection>()
            {
                new EnemySection(20, false, new DSpread(100, EEnemyProjectileType.Normal), new DSpread(1400, EEnemyProjectileType.Normal)),
                new EnemySection(20, false, new DSpread(200, EEnemyProjectileType.Normal), new DSpread(1300, EEnemyProjectileType.Normal)),
                new EnemySection(20, false, new DSpread(300, EEnemyProjectileType.Normal), new DSpread(1200, EEnemyProjectileType.Normal)),
                new EnemySection(20, false, new DSpread(400, EEnemyProjectileType.Normal), new DSpread(1100, EEnemyProjectileType.Normal)),
                new EnemySection(20, false, new DSpread(500, EEnemyProjectileType.Normal), new DSpread(1000, EEnemyProjectileType.Normal)),
                new EnemySection(20, false, new DSpread(600, EEnemyProjectileType.Normal), new DSpread(900, EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSpread(700, EEnemyProjectileType.Normal), new DSpread(800, EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSpreader(700, EEnemyProjectileType.Light), new DSpreader(800, EEnemyProjectileType.Light)),
            };
		}else if(enemySection == 10)
		{			
			enemies = new List<EnemySection>()
            {
                new EnemySection(20, false, new DStomper(100)),
                new EnemySection(20, false, new DStomper(1400)),
                new EnemySection(20, false, new DStomper(100)),
                new EnemySection(20, false, new DStomper(1400)),
                new EnemySection(20, false, new DStomper(100)),
                
			};
		}else
		{
			enemies = new List<EnemySection>()
            {
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                new EnemySection(10, false, new DSurpriser()),
                
			};
		}
		_enemyManager.AddEnemySection(enemies);
		_enemyManager.GetNextSection();

		_timer = 0;
    }

	public void OnCoreDestroyed(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: false);
		_boss = node;
		_enemyManager.RemoveAllEnemies();

	}

    public void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }

}