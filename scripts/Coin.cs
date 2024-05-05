using Godot;
using System;
using static Godot.GD;

public partial class Coin : Area2D
{
	public AnimationPlayer AnimationPlayer { get; set; }

	public override void _Ready()
	{
		base._Ready();

		AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	private void _on_body_entered(Node2D body)
	{
		var gameManager = GetNode<GameManager>("%GameManager");
		gameManager.AddPoint();

		Print("+1 coin!");
		AnimationPlayer.Play("pickup");
	}
}
