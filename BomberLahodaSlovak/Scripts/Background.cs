using Godot;
using System;
using System.Collections.Generic;

public partial class Background : Sprite2D
{
	public override void _Ready() {
		Vector2I size = new Vector2I(1250, 850);
        DisplayServer.WindowSetSize(size);		
	}

	public override void _Process(double delta) {
		
	}
}
