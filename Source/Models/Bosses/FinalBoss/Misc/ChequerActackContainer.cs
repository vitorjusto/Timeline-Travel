using Godot;
using System;
using System.Linq;

public partial class ChequerActackContainer : Node2D
{
	private int _timer;
    private ChequerActack _mainNode;

    public bool Active = true;

    public override void _Ready()
	{
		_mainNode = GetNode<ChequerActack>("MainNode");
		SetContainersToChildrens();
	}

    private void SetContainersToChildrens()
    {
        foreach(ChequerActack node in GetChildren())
		{
			node.BaseContainer = this;
		}
    }

    public override void _Process(double delta)
	{
		if(!Active)
			return;
			
		_timer++;

		if(_timer > 50)
		{
			_mainNode.Activate();
			_timer = 0;
		}

	}

	public void OnActivation(Node2D node)
	{
		var nextRow = GetChildren().Select((x) => (ChequerActack)x).Where((x) => x.row == ((ChequerActack)node).row + 1);

		var nextColumn = new Random().Next(0, 2);
		var nextNode = nextRow.FirstOrDefault((x) => x.column == ((ChequerActack)node).column + nextColumn);

		if(nextNode is null)
			return;

		nextNode.Activate();
	}
}
