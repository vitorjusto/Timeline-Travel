
using Godot;
using Shooter.Source.Managers;

namespace TimelineTravel.Source.ScrensTransitions
{
    public abstract class ScreenTransition
    {
		protected Player _player;
		protected EnemySpawner _enemySpawner;
		protected ProjectileManager _projectileManager;

		protected ScreenTransition()
		{
			_player = Player.GetPlayer();
			_enemySpawner = EnemySpawner.GetEnemySpawner();
			_projectileManager = ProjectileManager.GetManager();

			GameManager.GetManager().BlackScreen.Visible = true;
			GameManager.GetManager().IsBlackScreen = true;
		}

		public void LoadLevel()
		{
			ProcessLoadLevel();

        	AudioManager.Stop();
        	AudioManager.SetTimelineSong(_enemySpawner.CurrentLevel);

			_player.Position = new Vector2(x: 722, y: 720);

			_enemySpawner.RestartLevel();

			_projectileManager.RemoveAllProjectiles();

			Hud.ShowCustomWarning("None");
			PowerUpManager.ClearAllChild();
		}

		protected abstract void ProcessLoadLevel();
    }
}