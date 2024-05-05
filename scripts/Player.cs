using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -300.0f;
	public float CoinCount = 0.0f;
	public AnimatedSprite2D PlayerSprite { get; set; }

	public bool IsDead { get; set; }

	public override void _Ready()
	{
		base._Ready();

		PlayerSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Process(double delta)
	{
		if (IsDead)
		{
			PlayDeathAnimation();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (IsDead)
			return;
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) 
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "jump", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			PlayerSprite.Play("run");

			if (direction.X < 0)
			{
				PlayerSprite.FlipH = true;
			}
			else
			{
				PlayerSprite.FlipH = false;
			}

			// Play Animations
			if (!IsOnFloor())
			{
				PlayerSprite.Play("jump");
			}

		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			PlayerSprite?.Play("idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void PlayDeathAnimation()
	{
		// we are alrady dead, skip
		if (IsDead)
			return;
		IsDead = true;

		PlayerSprite.Play("death");
	}
}
