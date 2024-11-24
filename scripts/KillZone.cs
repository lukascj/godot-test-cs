using Godot;
using System;

public partial class KillZone : Area2D
{
	// Declare a Timer variable.
	private Timer timer;
	
	public override void _Ready()
	{
		// Assign the Timer node using GetNode.
		timer = GetNode<Timer>("Timer");
	}
	private void _OnBodyEntered(Node2D body)
	{
		GD.Print("You died!");
		timer.Start();
	}
	private void _OnTimerTimeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
