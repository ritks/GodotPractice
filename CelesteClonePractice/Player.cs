using Godot;

public partial class Player : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public Vector2 ScreenSize;
	public int Speed { get; set; } = 400;
	private const float Gravity = 200.0f;	public const float JUMPSPEED = 30f; 
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// var velocity = Vector2.Zero;
		// // jumping and horiztonal movement	
		// if (Input.IsActionPressed("move_right"))
		// {
		// 	velocity.X += 1;
		// }

		// if (Input.IsActionPressed("move_left"))
		// {
		// 	velocity.X -= 1;
		// }

		// if (Input.IsActionPressed("move_up"))
		// {
		// 	velocity.Y -= JUMP;
		// }
		

		// //Diagonal movement is not allowed so no need for normalization?
		// // if (velocity.Length() > 0)
		// // {
		// // 	velocity = velocity.Normalized() * Speed;
		// // }
		// velocity = MoveAndSlide();
		// Position += velocity * (float)delta;
		// Position = new Vector2(
		// 	x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
		// 	y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		// );


	}

	public override void _PhysicsProcess(double delta)
    {
        // Vector2 velocity = Velocity;

        // // Add the gravity.
        // velocity.Y += GRAVITY * (float)delta;


		// // if (Input.IsActionPressed("move_right"))
		// // 	velocity.X += 1;

		// // if (Input.IsActionPressed("move_left"))
		// // 	velocity.X -= 1;

        // // Handle jump.
        // if (Input.IsActionJustPressed("move_up") && IsOnFloor())
        //     velocity.Y = JUMPSPEED;

        // // Get the input direction.
        // float direction = Input.GetAxis("move_left", "move_right");
        // velocity.X = direction * Speed;

        // Velocity = velocity;
        // MoveAndSlide();

		//Start of manual
		MoveAndCollide(new Vector2(0, 1));
		var velocity = Velocity;
		velocity.Y += (float)delta * Gravity;
        Velocity = velocity;
		var motion = velocity * (float)delta;
        MoveAndCollide(motion);
    }

	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
