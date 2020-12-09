using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day9Part2
	{
		private long[] programList;
		public Day9Part2()
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

			long encryptionWeakness = SearchSum(value);
			
			Console.WriteLine($"The first encryption weakness code is {encryptionWeakness}");
		}

		private long SearchSum(long neededValue)
		{
			int row = 0;
			while (true)
			{
				long sum = 0;
				List<long> itemList = new List<long>();
				for (int i = row; i < programList.Length; i++)
				{
					if (sum < neededValue)
					{
						sum += programList[i];
						itemList.Add(programList[i]);
					} else if (sum == neededValue)
					{
						long min = itemList.Min();
						long max = itemList.Max();
						return min + max;
					}
					else
					{
						break;
					}
				}
				itemList.Clear();
				row++;
			}
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