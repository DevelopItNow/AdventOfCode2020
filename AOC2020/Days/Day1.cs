using System;

namespace AOC2020.Days
{
	public class Day1
	{
		public Day1()
		{
			string[] programList = Utils.LoadFile("Day1-1.txt");
			foreach (string i in programList)
			{
				foreach (string j in programList)
				{
					int num1 = Int32.Parse(i);
					int num2 = Int32.Parse(j);
					if ((num1 + num2) == 2020)
					{
						Console.WriteLine(num1 * num2);
						return;
					}
				}
			}
		}
	}
}