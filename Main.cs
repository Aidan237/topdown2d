using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node
{
	[Export]
	public int zombieCount { get; set;} = 3;

	private Area2D player;
	private List<Area2D> zombies;
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
		var zombieInstance = zombieScene.Instantiate();
		AddChild(zombieInstance);
		zombies.Add(zombieInstance.GetChild<Area2D>(0));
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Area2D>("Player");
		camera = GetNode<Camera2D>("Camera2D");
		zombies = new List<Area2D>();
		spawnTimer = GetNode<Timer>("SpawnTimer");
		zombieScene = GD.Load<PackedScene>("res://zombie/zombie.tscn");
		zombiesActive = 0;

		startGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		camera.Position = player.Position;
	}
}
