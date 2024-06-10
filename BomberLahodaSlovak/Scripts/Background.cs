using Godot;
using System;

public partial class Background : Sprite2D
{
	private int cellSize = 100;
	private RandomNumberGenerator _rng = new RandomNumberGenerator();
	
	private System.Collections.Generic.List<Vector2> stoneList = new System.Collections.Generic.List<Vector2>();
	
	
	private Vector2 GenerateRandomPosition() {
		float x = _rng.RandfRange(0, 200);
		float y = _rng.RandfRange(0, 150);
		return new Vector2(x,y);
	}
	
	private void GenerateStone(int countOfStone){
		for(int row = 0; row < 7; row++) {
			for(int col = 0; col < 11; col++) {
				//Vector2 pos = GenerateRandomPosition();
				
				Vector2 pos = new Vector2(col * cellSize + cellSize / 2, row * cellSize + cellSize / 2);
				stoneList.Add(pos);
				
				PackedScene stoneScene = (PackedScene)ResourceLoader.Load("res://Scene/Stone.tscn");
				Panel stoneItem = (Panel)stoneScene.Instantiate();
				stoneItem.Position = (pos);
				AddChild(stoneItem);
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GenerateStone(10);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
