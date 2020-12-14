using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day14Part2
	{
		private Dictionary<string, int> _memory = new Dictionary<string, int>();
		
		public Day14Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day14-1-Test.txt");

			string mask = "";
			foreach (string memInfo in programList)
			{
				if (memInfo.StartsWith("mask = "))
				{
					mask = memInfo.Replace("mask = ", "");
					continue;
				}

				if (memInfo.StartsWith("mem["))
				{
					HandleBitMask(mask, memInfo);
				}
			}

			// long total = _memory.Sum(memInfo => Convert.ToInt64(memInfo.Value, 2));

			// Console.WriteLine($"Total of the binaries is {total}");

		}

		private void HandleBitMask(string mask, string memoryInfo)
		{
			int memoryLocationInt = Convert.ToInt32(memoryInfo.Replace("mem[", "").Split("]")[0]);
			string memoryLocation = Convert.ToString(memoryLocationInt, 2);
			int value = Convert.ToInt32(memoryInfo.Split(" = ")[1]);
			char[] maskChars = mask.ToCharArray();

			for (int i = 0; i < maskChars.Length; i++)
			{
				
			}
		}
	}
}