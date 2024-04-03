using Godot;
// using System;

public partial class Player : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public Vector2 ScreenSize;
	public int Speed { get; set; } = 400;
	private const float Gravity = 980.0f;
	private const int WalkMaxSpeed = 5000;
	private const int WalkForce = 7500;
	private const int StopForce = 2000;
	private const int JumpSpeed = 4000;
	private const int DashSpeed = 3500;
	bool canDash = true;
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _PhysicsProcess(double delta)
	{

		//Basic velocity and movement
		var velocity = Vector2.Zero;
		var walk = WalkForce * Input.GetAxis("move_left", "move_right");

		if (Mathf.Abs(walk) < WalkForce * 0.2)
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, StopForce * (float)delta);
		}
		else
		{
			velocity.X += walk * (float)delta;
		}
		velocity.X = Mathf.Clamp(velocity.X, -1 * WalkMaxSpeed, WalkMaxSpeed);

		//Applying gravity at every frame
		velocity.Y += (float)delta * Gravity * 5;

		//Checking if on floor to jump
		if (IsOnFloor() && Input.IsActionJustPressed("move_up"))
		{
			velocity.Y = -JumpSpeed;
		}

		//Making dash mechanic
		// bool canDash = true;
		if (canDash && Input.IsActionPressed("move_right") && Input.IsActionJustPressed("dash"))
		{
			velocity.X += DashSpeed;
			canDash = false;

		}
		if (canDash && Input.IsActionPressed("move_left") && Input.IsActionJustPressed("dash"))
		{
			velocity.X -= DashSpeed;
			canDash = false;

		}

		// NEED TO TEST DASHING UP WIHTOUT DIAGONAL MOVEMENT YET
		if (canDash && Input.IsActionPressed("move_right")
			&& Input.IsActionPressed("move_up") && Input.IsActionJustPressed("dash"))
		{
			velocity.X += DashSpeed;
			velocity.Y -= DashSpeed;
			velocity += velocity.Normalized() * DashSpeed;

			canDash = false;

		}

		// if (canDash && Input.IsActionPressed("move_up") && Input.IsActionJustPressed("dash"))
		// {
		// 	velocity.Y -= DashSpeed;
		// 	canDash = false;
		// }


		if (IsOnFloor())
			canDash = true;


		Velocity = velocity;
		MoveAndSlide();

	}

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
