using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public class DimentionalStarshipShootingState : IState
{
    private readonly Node2D _node;
    private readonly QuickTimer _time = new(102);
    private readonly QuickTimer _shootTimer = new(33);

    public DimentionalStarshipShootingState(Node2D node)
    {
        _node = node;
    }


    public IState NextState()
    {
        return new DimentionalStarshipGoingInvisibleState(_node);
    }

    public bool Process(double delta)
    {
        if(_shootTimer.Process(delta))
            Shoot();

        return _time.Process(delta);
    }

    private void Shoot()
    {
        _node.GetNode<ShootPoint>("ShootPoint").Shoot();
        _node.GetNode<ShootPoint>("ShootPoint2").Shoot();
        _node.GetNode<ShootPoint>("ShootPoint3").Shoot();
        _node.GetNode<ShootPoint>("ShootPoint4").Shoot();
        _node.GetNode<ShootPoint>("ShootPoint5").Shoot();
        _node.GetNode<ShootPoint>("ShootPoint6").Shoot();
    }
}
