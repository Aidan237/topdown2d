using Godot;
using System;

public partial class Zombie : Area2D
{
	[Export]

	public int maxHealth { get; set; } = 100;
	public int speed { get; set; } = 100;

	public int health;
	public int direction;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		health = maxHealth;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
