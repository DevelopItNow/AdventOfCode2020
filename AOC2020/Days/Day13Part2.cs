using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day13Part2
	{
		public Day13Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day13-1.txt");

			string times = programList[1];
			// string times = "17,x,13,19";
			// string times = "67,7,59,61";
			// string times = "67,x,7,59,61";
			// string times = "67,7,x,59,61";
			// string times = "1789,37,47,1889";
			
			long[] busList = times.Split(",").Select(s => s == "x" ? -1 : long.Parse(s)).ToArray();

			long time = 0;
			
			for (long i = 1, startBusTime = busList[0]; i < busList.Length; i++)
			{
				long buss = busList[i];
				if (buss == -1) continue;
				long timeBus = buss * (1 + i / buss);
				while (true)
					if (timeBus - time % buss != i) time += startBusTime;
					else break;
				startBusTime *= buss;
			}
			
		
			Console.WriteLine($"The time is {time}");

		}
	}
}