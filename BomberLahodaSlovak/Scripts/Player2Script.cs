using Godot;
using System;
using System.Collections.Generic;

public partial class Player2Script : CharacterBody2D
{
	
	private Background Back;
	private PlayerScript enemy;
	
	[Export]
	public int Speed { get; set; } = 400;
	
	[Export]
	public int PlayerIndex {get; set; } = 0;
	
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
	private bool makeBomb = true;

	public void GetInput()
	{
		
		Vector2 inputDirection = Input.GetVector("left2", "right2", "up2", "down2");
		Velocity = inputDirection * Speed;
		
		if (Input.IsActionJustPressed("putBomb2") && makeBomb) {
			bombPosition = CreateBaseBomb();
			isPutBomb = true;
			makeBomb = false;
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
		
		GetNode<Timer>("Timer2").Start();
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
	
	private void _on_timer_2_timeout()
	{
		GD.Print("asodifjoviasjdvi");
		
		if (bombItem != null)
		{
			bombItem.QueueFree();
			baseBombItem.QueueFree();
			
			Explosion(bombPosition);
			
			GetNode<Timer>("Timer2").Stop();
		}
	}	
	
	private void _on_explosion_timer_2_timeout()
	{
		GD.Print("asodifjoviasjdvi");
		if (verExpl != null && !verExpl.IsQueuedForDeletion())
		{
			verExpl.QueueFree();
			verExpl = null;
			GD.Print("verE");
		}
		if (horExpl != null && !horExpl.IsQueuedForDeletion())
		{
			horExpl.QueueFree();
			horExpl = null;
			GD.Print("horE");
		}
		if (mainExpl != null && !mainExpl.IsQueuedForDeletion())
		{
			mainExpl.QueueFree();
			mainExpl = null;
			GD.Print("mainE");
		}
		if (verExpl2 != null && !verExpl2.IsQueuedForDeletion())
		{
			verExpl2.QueueFree();
			verExpl2 = null;
			GD.Print("verE2");
		}
		if (horExpl2 != null && !horExpl2.IsQueuedForDeletion())
		{
			horExpl2.QueueFree();
			horExpl2 = null;
			GD.Print("horE2");
		}
		
		Vector2 bombPos = bombPosition;
		Vector2 newVec = new Vector2(0,0);
		
		newVec = new Vector2(bombPos.X + 50, bombPos.Y);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		} 
		
		newVec = new Vector2(bombPos.X - 50, bombPos.Y);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}
		
		
		
		newVec = new Vector2(bombPos.X, bombPos.Y + 50);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}
		
		newVec = new Vector2(bombPos.X, bombPos.Y - 50);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}
		
		GetNode<Timer>("explosionTimer2").Stop();
	}
	
	private void Explosion(Vector2 bombPos) {
		Vector2 newVec = new Vector2(0,0);
		List<Vector2> v = new List<Vector2>();
		
		PackedScene exScene = (PackedScene)ResourceLoader.Load("res://Scene/explosionScene.tscn");
		mainExpl = (Sprite2D)exScene.Instantiate();
		mainExpl.Position = bombPos;
		Owner.AddChild(mainExpl);
		
		PackedScene exHorScene = (PackedScene)ResourceLoader.Load("res://Scene/horizontalExplosion.tscn");
		newVec = new Vector2(bombPos.X + 50, bombPos.Y);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			horExpl = (Sprite2D)exHorScene.Instantiate();
			horExpl.Position = newVec;
			Owner.AddChild(horExpl);
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		} else {
			newVec.X -= 25;
			newVec.Y -= 25;
			v.Add(newVec);
		}
		
		newVec = new Vector2(bombPos.X - 50, bombPos.Y);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			horExpl2 = (Sprite2D)exHorScene.Instantiate();
			horExpl2.Position = newVec;
			Owner.AddChild(horExpl2);
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}else {
			newVec.X -= 25;
			newVec.Y -= 25;
			v.Add(newVec);
		}
		
		
		PackedScene exVerScene = (PackedScene)ResourceLoader.Load("res://Scene/verticalExplosion.tscn");
		newVec = new Vector2(bombPos.X, bombPos.Y + 50);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			verExpl = (Sprite2D)exVerScene.Instantiate();
			verExpl.Position = newVec;
			Owner.AddChild(verExpl);
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}else {
			newVec.X -= 25;
			newVec.Y -= 25;
			v.Add(newVec);
		}
		
		newVec = new Vector2(bombPos.X, bombPos.Y - 50);
		if (!IsStoneCollision(newVec) && !IsBreakStoneCollision(newVec)) {
			verExpl2 = (Sprite2D)exVerScene.Instantiate();
			verExpl2.Position = newVec;
			Owner.AddChild(verExpl2);
			IsPleyer2Death(newVec);
			enemy.IsPleyer1Death(newVec);
		}else {
			newVec.X -= 25;
			newVec.Y -= 25;
			v.Add(newVec);
		}
		
		
		
		GetNode<Timer>("explosionTimer2").Start();
		
		makeBomb = true;
	}
	
	public bool IsStoneCollision(Vector2 pos) {
		pos.X -= 25;
		pos.Y -= 25;
		
		bool tmp = Back.getStoneList().Contains(pos);
		GD.Print("Je zasahnuto Stone ? ");
		GD.Print(tmp);
		return tmp;
	}
	
	public bool IsBreakStoneCollision(Vector2 pos) {
		pos.X -= 25;
		pos.Y -= 25;
		
		bool tmp = Back.getBreakStoneList().Contains(pos);
		GD.Print(pos);
		GD.Print("Je zasahnuto breakStone ?");
		GD.Print(tmp);
		
		Back.DestroySpriteAtPosition(pos);
		
		return tmp;
	}
	
	public bool IsPleyer2Death(Vector2 bombPos) {
		Rect2 explosionArea = new Rect2(bombPos - new Vector2(25, 25), new Vector2(50, 50));
		if (explosionArea.HasPoint(Position))
		{
			GetTree().ChangeSceneToFile($"res://Scene/GameOverWinOne.tscn");
			return true;
		}
		return false;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
	
	public override void _Ready()
	{
		// Zajistěte, aby se správně našel uzel s PlayerScript
		Back = GetNode<Background>("/root/Game/Background"); // upravte cestu podle vaší scény
		enemy = GetNode<PlayerScript>("/root/Game/Player");
	}
}






