using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDice
{
	class PokerRules
	{
		public void FindMatchingDice(Player player)
		{
			var hand = player.DiceRolled;

			for (int i = 0; i <= 2; i++)
			{
				var pairs = new List<int>();

				for (int j = 1; j <= hand[i].Length - 1; j++)
				{
					if (hand[i][j].Item2 == hand[i][j - 1].Item2){
						int matchingCard = hand[i][j].Item2;
						pairs.Add(matchingCard);
					}
				}

				pairs.ToArray();
				player.HandWeight[i] = pairs;
			}

			Console.WriteLine();
		}
	}
}
