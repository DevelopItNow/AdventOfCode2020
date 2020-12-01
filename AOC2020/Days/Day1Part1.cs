using System;
using System.Linq;

namespace AOC2020.Days
{
	public class Day1Part1
	{
		public Day1Part1()
		{
			string[] programList = Utils.LoadFile("Day1-1.txt");
			foreach (string i in programList)
			{
				int valueNeeded = 2020 - Int32.Parse(i);
				if (Array.IndexOf(programList, valueNeeded.ToString()) > -1)
				{
					Console.WriteLine(valueNeeded * Int32.Parse(i));
					return;
				}
			}
		}
	}
}