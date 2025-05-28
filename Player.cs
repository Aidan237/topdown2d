using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int speed { get; set; } = 200;
	
	public Vector2 screenSize;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
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
		
		velocity *= speed;  // velocity is normalized, speed = magnitide
		
		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, screenSize.X),
			y: Mathf.Clamp(Position.Y, 0, screenSize.Y)
		);

		// Player Direction

		Vector2 mousePos = GetViewport().GetMousePosition();

		Rotation = (mousePos - Position).Angle();
	}
}
