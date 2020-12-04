using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day3Part1
	{
		public Day3Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day3-1.txt");
			int depth = programList.Length;
			int length = 0;
			List<char[]> items = new List<char[]>();
			foreach (var line in programList)
			{
				if (length == 0)
					length = line.Length;
				
				items.Add(line.ToCharArray());
			}

			int row = 0;
			int right = 0;
			int foundTrees = 0;
			while (row != depth - 1)
			{
				row += 1;
				right += 3;

				if (items[row][right % length] == '#')
					foundTrees++;
			}
			
			Console.WriteLine($"Found Trees: {foundTrees}");

		}
	}
}