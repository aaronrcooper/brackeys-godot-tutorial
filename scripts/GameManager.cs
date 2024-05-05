using Godot;
using System;

public partial class GameManager : Node
{
	public int Score { get; set; } = 0;
	public Label ScoreLabel { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreLabel = GetNode<Label>("ScoreLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddPoint() {
		Score +=1;
		ScoreLabel.Text = $"You have collected {Score} coins!";
	}
}
