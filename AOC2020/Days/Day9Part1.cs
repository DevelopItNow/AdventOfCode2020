using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day9Part1
	{
		private long[] programList;
		public Day9Part1()
		{
			programList = Utils.LoadFileToLongArray("Day9-1.txt");

			int start = 0;
			const int length = 24;
			long value = 0;
			while (true)
			{
				long matchValue = SearchNoneMatch(start, length);

				if (matchValue == -1)
					start++;
				else
				{
					value = matchValue;
					break;
				}
			}
			
			Console.WriteLine($"The first value we can't match is {value}");
		}

		private long SearchNoneMatch(int start, int length)
		{
			int id = start;
			long neededValue = programList[length + start + 1];
			while (id <= start+length)
			{
				long val1 = programList[id];
				for (int i = start; i < start + length; i++)
				{
					if (id == i) continue;
					if (val1 + programList[i] == neededValue)
						return -1;
				}

				id++;
			}

			return neededValue;
		}
	}
}