using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDice
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Program();
			var b = new PokerRules();
			int numOfPlayers = p.ObtainNumOfPlayers();
			Player[] players = p.CreatePlayers(numOfPlayers);
			p.RollDice(players);

			Console.ReadLine();
		}

		private int ObtainNumOfPlayers()
		{
			int numOfPlayers = 0;

			do
			{
				Console.WriteLine("Please type number of Players (2-5)");
			} while (!int.TryParse(Console.ReadLine(), out numOfPlayers));

			if (numOfPlayers < 2 || numOfPlayers > 5)
			{
				return ObtainNumOfPlayers();		
			}

			Console.WriteLine("You selected " + numOfPlayers + " players");
			return numOfPlayers;
		}

		private Player[] CreatePlayers(int numOfPlayers)
		{
			Player[] playerArray = new Player[numOfPlayers];

			for (int i = 1; i <= numOfPlayers; i++)
			{
				Console.WriteLine($"Player {i} please enter your name:");
				var playerName = Console.ReadLine();
				var newPlayer = new Player(playerName);
				playerArray[i - 1] = newPlayer;
			}

			return playerArray;
		}

		private void RollDice(Player[] players)
		{
			foreach (var player in players)
			{
				RandomDiceRoll(player);
			}
		}

		private void RandomDiceRoll(Player player)
		{
			var diceDict = DiceValues.Dice;
			player.DiceRolled = new Tuple<string, int>[3][];
			Random random = new Random();
			var pokerRules = new PokerRules();

			for (int i = 1; i <= 3; i++)
			{
				var handArray = new Tuple<string, int>[5];
				Console.WriteLine($"{player.Name} press enter to take dice roll number {i}");
				Console.ReadLine();

				for (int j = 0; j <= 4; j++)
				{
					var randomDice = diceDict.ElementAt(random.Next(0, diceDict.Count)).Key;
					handArray[j] = Tuple.Create(randomDice, diceDict[randomDice]);
				}

				player.DiceRolled[i - 1] = handArray.OrderBy(x => x.Item2).ToArray();
				 
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"{player.Name} rolled {player.DiceRolled[i - 1][0].Item1}, " +
											 $"{player.DiceRolled[i - 1][1].Item1}, " +
											 $"{player.DiceRolled[i - 1][2].Item1}, " +
											 $"{player.DiceRolled[i - 1][3].Item1}, " +
											 $"{player.DiceRolled[i - 1][4].Item1}");
				Console.ResetColor();
				pokerRules.FindMatchingDice(player.DiceRolled[i - 1]);
			}		

			Console.WriteLine();
		}
	}
}
