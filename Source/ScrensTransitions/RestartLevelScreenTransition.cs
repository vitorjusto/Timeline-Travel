using System;

namespace TimelineTravel.Source.ScrensTransitions
{
	public class RestartLevelScreenTransition : ScreenTransition
	{
		protected override void ProcessLoadLevel()
		{
			_player.Hp = 10;
			_player.Life--;

			_player.EmitSignal("PlayerHpUpdated", _player.Hp);
			_player.EmitSignal("PlayerLifeUpdated", _player.Life);
			_player.ResetTargetCount();

        	AudioManager.SetTimelineSong(_enemySpawner.CurrentLevel);

			_projectileManager.PlayerProjectileLevel = 1;
		}
	}
}