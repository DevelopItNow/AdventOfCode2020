using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day14Part1
	{
		private Dictionary<int, string> _memory = new Dictionary<int, string>();
		
		public Day14Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day14-1.txt");

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

			long total = _memory.Sum(memInfo => Convert.ToInt64(memInfo.Value, 2));

			Console.WriteLine($"Total of the binaries is {total}");

		}

		private void HandleBitMask(string mask, string memoryInfo)
		{
			int memoryLocation = Convert.ToInt32(memoryInfo.Replace("mem[", "").Split("]")[0]);
			int decimalNumber = Convert.ToInt32(memoryInfo.Split(" = ")[1]);
			char[] binaryNumber = Convert.ToString(decimalNumber, 2).ToCharArray();
			char[] newBinaryMemory = "000000000000000000000000000000000000".ToCharArray();
			char[] maskChars = mask.ToCharArray();

			int j = binaryNumber.Length - 1;
			for (int i = maskChars.Length - 1; i >= 0; i--)
			{
				if (j >= 0)
				{
					newBinaryMemory[i] = binaryNumber[j];
				}

				newBinaryMemory[i] = maskChars[i] switch
				{
					'1' => '1',
					'0' => '0',
					_ => newBinaryMemory[i]
				};

				j--;
			}

			_memory[memoryLocation] = new string(newBinaryMemory);
		}
	}
}