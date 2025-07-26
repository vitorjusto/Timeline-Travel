using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses
{
    public class Hunting : IState
    {
        private Node2D _node;
        private Player _player;
        private int _speed = 5;

        private int _time = 0;

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
            _node.Position = new Vector2(_node.Position.X, _node.Position.Y + 15);

            if(_time == 100)
            {
                _node.Position = new Vector2(_player.Position.X, - 170);
                _time = 0;
            }

            _time++;

            return false;
        }

    }
}