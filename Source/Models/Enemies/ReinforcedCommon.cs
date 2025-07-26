using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class ReinforcedCommon : CharacterBody2D, IEnemy
    {
        public int Speed = 1;

        public override void _Process(double delta)
            => Position += new Vector2(x: 0, y: Speed * (float)(delta * 60));

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy() { }

        public EnemyBoundy GetBoundy()
            => new();
    }
}