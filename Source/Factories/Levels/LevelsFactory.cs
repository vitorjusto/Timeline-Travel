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

    }
}