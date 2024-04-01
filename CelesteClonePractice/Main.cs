using Godot;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var Player = GetNode<Player>("Player");
		var startPosition = GetNode<Marker2D>("StartPosition");
		Player.Start(startPosition.Position);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
}
