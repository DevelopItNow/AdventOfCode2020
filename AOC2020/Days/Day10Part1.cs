using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day10Part1
	{
		private int[] programList;
		public Day10Part1()
		{
			programList = Utils.LoadFileToIntArray("Day10-1.txt");
			Array.Sort(programList);
			

			int location = 0;
			int difference1 = 1;
			int difference3 = 1;

			while (location < programList.Length)
			{
				if (location + 1 == programList.Length) break;
				if (programList[location + 1] - programList[location] == 1)
					difference1++;
				else
					difference3++;

				location++;
			}
			Console.WriteLine($"Jolt value is {difference1 * difference3}");
		}
	}
}