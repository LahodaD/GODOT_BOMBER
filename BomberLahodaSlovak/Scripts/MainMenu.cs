using Godot;
using System;

public partial class MainMenu : ColorRect
{
	public void PlayGame() {
		GetTree().ChangeSceneToFile($"res://Scene/game.tscn");
	}
	
	public void ExitGame() {
		GetTree().Quit();
	}
}
