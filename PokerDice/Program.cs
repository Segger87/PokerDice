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
			p.CreatePlayers(numOfPlayers);
			
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
	}
}
