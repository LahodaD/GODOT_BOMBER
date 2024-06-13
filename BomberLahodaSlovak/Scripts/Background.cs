using Godot;
using System;
using System.Collections.Generic;

public partial class Background : Sprite2D
{
	private int cellSize = 100;
	private int mapWidth = 11 * 100;  // Šířka mapy
	private int mapHeight = 7 * 100;  // Výška mapy
	private RandomNumberGenerator _rng = new RandomNumberGenerator();
	
	private List<Vector2> stoneList = new List<Vector2>();
	private List<Vector2> breakStoneList = new List<Vector2>();
	
	private void GenerateBreakStone(int countOfBreakStone) {
		List<Vector2> freePositions = new List<Vector2>();

		// Find free positions between stones
		for (int row = 0; row < 7 * 2; row++) {
			for (int col = 0; col < 11 * 2; col++) {
				// Check four possible positions around each stone (up, down, left, right)
				Vector2[] possiblePositions = new Vector2[] {
					new Vector2(col * cellSize / 2 + cellSize / 2 - cellSize / 2, row * cellSize / 2 + cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2 - cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2 + cellSize / 2)
				};

				foreach (var pos in possiblePositions) {
					if (!stoneList.Contains(pos) && pos.X >= 0 && pos.Y >= 0 && pos.X < mapWidth && pos.Y < mapHeight) {
						freePositions.Add(pos);
					}
				}
			}
		}

		// Randomly select positions for BreakStones
		for (int i = 0; i < countOfBreakStone; i++) {
			if (freePositions.Count == 0) {
				GD.Print("No more free positions available for BreakStones.");
				break;
			}

			int index = _rng.RandiRange(0, freePositions.Count - 1);
			Vector2 breakStonePos = freePositions[index];
			freePositions.RemoveAt(index);

			breakStoneList.Add(breakStonePos);

			PackedScene breakStoneScene = (PackedScene)ResourceLoader.Load("res://Scene/BreakStone.tscn");
			CharacterBody2D breakStoneItem = (CharacterBody2D)breakStoneScene.Instantiate();
			breakStoneItem.Position = breakStonePos;
			AddChild(breakStoneItem);
		}
	}

	public override void _Ready() {		
		GenerateBreakStone(200); // Generuje 10 rozbitných kamenů		
		Vector2I size = new Vector2I(1250, 850);
        DisplayServer.WindowSetSize(size);		
	}

	public override void _Process(double delta) {
		// Processing each frame if needed
	}
}
