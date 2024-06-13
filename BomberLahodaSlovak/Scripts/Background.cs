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

	public List<Vector2> getStoneList() {
		return stoneList;
	}
	
	public List<Vector2> getBreakStoneList() {
		return breakStoneList;
	}

	private void GenerateStone() {
		for (int row = 0; row < 6; row++) {
			for (int col = 0; col < 11; col++) {
				Vector2 pos = new Vector2(col * cellSize + cellSize / 2, row * cellSize + cellSize / 2);
				stoneList.Add(pos);
				
				PackedScene stoneScene = (PackedScene)ResourceLoader.Load("res://Scene/Stone.tscn");
				CharacterBody2D stoneItem = (CharacterBody2D)stoneScene.Instantiate();
				stoneItem.Position = pos;
				AddChild(stoneItem);
			}
		}
	}
	
	private void GenerateBreakStone(int countOfBreakStone) {
		List<Vector2> freePositions = new List<Vector2>();

		// Najdi volné pozice mezi kameny
		for (int row = 0; row < 6 * 2 -1; row++) {
			for (int col = 0; col < 10 * 2 - 1; col++) {
				// Kontrolujeme čtyři možné pozice kolem každého kamene (nahoře, dole, vlevo, vpravo)
				Vector2[] possiblePositions = new Vector2[] {
					new Vector2(col * cellSize / 2 + cellSize / 2 - cellSize / 2, row * cellSize / 2 + cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2 - cellSize / 2),
					new Vector2(col * cellSize / 2 + cellSize / 2, row * cellSize / 2 + cellSize / 2 + cellSize / 2)
				};

				foreach (var pos in possiblePositions) {
				// Zkontroluj, jestli pozice není v levém horním rohu o velikosti 4x4 bloky
				// a jestli není v pravém spodním rohu o velikosti 4x4 bloky
					if (!stoneList.Contains(pos) && pos.X >= 0 && pos.Y >= 0 && pos.X < mapWidth && pos.Y < mapHeight &&
						!(pos.X < 2 * cellSize && pos.Y < 2 * cellSize) && 
						!(pos.X > 1150 - 2 * cellSize && pos.Y > 650 - 2 * cellSize)) {
						freePositions.Add(pos);
					}
				}
			}
		}

		// Náhodně vyber pozice pro BreakStones
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
	public void DestroySpriteAtPosition(Vector2 position)
	{
		foreach (Node child in GetChildren())
		{
			if (child is CharacterBody2D sprite && sprite.Position == position)
			{
				breakStoneList.RemoveAt(breakStoneList.IndexOf(position));
				GD.Print("Dostal jsem se SEM");
				sprite.QueueFree();
				if (sprite.IsQueuedForDeletion())
				{
					GD.Print("Sprite is queued for deletion.");
				}
				else
				{
					GD.Print("Sprite is NOT queued for deletion.");
				}
				
				GD.Print(breakStoneList.Count);
				GD.Print(breakStoneList.IndexOf(position));
				GD.Print(breakStoneList.Count);
				foreach(Vector2 v in breakStoneList) {
					GD.Print(v);
				}
				break;
			}
		}
	}

	public override void _Ready() {
		GenerateStone();
		GenerateBreakStone(120); // Generuje 10 rozbitných kamenů
	}

	public override void _Process(double delta) {
		// Zpracování každý snímek, pokud je potřeba
	}
}
