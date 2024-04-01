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

		//Start of manual
		var velocity = Vector2.Zero;
		var walk = WalkForce * Input.GetAxis("move_left", "move_right");
		
		if(Mathf.Abs(walk) < WalkForce * 0.2){
			velocity.X = Mathf.MoveToward(velocity.X, 0, StopForce * (float)delta);
		}
		else{
			velocity.X += walk * (float)delta;
		}
		velocity.X = Mathf.Clamp(velocity.X, -1 * WalkMaxSpeed, WalkMaxSpeed);

		velocity.Y += (float)delta * Gravity * 5;
		
		if(IsOnFloor() && Input.IsActionJustPressed("move_up")){
			velocity.Y = -JumpSpeed;
		}

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
