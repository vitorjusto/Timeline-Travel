using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Misc;

public partial class TimelineTwoFourBoss : Node2D
{
    private int _enemiesSpawned;
    private QuickTimer _timer = new(383);
	private QuickTimer _labelTimer = new(200);
	private QuickTimer _labelVisibleTimer = new(10);
    private EnemySpawner _enemySpawner;
    private Label lbltimeline1;
    private Label lbltimeline2;
    private INextStateFinalBoss _nextState;
    private bool _labelsVisible = true;

    public override void _Ready()
	{
        lbltimeline1 = GetNode<Label>("lblTimeline");
        lbltimeline2 = GetNode<Label>("lblTimeline2");

		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
	}

	public override void _Process(double delta)
	{
        if(_labelsVisible)
            ShowTimelinesLabels(delta);

		if(_enemiesSpawned < 4)
        {
            if(_timer.Process(delta))
                AddEnemies();

        }
	}

    private void ShowTimelinesLabels(double delta)
    {
        if(_labelTimer.Process(delta))
        {
            lbltimeline1.Visible = false;
		    lbltimeline2.Visible = false;
            _labelsVisible = false;
            return;
        }

		if(_labelVisibleTimer.Process(delta))
        {
			lbltimeline1.Visible = !lbltimeline1.Visible;
			lbltimeline2.Visible = !lbltimeline2.Visible;
        }
    }

    private void AddEnemies()
    {
        _enemySpawner.AddEnemy(new DWaver(100, 5));
        _enemySpawner.AddEnemy(new DWaver(200, 10));
        _enemySpawner.AddEnemy(new DWaver(300, 15));
        _enemySpawner.AddEnemy(new DWaver(400, 20));
        _enemySpawner.AddEnemy(new DWaver(500, 25));
        _enemySpawner.AddEnemy(new DWaver(600, 30));
        _enemySpawner.AddEnemy(new DWaver(700, 35));
        _enemySpawner.AddEnemy(new DWaver(800, 40));
        _enemySpawner.AddEnemy(new DWaver(900, 45));
        _enemySpawner.AddEnemy(new DWaver(1000, 50));
        _enemySpawner.AddEnemy(new DWaver(1100, 55));
        _enemySpawner.AddEnemy(new DWaver(1200, 60));

        _enemiesSpawned++;
    }

    public void OnConceptDestroyed()
    {
        _enemySpawner.RemoveAllEnemies();
        _nextState.OnNextState();
        _enemiesSpawned = 5;
        GetNode<Node2D>("Concept").CallDeferred("queue_free");
    }

    public void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
