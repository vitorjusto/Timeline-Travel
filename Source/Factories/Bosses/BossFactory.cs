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
            if(level == 3)
                return GetBossLevelThree();         
            if(level == 4)
                return GetBossLevelFour();
            if(level == 5)
                return GetBossLevelFive();  
            if(level == 6)
                return GetBossLevelSix();
            if(level == 7)
                return GetBossLevelSeven();
                
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

        private static Node2D GetBossLevelThree()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelThree/DimentionalStarship.tscn");

            return (Node2D)scene.Instantiate();
        }

        private static Node2D GetBossLevelFour()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelFour/SpaceshipPredador.tscn");

            return (Node2D)scene.Instantiate();
        }

        private static Node2D GetBossLevelFive()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelFive/SpaceshipMagnectorBase.tscn");

            return (Node2D)scene.Instantiate();
        }

        private static Node2D GetBossLevelSix()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelSix/LightningRodSatellite.tscn");

            return (Node2D)scene.Instantiate();
        }

        private static Node2D GetBossLevelSeven()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelSeven/SeasoningAdpter.tscn");

            return (Node2D)scene.Instantiate();
        }
    }
}