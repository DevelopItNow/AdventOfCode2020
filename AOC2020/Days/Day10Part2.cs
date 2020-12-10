using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day10Part2
	{
		private List<int> programList;
		public Day10Part2()
		{
			programList = Utils.LoadFileToIntArray("Day10-1.txt").ToList();
			programList.Add(0);
			programList.Sort();
			programList.Add(programList[^1]+3);
			long possibilities = BruteForceAdapter();
			
			Console.WriteLine($"There are {possibilities} possibilities");
		}

		private long BruteForceAdapter()
		{
			HashSet<int> dataWithIndex = programList.ToHashSet();
			
			Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

			for (int i = dataWithIndex.Count - 1; i >= 0; i--)
			{
				graph.Add(programList[i], new List<int>());
				if(dataWithIndex.Contains(programList[i] - 1))
					graph[programList[i]].Add(programList[i] - 1);
				if(dataWithIndex.Contains(programList[i] - 2))
					graph[programList[i]].Add(programList[i] - 2);
				if(dataWithIndex.Contains(programList[i] - 3))
					graph[programList[i]].Add(programList[i] - 3);
			}
			
			Dictionary<int, long> totalDict = new Dictionary<int, long>();

			for (int i = 0; i < programList.Count; i++)
			{
				long count = (i == 0 ? 1 : 0) + graph[programList[i]].Sum(g => totalDict[g]);
				totalDict.Add(programList[i], count);
			}

			return totalDict[programList[^1]];

		}
	}
}