using System;
using System.Collections.Generic;

namespace PokerDice
{
	class PokerRules
	{
		public void FindMatchingDice(Tuple<string, int>[] hand)
		{
			var pairs = new List<string>();
			var kickers = new List<string>();
			int totalHandValue = 0;

			for (var i = 1; i <= hand.Length - 1; i++)
			{
				totalHandValue += hand[i - 1].Item2;

				if (hand[i].Item1 == hand[i - 1].Item1)
				{
					string matchingDice = hand[i].Item1;
					pairs.Add(matchingDice);
				}
				else
				{
					string bob = hand[i - 1].Item1;
					kickers.Add(bob);
				}

				pairs.ToArray();
				kickers.ToArray();
				//player.HandWeight[i] = pairs;
			}

			totalHandValue += hand[4].Item2;

			if(pairs.Count == 0)
			{
				if (totalHandValue == 55)
				{
					Console.WriteLine("You have a K high Straight");
					return;
				}
				if (totalHandValue == 60)
				{
					Console.WriteLine("You have a A high Straight");
					return;
				}
			}
			else
			{
				var printHand = DetermineHand(pairs);
				Console.WriteLine(printHand);
			}
		}

		public string DetermineHand(List<string> player)

		{
			if (player.Count == 1)
			{
				return $"Pair of {player[0]}";
			}
			if(player.Count == 2 && player[0] == player[1])
			{
				return $"Three of a kind {player[0]}";
			}
			if (player.Count == 2 && player[0] != player[1])
			{
				return $"2 Pair {player[0]} {player[1]}";
			}
			if (player.Count == 3 && player[0] != player[2])
			{
				return $"Full House {player[0]}'s full of {player[2]}'s";
			}
			if (player.Count == 3 && player[0] == player[2])
			{
				return $"Four of a kind {player[0]}'s";
			}
			if (player.Count == 3 && player[0] == player[3])
			{
				return $"Five of a kind {player[0]}'s";
			}
			return "";
		}
	}
}
