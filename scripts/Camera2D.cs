using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{
	public Label ScoreTextNode { get; set; }
	public Player Player { get; set; }
	public GameManager GameManager { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreTextNode = GetNode<Label>("ScoreLabel");
		GameManager = GetNode<GameManager>("%GameManager");
		Player = GetParent<Player>();	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
