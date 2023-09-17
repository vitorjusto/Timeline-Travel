using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shooter.Source.Dumies.Interfaces;
using Godot;

namespace Shooter.Source.Dumies.Enemies
{
    public class DBomber : IEnemyDummy
    {
        private int _x;
        public DBomber(int x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Bomber.tscn");

            var instance = (Bomber)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}