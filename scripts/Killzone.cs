using Godot;
using System;

public partial class Killzone : Area2D
{
	public Timer Timer { get; set; }

	public override void _Ready()
	{
		base._Ready();
		Timer = GetNode<Timer>("Timer");
		Timer.Timeout += () =>
		{
			GetTree().ReloadCurrentScene();
			Engine.TimeScale = 1;
		};
	}

	public void _on_body_entered(Node2D body)
	{
		(body as Player).PlayDeathAnimation();

		GD.Print("Dead!");
		
		body.GetNode("CollisionShape2D").QueueFree();
		
		Engine.TimeScale = 0.5;
		
		Timer.Start();
	}
}
