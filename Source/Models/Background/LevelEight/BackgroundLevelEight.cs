using Godot;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Models.Background.LevelEight
{
    public partial class BackgroundLevelEight : Node2D
    {
        public void OnPanelOnColorChange()
        {
            if (!GameManager.IsSpecialMode)
                return;
    
            var enemies = EnemySpawner.GetEnemySpawner().Enemies;
    
            foreach (Node2D enemy in enemies)
            {
                if (enemy is not Blackhole)
                    continue;
    
                try
                {
                    ((Blackhole)enemy).ToggleBlackHoleType();
                }
                catch { }
            }
        }
    }
}

