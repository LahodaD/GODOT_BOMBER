using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
	[Export]
	public int PlayerIndex {get; set; } = 1;

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
