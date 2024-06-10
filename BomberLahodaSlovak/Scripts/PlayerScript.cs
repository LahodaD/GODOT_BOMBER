using Godot;
using System;

public partial class PlayerScript : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
	
	[Export]
	public int PlayerIndex {get; set; } = 0;
	
	[Export]
	public Vector2 InputVelocity = new Vector2(0,0);

	public void GetInput()
	{
		
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
