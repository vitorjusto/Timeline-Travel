using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public class DimentionalStarshipShootingState : IState
{
    private Node2D _node;
    private Player _player;
    private ProjectileManager _projectiles;
    private int _time;

    public DimentionalStarshipShootingState(Node2D node)
    {
        _node = node;
        _player =  _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
    }


    public IState NextState()
    {
        return new DimentionalStarshipGoingInvisibleState(_node);
    }

    public bool Process(double delta)
    {
        if(_time % 33 == 0)
            Shoot();

        _time++;

        return _time == 99;
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
