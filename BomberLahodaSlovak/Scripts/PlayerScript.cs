using Godot;
using System;

public partial class PlayerScript : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400;
	
	[Export]
	public int PlayerIndex { get; set; } = 0;
	
	[Export]
	public Vector2 InputVelocity = new Vector2(0,0);
	
	private Vector2 bombPosition = new Vector2(0,0);
	public int countOfBomb = 1;
	
	private CharacterBody2D bombItem;
	private Sprite2D baseBombItem;
	private Sprite2D mainExpl;
	private Sprite2D horExpl;
	private Sprite2D verExpl;
	private Sprite2D horExpl2;
	private Sprite2D verExpl2;
	
	private bool isPutBomb = false;

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
		
		if (Input.IsActionJustPressed("putBomb")) {
			bombPosition = CreateBaseBomb();
			isPutBomb = true;
		}
		if ((Position.X >= bombPosition.X + 25
			|| Position.X <= bombPosition.X - 25
			|| Position.Y >= bombPosition.Y + 25
			|| Position.Y <= bombPosition.Y - 25)
			&& isPutBomb) {
				GD.Print("vytváří bombu");
				CreateBomb(bombPosition);
				isPutBomb = false;
			}
	}
	
	private void CreateBomb(Vector2 pos) {
		PackedScene bombScene = (PackedScene)ResourceLoader.Load("res://Scene/bomb.tscn");
		bombItem = (CharacterBody2D)bombScene.Instantiate();
		bombItem.Position = pos;
		Owner.AddChild(bombItem);
		
		GetNode<Timer>("Timer").Start();
	}
	
	private Vector2 CreateBaseBomb()
	{
		PackedScene bombScene = (PackedScene)ResourceLoader.Load("res://Scene/baseBomb.tscn");
		baseBombItem = (Sprite2D)bombScene.Instantiate();
		
		// Adjust the position to fit the grid
		Vector2 gridPosition = new Vector2(
			Mathf.Round((Position.X - 25) / 50) * 50 + 25,
			Mathf.Round((Position.Y - 25) / 50) * 50 + 25
		);

		baseBombItem.Position = gridPosition;
		Owner.AddChild(baseBombItem);
		return gridPosition;
	}
	
	public void OnBombTimerTimeout()
	{
		GD.Print("asodifjoviasjdvi");
		if (bombItem != null)
		{
			bombItem.QueueFree();
			baseBombItem.QueueFree();
			
			Explosion(bombPosition);
			
			GetNode<Timer>("Timer").Stop();
		}
	}
	
	public void OnExplTimerTimeout()
	{
		GD.Print("asodifjoviasjdvi");
		if (verExpl != null)
		{
			verExpl.QueueFree();
			horExpl.QueueFree();
			verExpl2.QueueFree();
			horExpl2.QueueFree();
			mainExpl.QueueFree();
			GetNode<Timer>("explosionTimer").Stop();
		}
	}
	
	private void Explosion(Vector2 bombPos) {
		Vector2 newVec = new Vector2(0,0);
		
		PackedScene exScene = (PackedScene)ResourceLoader.Load("res://Scene/explosionScene.tscn");
		mainExpl = (Sprite2D)exScene.Instantiate();
		mainExpl.Position = bombPos;
		Owner.AddChild(mainExpl);
		
		PackedScene exHorScene = (PackedScene)ResourceLoader.Load("res://Scene/horizontalExplosion.tscn");
		horExpl = (Sprite2D)exHorScene.Instantiate();
		newVec = new Vector2(bombPos.X + 50, bombPos.Y);
		horExpl.Position = newVec;
		Owner.AddChild(horExpl);
		
		horExpl2 = (Sprite2D)exHorScene.Instantiate();
		newVec = new Vector2(bombPos.X - 50, bombPos.Y);
		horExpl2.Position = newVec;
		Owner.AddChild(horExpl2);
		
		PackedScene exVerScene = (PackedScene)ResourceLoader.Load("res://Scene/verticalExplosion.tscn");
		verExpl = (Sprite2D)exVerScene.Instantiate();
		newVec = new Vector2(bombPos.X, bombPos.Y + 50);
		verExpl.Position = newVec;
		Owner.AddChild(verExpl);
		
		verExpl2 = (Sprite2D)exVerScene.Instantiate();
		newVec = new Vector2(bombPos.X, bombPos.Y - 50);
		verExpl2.Position = newVec;
		Owner.AddChild(verExpl2);
		
		GetNode<Timer>("explosionTimer").Start();
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
