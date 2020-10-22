using Godot;
using System;


public class player : Node
{	
	[Export]
	int karma = 10;
	[Export]
	int luck_modifyer = 5;
	string[] inventory_events = {};
	

	public void _karma_reduce(int how_much_to_reduce)
	{
		if(karma > 0)
			if(karma - how_much_to_reduce < 0)
			{
				karma = 10;
			}
			else
			{
				karma -= how_much_to_reduce;
			}
		else 
		{
			karma = 0;
		}
	}
	public void _karma_restore(int how_much_to_restore)
	{
		if(karma < 100 && karma >= 0)
			if(karma + how_much_to_restore > 100)
			{
				karma = 90;
			}
			else
			{
				karma += how_much_to_restore;
			}
		else 
		{
			karma = 100;
		}
	}

	public bool _karma_chance_roll(int cum)
	{
		Random rng = new Random();
		if(rng.Next(101) + luck_modifyer <= karma)
		{
			_karma_reduce(cum);
			return true;			
		}
		else
		{
			_karma_restore(cum);
			return false;
		}
	}

	public bool _half_chance_roll()
	{
		Random rng = new Random();
		return (rng.Next(101) + luck_modifyer >= 50);
	}
}
