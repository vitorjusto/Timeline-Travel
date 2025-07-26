using System;
using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteMovingAroundState : IState
    {
        private Node2D _node;
        private LightningRodSatelliteShootingState _state;
        private bool _isMoving;
        private float _stayPosition;
        private int _time;
        private bool _isShowingWarning;

        public LightningRodSatelliteMovingAroundState(LightningRodSatelliteShootingState state, Node2D node)
        {
            _state = state;
            _node = node;
            _stayPosition = _node.Position.X;
        }

        public IState NextState()
        {
            return new LightningRodSatelliteLightningState(_node, this); 
        }

        public bool Process(double delta)
        {
            Move();
            _state.Process(delta);
            return false;
        }

        private void Move()
        {
            if(_isShowingWarning)
                ShowingWarning();
            if(_isMoving)
                ModeNode();
            else
                UpdateTimer();
        }

        private void ShowingWarning()
        {
            if(_time == 0)
            {
                var hud = _node.GetTree().Root.GetNode<Hud>("/root/Main/Hud");
                hud.ShowCustomWarning(_stayPosition < _node.Position.X? "LeftWarning": "RightWarning");
            }else if(_time == 50)
            {
                _isShowingWarning = false;
                _isMoving = true;
                _time = 0;
                _node.GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
            }

        }

        private void ModeNode()
        {
            if(Math.Abs(_node.Position.X - _stayPosition) < 6)
            {
                _isMoving = false;
                _time = 0;
                return;
            }

            if(_node.Position.X - _stayPosition < 0)
                _node.Position = new Vector2(_node.Position.X + 4, _node.Position.Y);
            else
                _node.Position = new Vector2(_node.Position.X - 4, _node.Position.Y);
        }

        private void UpdateTimer()
        {
            _time++;

            if(_time == 100)
                SetStayPosition();
        }

        private void SetStayPosition()
        {
            while(true)
            {
                var value = new Random().Next(400, 700) * (new Random().Next(-1, 1) == 0? 1: -1);
                var newStayPosition = _stayPosition + value;

                if(newStayPosition > 200 && newStayPosition < 1300)
                {
                    _stayPosition += value;
                    break;
                }
            }
            _isShowingWarning = true;
            _time = 0;
        }
    }
}