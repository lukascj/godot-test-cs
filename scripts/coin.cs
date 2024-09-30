using Godot;
using System;

public partial class coin : Area2D
{
	// Method triggered when a body enters the coin's area.
	public void _OnBodyEntered(Node2D body)
	{
		GD.Print("+1 coin!");
		QueueFree();
	}
}
