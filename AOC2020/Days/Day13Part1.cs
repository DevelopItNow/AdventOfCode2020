using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day13Part1
	{
		public Day13Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day13-1.txt");
			int earliestDepartureTime = Convert.ToInt32(programList[0]);

			string[] times = programList[1].Split(',');
			
			int minDepartureTime = Int32.MaxValue;
			int departureTimeStamp = 0;
			int specificTime = 0;
			foreach (string time in times)
			{
				if (time == "x") continue;
				int minTime = Convert.ToInt32(time);
				int min = earliestDepartureTime / minTime + 1;
				int sum = min * minTime;
				if (sum < minDepartureTime)
				{
					minDepartureTime = sum;
					specificTime = minTime;
					departureTimeStamp = min;
				}
			}

			int waitTime = departureTimeStamp * specificTime - earliestDepartureTime;
			Console.WriteLine($"The earliest bus leaves at {specificTime * waitTime}");
		}
	}
}