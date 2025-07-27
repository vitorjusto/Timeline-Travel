using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies.Parts
{
    public partial class LightningPart : CharacterBody2D, IEnemy, INonExplodable
    {
        private readonly QuickTimer _timer = new(10);
        public override void _Ready()
        {
            var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            animation.Play("default");
        }

        public override void _Process(double delta)
        {
            if (_timer.Process(delta))
                EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
        }

        public bool IsImortal()
            => true;

        public void Destroy()
        {}

        public EnemyBoundy GetBoundy()
            => new();
    }
}