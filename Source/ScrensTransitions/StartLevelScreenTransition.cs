using Godot;
using Shooter.Source.Models.Background;

namespace TimelineTravel.Source.ScrensTransitions
{
	public class StartLevelScreenTransition : ScreenTransition
	{
		protected override void ProcessLoadLevel()
		{
			_player.Position = new Vector2(x: 722, y: 720);
			_player.ResetTargetCount();

			_enemySpawner.CurrentLevel += 1;
        	_enemySpawner.CheckpointId = 0;
	
			BackgroundManager.GetManager().SetNewBackgroundLevel(_enemySpawner.CurrentLevel);
		}
	}
}