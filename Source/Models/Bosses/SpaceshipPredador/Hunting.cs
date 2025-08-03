using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses
{
    public class Hunting : IState
    {
        private Node2D _node;
        private Player _player;
        private int _speed = 5;

        private QuickTimer _time = new(100);

        private int _xSpeed;
        private int _ySpeed;

        public Hunting(Node2D node)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return null; 
        }

        public bool Process(double delta)
        {
            _node.Position += new Vector2(0, 15) * (float)(delta * 60);

            if(_time.Process(delta))
                _node.Position = new Vector2(_player.Position.X, - 170);

            return false;
        }

    }
}