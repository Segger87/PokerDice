using System;
using System.Collections.Generic;

namespace PokerDice
{
	public class Player
	{
		public string Name { get; set; }
		public string BestHand { get; set; }
		public Tuple<string, int>[][] DiceRolled { get; set; }
		public List<int>[] HandWeight = new List<int>[3];

		public Player(string name)
		{
			this.Name = name;
		}
	}
}
