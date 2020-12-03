using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day3Part1
	{
		public Day3Part1()
		{
			string[] programList = Utils.LoadFile("Day3-1.txt");
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
				if (right > length - 1)
					right -= length;

				if (items[row][right] == '#')
					foundTrees++;
			}
			
			Console.WriteLine($"Found Trees: {foundTrees}");

		}
	}
}