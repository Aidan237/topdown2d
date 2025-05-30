using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 200;
	public int maxHealth { get; set; } = 100;
	
	public Vector2 ScreenSize;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Player Movement
		
		Vector2 velocity = Vector2.Zero;
		
		if(Input.IsActionPressed("move_left")) {
			velocity.X -= 1;
		}
		if(Input.IsActionPressed("move_right")) {
			velocity.X += 1;
		}
		if(Input.IsActionPressed("move_down")) {
			velocity.Y += 1;
		}
		if(Input.IsActionPressed("move_up")) {
			velocity.Y -= 1;
		}
		
		velocity *= Speed;  // velocity is normalized, speed = magnitide
		
		Position += velocity * (float)delta;

		// Player Direction

		Vector2 mousePos = GetViewport().GetMousePosition();

		Rotation = (mousePos - Position).Angle();
	}
}
