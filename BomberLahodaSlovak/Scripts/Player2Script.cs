using Godot;
using System;

public partial class Player2Script : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
	
	[Export]
	public int PlayerIndex {get; set; } = 0;
	
	[Export]
	public Vector2 InputVelocity = new Vector2(0,0);

	public void GetInput()
	{
		
		Vector2 inputDirection = Input.GetVector("left2", "right2", "up2", "down2");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
