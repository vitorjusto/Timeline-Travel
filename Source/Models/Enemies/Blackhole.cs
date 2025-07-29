using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Blackhole : CharacterBody2D, IEnemy
    {
        public int Speed = 360;
        private bool _isWhiteHole;
        public void SetBlackholeType(bool isWhiteHole)
        {
            _isWhiteHole = isWhiteHole;

            GetNode<BlackHoleAnimation>("BlackHoleAnimation").UpdateAnimation(_isWhiteHole);
        }

        public void ToggleBlackHoleType()
        {
            SetBlackholeType(!_isWhiteHole);
        }

        public override void _Process(double delta)
        {
            MoveEnemy((float)delta);

            AtractPlayer((float)delta);
        }

        private void MoveEnemy(float delta)
            => Position += new Vector2(0, Speed * (delta * 60));

        private void AtractPlayer(float delta)
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

            player.SetSpeed((float)Math.Sin(angle) * 5 * (_isWhiteHole ? -1 : 1) * delta * 60,
                            (float)Math.Cos(angle) * 5 * (_isWhiteHole ? -1 : 1) * delta * 60);
        }
    
        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy() { }

        public EnemyBoundy GetBoundy()
            => new();
        }
}