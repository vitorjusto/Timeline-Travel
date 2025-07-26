using System.Collections.Generic;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public static class BetaTestEnemy
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(30, false, new DSurpriser(new Vector2(100, 100))),
                new(30, false, new DSurpriser(new Vector2(200, 100))),
                new(30, false, new DSurpriser(new Vector2(300, 100))),
                new(30, false, new DSurpriser(new Vector2(400, 100))),
                new(30, false, new DSurpriser(new Vector2(500, 100))),
                new(30, false, new DSurpriser(new Vector2(600, 100))),
                new(30, false, new DSurpriser(new Vector2(700, 100))),
                new(30, false, new DSurpriser(new Vector2(800, 100))),
                new(30, false, new DSurpriser(new Vector2(900, 100))),
                new(30, false, new DSurpriser(new Vector2(1000, 100))),
                new(30, false, new DSurpriser(new Vector2(1100, 100))),
                new(30, false, new DSurpriser(new Vector2(1200, 100))),
                new(30, false, new DSurpriser(new Vector2(1300, 100))),
                new(30, false, new DSurpriser(new Vector2(1300, 200))),
                new(30, false, new DSurpriser(new Vector2(1300, 300))),
                new(30, false, new DSurpriser(new Vector2(1300, 400))),
                new(30, false, new DSurpriser(new Vector2(1300, 500))),
                new(30, false, new DSurpriser(new Vector2(1300, 600))),
                new(30, false, new DSurpriser(new Vector2(1300, 700))),
                new(30, false, new DSurpriser(new Vector2(1300, 800))),
                new(30, false, new DSurpriser(new Vector2(1200, 800))),
                new(30, false, new DSurpriser(new Vector2(1100, 800))),
                new(30, false, new DSurpriser(new Vector2(1000, 800))),
                new(30, false, new DSurpriser(new Vector2(900, 800))),
                new(30, false, new DSurpriser(new Vector2(800, 800))),
                new(30, false, new DSurpriser(new Vector2(700, 800))),
                new(30, false, new DSurpriser(new Vector2(600, 800))),
                new(30, false, new DSurpriser(new Vector2(500, 800))),
                new(30, false, new DSurpriser(new Vector2(400, 800))),
                new(30, false, new DSurpriser(new Vector2(300, 800))),
                new(30, false, new DSurpriser(new Vector2(200, 800))),
                new(30, false, new DSurpriser(new Vector2(100, 800))),
                new(30, false, new DSurpriser(new Vector2(100, 700))),
                new(30, false, new DSurpriser(new Vector2(100, 600))),
                new(30, false, new DSurpriser(new Vector2(100, 500))),
                new(30, false, new DSurpriser(new Vector2(100, 400))),
                new(30, false, new DSurpriser(new Vector2(100, 300))),
                new(30, false, new DSurpriser(new Vector2(100, 200))),
                new(30, false, new DSurpriser(new Vector2(100, 100))),
            };
        }
    }
}