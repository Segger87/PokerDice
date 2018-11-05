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

			int numOfPlayers = p.ObtainNumOfPlayers();
			Player[] players = p.CreatePlayers(numOfPlayers);
			p.RollDice(players);
			Console.ReadLine();
			
		}

		private int ObtainNumOfPlayers()
		{
			int numOfPlayers;
			do
			{
				Console.WriteLine("Please type number of Players (2-5)");
			} while (!int.TryParse(Console.ReadLine(), out numOfPlayers));

			if(numOfPlayers < 2 || numOfPlayers > 5)
			{
				ObtainNumOfPlayers();
			}

			Console.WriteLine("You selected " + numOfPlayers + " players");
			return numOfPlayers;
		}

		private Player[] CreatePlayers(int numOfPlayers)
		{
			Player[] playerArray = new Player[numOfPlayers];

			for (int i = 1; i <= numOfPlayers; i++)
			{
				Console.WriteLine($"Player {i} please enter your name:" );
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
				for (int i = 1; i <= 3; i++)
				{
					Console.WriteLine($"{player.Name} press enter to take dice roll number {i}" );
					Console.ReadLine();
				}
				RandomDiceRoll(player);
			}
		}

		private void RandomDiceRoll(Player player)
		{
			//Array values = Enum.GetValues(typeof(DiceValues.Dice));
			var diceDict = DiceValues.Dice;
			player.DiceRolled = new string [3][];
			player.DiceValues = new int[3][];
			Random random = new Random();

			for (int i = 0; i <= 2; i++)
			{
				//var diceArray = new DiceValues.Dice[6];
				var hand = new string[5];
				var value = new int[5];

				for (int j = 0; j <= 4; j++)
				{
					//var randomDice = (DiceValues.Dice)values.GetValue(random.Next(values.Length));
					//player.DiceRolled[j] = randomDice;
					hand[j] = diceDict.ElementAt(random.Next(0, diceDict.Count)).Key;
					value[j] = diceDict[hand[j]];
				}

				player.DiceRolled[i] = hand;
				player.DiceValues[i] = value;
			}


			Console.WriteLine();
		}
	}
}
