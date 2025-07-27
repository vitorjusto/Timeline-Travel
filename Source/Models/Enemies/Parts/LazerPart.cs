using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
namespace Shooter.Source.Models.Enemies.Parts
{

    public partial class LazerPart : CharacterBody2D, IEnemy, INonExplodable
    {
        private QuickTimer _timer = new(200);

        public void SetMaxTimer(int time)
            => _timer = new(time);
        public override void _Process(double delta)
        {
            if (_timer.Process(delta))
                EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
        }

        public bool IsImortal()
            => true;

        public void Destroy()
        { }

        public EnemyBoundy GetBoundy()
            => new();
    }
}