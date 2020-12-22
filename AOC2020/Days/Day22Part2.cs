using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day22Part2
	{
		private int _lastInt = 1;

		public Day22Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day22-1.txt");

			List<Queue<int>> hands = new List<Queue<int>>();
			foreach (string input in programList)
			{
				if (input.StartsWith("Player"))
				{
					hands.Add(new Queue<int>());
				}
				else if (input != "")
				{
					hands[^1].Enqueue(Convert.ToInt32(input));
				}
			}

			playGame(hands[0], hands[1]);

			int winner = (hands[0].Count > 0) ? 0 : 1;
			int total = 0;
			for (int i = hands[winner].Count - 1; i >= 0; i--)
			{
				total += (hands[winner].Dequeue() * (i + 1));
			}

			Console.WriteLine($"The total score is: {total}");
		}

		private void playGame(Queue<int> player1, Queue<int> player2)
		{
			List<string> copies = new List<string>();

			while (player1.Count > 0 && player2.Count > 0)
			{
				var state = String.Join(":", player1) + " " + String.Join(":", player2);

				if (copies.Contains(state))
				{
					player2.Clear();
					return;
				}

				copies.Add(state);

				int card1 = player1.Dequeue();
				int card2 = player2.Dequeue();

				if (player1.Count >= card1 && player2.Count >= card2)
				{
					Queue<int> copyPlayer1 = new Queue<int>(player1.Take(card1));
					Queue<int> copyPlayer2 = new Queue<int>(player2.Take(card2));

					playGame(copyPlayer1, copyPlayer2);
					if (copyPlayer1.Count > 1)
					{
						player1.Enqueue(card1);
						player1.Enqueue(card2);
					}
					else
					{
						player2.Enqueue(card2);
						player2.Enqueue(card1);
					}
				}
				else if (card1 > card2)
				{
					player1.Enqueue(card1);
					player1.Enqueue(card2);
				}
				else if (card1 < card2)
				{
					player2.Enqueue(card2);
					player2.Enqueue(card1);
				}
			}
		}
	}
}