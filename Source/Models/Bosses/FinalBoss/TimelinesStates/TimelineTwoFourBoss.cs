using System;
using Godot;
using Shooter.Source.Dumies.Enemies;

public partial class TimelineTwoFourBoss : Node2D
{
    private int _enemiesSpawned;
    private int _time = 383;
    private int _LabelsTime = 0;
    private EnemySpawner _enemySpawner;
    private Label lbltimeline1;
    private Label lbltimeline2;
    private INextStateFinalBoss _nextState;

    public override void _Ready()
	{
        lbltimeline1 = GetNode<Label>("lblTimeline");
        lbltimeline2 = GetNode<Label>("lblTimeline2");

		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
	}

	public override void _Process(double delta)
	{
        ShowTimelinesLabels();

		if(_enemiesSpawned < 4)
        {
            if(_time > 383)
                AddEnemies();

            _time++;
        }
	}

    private void ShowTimelinesLabels()
    {
        if(_LabelsTime == 200)
        {
            lbltimeline1.Visible = false;
		    lbltimeline2.Visible = false;
            return;

        }

        _LabelsTime++;
			
		if(_LabelsTime < 200)
		{
			if(_LabelsTime % 10 == 0)
            {
				lbltimeline1.Visible = !lbltimeline1.Visible;
				lbltimeline2.Visible = !lbltimeline2.Visible;
            }
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

        _time = 0;
        _enemiesSpawned++;
    }

    public void OnConceptDestroyed()
    {
        _enemySpawner.RemoveAllEnemies();
        _nextState.OnNextState();
        GetNode<Node2D>("Concept").CallDeferred("queue_free");
    }

    public void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
