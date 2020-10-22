using Godot;
using System;


public class player : Node
{	
	[Export]
	int karma = 100;
	[Export]
	int luck_modifyer = 5;
	string[] inventory_events = {};
}
