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
					foreach (string k in programList)
					{
						int num1 = Int32.Parse(i);
						int num2 = Int32.Parse(j);
						int num3 = Int32.Parse(k);
						if ((num1 + num2 + num3) == 2020)
						{
							Console.WriteLine(num1 * num2 * num3);
							return;
						}
					}
				}
			}
		}
	}
}