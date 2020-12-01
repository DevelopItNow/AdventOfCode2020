using System;

namespace AOC2020.Days
{
	public class Day1Part2
	{
		public Day1Part2()
		{
			string[] programList = Utils.LoadFile("Day1-1.txt");
			foreach (string i in programList)
			{
				foreach (string j in programList)
				{
					int valueNeeded = 2020 - Int32.Parse(i) - Int32.Parse(j);
					if (Array.IndexOf(programList, valueNeeded.ToString()) > -1)
					{
						Console.WriteLine(valueNeeded * Int32.Parse(i) * Int32.Parse(j));
						return;
					}
				}
			}
		}
	}
}