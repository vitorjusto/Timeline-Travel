using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Common : CharacterBody2D, IEnemy
    {
        public int Speed = 1;
        private DamageAnimationPlayer _damageAnimator;
        public int Hp = 1;

        public override void _Ready()
            => _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));

        public override void _Process(double delta)
        {
            MoveEnemy(delta);
            _damageAnimator.Process(delta);
        }

        private void MoveEnemy(double delta)
            => Position += new Vector2(0, y: Speed * (float)(delta * 60));

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy()
        {
            Hp--;

            if (Hp <= 0)
                EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

            _damageAnimator.PlayDamageAnimation();
        }

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 1, bulletPoints: 0, Position);
    }
}
