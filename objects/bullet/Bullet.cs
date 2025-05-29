using Godot;
using System;

public partial class Bullet : Area2D
{
	public Vector2 start, end, velocity;
	public int speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocity = (end - start).Normalized() * speed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += velocity * (float)delta;
	}
}
