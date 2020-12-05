using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day5Part2
	{
		private static readonly int ROW_NUMBERS = 127;
		private static readonly int SEAT_NUMBERS = 7;

		public Day5Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day5-1.txt");

			List<int> seatIdList = new List<int>();

			int highestValue = 0;
			foreach (string boardingCard in programList)
			{
				int minRow = 0;
				int maxRow = ROW_NUMBERS;
								
				int minSeat = 0;
				int maxSeat = SEAT_NUMBERS;
				
				foreach (char rowChar in boardingCard)
				{
					switch (rowChar)
					{
						case 'F':
							maxRow = (int )Math.Floor((double) (minRow + maxRow) / 2);
							break;
						case 'B':
							minRow = (int )Math.Ceiling((double) (minRow + maxRow) / 2);
							break;
						case 'L':
							maxSeat = (int )Math.Floor((double) (minSeat + maxSeat) / 2);
							break;
						case 'R':
							minSeat = (int )Math.Ceiling((double) (minSeat + maxSeat) / 2);
							break;
					}
				}
				int sum = minRow * 8 + minSeat;
				seatIdList.Add(sum);
				highestValue = (sum > highestValue) ? sum : highestValue;
			}

			foreach (int seatId in seatIdList.Where(seatId => !seatIdList.Contains(seatId + 1) && seatIdList.Contains(seatId + 2)))
			{
				Console.WriteLine("SEAT: " + (seatId + 1));
			}

		}
	}
}