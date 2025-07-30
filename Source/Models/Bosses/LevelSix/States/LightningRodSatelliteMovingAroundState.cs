using System;
using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteMovingAroundState : IState
    {
        private Node2D _node;
        private LightningRodSatelliteShootingState _state;
        private bool _isMoving;
        private float _stayPosition;
        private QuickTimer _idleTimer = new(100);
        private QuickTimer _warningTimer = new(50);
        private bool _isShowingWarning;
        private bool _warningVisible;

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
            Move(delta);
            _state.Process(delta);
            return false;
        }

        private void Move(double delta)
        {
            if(_isShowingWarning)
                ShowingWarning(delta);
            if(_isMoving)
                ModeNode(delta);
            else
                UpdateTimer(delta);
        }

        private void ShowingWarning(double delta)
        {
            if(!_warningVisible)
            {
                _warningVisible = true;
                var hud = _node.GetTree().Root.GetNode<Hud>("/root/Main/Hud");
                hud.ShowCustomWarning(_stayPosition < _node.Position.X? "LeftWarning": "RightWarning");
            }

            if(_warningTimer.Process(delta))
            {
                _isShowingWarning = false;
                _isMoving = true;
                _warningVisible = false;
                _warningTimer.Reset();
                _node.GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
            }

        }

        private void ModeNode(double delta)
        {
            if(Math.Abs(_node.Position.X - _stayPosition) < 6)
            {
                _isMoving = false;
                return;
            }

            if(_node.Position.X - _stayPosition < 0)
                _node.Position += new Vector2(4, 0) * (float)(delta * 60);
            else
                _node.Position += new Vector2(-4, 0) * (float)(delta * 60);
        }

        private void UpdateTimer(double delta)
        {
            if(_idleTimer.Process(delta))
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
            _idleTimer.Reset();
        }
    }
}