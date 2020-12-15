using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Days
{
	public class Day14Part2
	{
		private Dictionary<string, long> _memory = new Dictionary<string, long>();
		
		public Day14Part2()
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

			long total = _memory.Sum(mem => mem.Value);

			Console.WriteLine($"Total of the binaries is {total}");

		}

		private void HandleBitMask(string mask, string memoryInfo)
		{
			int memoryLocationInt = Convert.ToInt32(memoryInfo.Replace("mem[", "").Split("]")[0]);
			string memoryLocation = Convert.ToString(memoryLocationInt, 2);
			int value = Convert.ToInt32(memoryInfo.Split(" = ")[1]);
		
			StringBuilder sb = new StringBuilder(memoryLocation.PadLeft(36, '0'));
			
			for (int i = 0; i < mask.Length; i++)
			{
				if (mask[i] == '0')
					continue;

				sb[i] = mask[i];
			}

			long[] addresses = GetAllAddress(sb.ToString());

			foreach (long item in addresses)
			{
				_memory[item.ToString()] = value;
			}
		}
		private long[] GetAllAddress(string addMask)
		{
			List<long> result = new List<long>();
			Queue<string> strAddr = new Queue<string>();
			strAddr.Enqueue(addMask);

			while(strAddr.Count > 0)
			{
				string t = strAddr.Dequeue();

				int pos = t.IndexOf('X');
				if (pos == -1)
				{
					result.Add(Convert.ToInt64(t, 2));
					continue;
				}
				StringBuilder sb = new StringBuilder(t);
				sb.Replace('X', '0', pos, 1);
				strAddr.Enqueue(sb.ToString());
				sb.Replace('0', '1', pos, 1);
				strAddr.Enqueue(sb.ToString());
			}
			return result.ToArray();
		}
	}
}