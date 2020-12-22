using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day22Part1
	{
		public Day22Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day22-1.txt");

			List<Queue<int>> hands = new List<Queue<int>>();

			foreach (string input in programList)
			{
				if (input.StartsWith("Player"))
				{
					hands.Add(new Queue<int>());
				}
				else
				{
					hands[^1].Enqueue(Convert.ToInt32(input));
				}
			}

			while (hands[0].Count > 0 && hands[1].Count > 0)
			{
				int hand1 = hands[0].Dequeue();
				int hand2 = hands[1].Dequeue();

				if (hand1 > hand2)
				{
					hands[0].Enqueue(hand1);
					hands[0].Enqueue(hand2);
				}
				else
				{
					hands[1].Enqueue(hand2);
					hands[1].Enqueue(hand1);
				}
			}

			int winner = (hands[0].Count > 0) ? 0 : 1;

			int total = 0;
			for (int i = hands[winner].Count - 1; i >= 0; i--)
			{
				total += (hands[winner].Dequeue() * (i + 1));
			}

			Console.WriteLine($"The total score is: {total}");
		}
	}
}