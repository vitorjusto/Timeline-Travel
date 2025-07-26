using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Enemies.EnemiesPart;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Lighting : Node2D, IEnemy, INonExplodable
    {
        private float _time = 0;
        private float _warningTimer = 0;
        private bool _isWarning = true;
    
        public override void _Process(double delta)
        {
            if (_isWarning)
                MakeWarning(delta);
            else
                MakeLightning();

            _time += (float)(delta * 60);
        }

        private void MakeWarning(double delta)
        {
            _warningTimer += (float)(delta * 60);

            if (_warningTimer >= 7)
            {
                if (Visible)
                    Hide();
                else
                    Show();

                _warningTimer = 0;
            }

            if (_time >= 100)
            {
                AudioManager.OnLighting();
                _isWarning = false;
                _time = -1;
            }
        }

        private void MakeLightning()
        {

            var enemySpawner = EnemySpawner.GetEnemySpawner();
            enemySpawner.AddEnemy(new DLightningPart(Position.X, _time * 320));

            if (_time > 4)
            {
                enemySpawner.RemoveEnemy(this);
            }

        }

        public bool IsImortal()
        {
            return false;
        }


        public void Destroy()
        {
            EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
        }

        public EnemyBoundy GetBoundy()
        {
            return new();
        }
    }

}
