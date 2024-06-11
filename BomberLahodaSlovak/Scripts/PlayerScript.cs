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
		
		if (Input.IsActionJustPressed("putBomb")) {
			CreateBomb();
		}
	}
	
	private void CreateBomb() {
		PackedScene bombScene = (PackedScene)ResourceLoader.Load("res://Scene/bomb.tscn");
		CharacterBody2D bombItem = (CharacterBody2D)bombScene.Instantiate();
		bombItem.Position = Position;
		Owner.AddChild(bombItem);
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
