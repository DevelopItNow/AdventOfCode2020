using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day6Part2
	{
		public Day6Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day6-1.txt");

			int total = 0;
			int groupTotal = 0;
			List<char> groupAnswers = new List<char>();
			foreach (string answer in programList)
			{
				if (answer == "")
				{
					IEnumerable<IGrouping<char, char>> g = groupAnswers.GroupBy( i => i );
					total += g.Count(grp => grp.Count() == groupTotal);
					groupAnswers.Clear();
					groupTotal = 0;
					continue;
				}

				foreach (char singleAnswer in answer)
					groupAnswers.Add(singleAnswer);

				groupTotal++;
			}
			IEnumerable<IGrouping<char, char>> ga = groupAnswers.GroupBy( i => i );
			total += ga.Count(grp => grp.Count() == groupTotal);
			Console.WriteLine($"The answers together are : {total}");
		}
	}
}