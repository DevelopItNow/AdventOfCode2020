using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day6Part1
	{
		public Day6Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day6-1.txt");

			int total = 0;
			List<char> groupAnswers = new List<char>();
			foreach (string answer in programList)
			{
				if (answer == "")
				{
					total += groupAnswers.Count;
					groupAnswers.Clear();
					continue;
				}

				foreach (char singleAnswer in answer.Where(singleAnswer => !groupAnswers.Contains(singleAnswer)))
					groupAnswers.Add(singleAnswer);
			}
			total += groupAnswers.Count;

			Console.WriteLine($"The answers together are : {total}");
		}
	}
}