using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDice
{
	public class Player
	{
		public string Name { get; set; }
		public string[] DiceRolled { get; set; }
		public int[] DiceValues { get; set; }

		public Player(string name)
		{
			this.Name = name;
		}
	}
}
