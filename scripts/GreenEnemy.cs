using Godot;
using System;

public partial class GreenEnemy : Node2D
{
	const float Speed = 60.0f;
	public int Direction { get; set; } = 1;
	public RayCast2D RayCastRight { get; set; }
	public RayCast2D RayCastLeft { get; set; }
	public AnimatedSprite2D Sprite { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		RayCastRight = GetNode<RayCast2D>("RayCastRight");
		Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (RayCastLeft.IsColliding())
		{
			Direction = 1;
			Sprite.FlipH = false;
		}
		if (RayCastRight.IsColliding())
		{
			Direction = -1;
			Sprite.FlipH = true;
		}
		var moveXBy = Direction * Speed * (float)delta;
		Position = new Vector2(Position.X + moveXBy, Position.Y);
	}
}
