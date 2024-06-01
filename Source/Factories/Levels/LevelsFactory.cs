using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace Shooter.Source.Factories.Levels
{
    public static class LevelsFactory
    {
        public static Node2D GetBackground(int level)
        {

            if(level == 1)
                return GetLevelOne();
            else if(level == 2)
                return GetLevelTwo();
            else if(level == 3)
                return GetLevelThree();
            else if(level == 4)
                return GetLevelFour();
            else if(level == 5)
                return GetLevelFive();
            else if(level == 6)
                return GetLevelSix();
            else if(level == 7)
                return GetLevelSeven();
            else if(level == 8)
                return GetLevelEight();  
            else if(level == 9)
                return GetLevelNine();      
            else if(level == 10)
                return GetLevelTen(); 

            return null;
        }
        private static Node2D GetLevelOne()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelOne.tscn");

            var instance = (BackgroundLevelOne)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelTwo()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelTwo.tscn");

            var instance = (BackgroundLevelTwo)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelThree()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelThree.tscn");

            var instance = (BackgroundLevelThree)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelFour()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelFour.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelFive()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelFive.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelSix()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelSix.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelSeven()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelSeven2.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelEight()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelEight.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelNine()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelNine.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }

        private static Node2D GetLevelTen()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelTen.tscn");

            var instance = (Node2D)scene.Instantiate();

		    return instance;
        }
    }
}