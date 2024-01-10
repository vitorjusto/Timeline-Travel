using System;
using Godot;

namespace Shooter.Source.Factories.Bosses
{
    public static class BossFactory
    {
        public static Node2D GetBoss(int level)
        {
            if(level == 1)
                return GetBossLevelOne();
            if(level == 2)
                return GetBossLevelTwo();
            
            return null;
        }

        private static Node2D GetBossLevelTwo()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelTwo/Concept.tscn");

            return (Node2D)scene.Instantiate();
        }


        private static Node2D GetBossLevelOne()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BlackHoleGenerator.tscn");

            return (Node2D)scene.Instantiate();
        }
    }
}