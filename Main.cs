using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Main : Node
{
	[Export]
	public int zombieCount { get; set;} = 3;

	private Area2D player;
	private List<Node2D> zombies;
	private Camera2D camera;
	private Timer spawnTimer;
	private PackedScene zombieScene;
	private int zombiesActive;
	
	private void startGame() 
	{
		spawnZombie();
	}

	private void spawnZombie()
	{
		// Create new Zombie instance, then add to end of list
		var zombieInstance = zombieScene.Instantiate();
		AddChild(zombieInstance);
		Node2D zombieNode = zombieInstance as Node2D;
		zombies.Add(zombieNode);

		// Set random spawn location of the newly created Zombie
		int distance = GD.RandRange(200, 400);
		float angle = GD.Randf() * 2 * Mathf.Pi;
		Vector2 spawnOffset = Vector2.FromAngle(angle) * distance;
		zombieNode.Position = player.Position + spawnOffset;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Area2D>("Player");
		camera = GetNode<Camera2D>("Camera2D");
		zombies = [];
		spawnTimer = GetNode<Timer>("SpawnTimer");
		zombieScene = GD.Load<PackedScene>("res://zombie/zombie.tscn");
		zombiesActive = 0;

		startGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		camera.Position = player.Position;
		Transform2D viewportPosition = new Transform2D();
		viewportPosition.Origin = camera.Position;
		GetViewport().CanvasTransform = viewportPosition;
	}
}
