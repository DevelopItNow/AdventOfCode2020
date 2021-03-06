﻿using System;

namespace AOC2020.Days
{
	public class Day5Part1
	{
		private static readonly int ROW_NUMBERS = 127;
		private static readonly int SEAT_NUMBERS = 7;

		public Day5Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day5-1.txt");

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
				highestValue = (sum > highestValue) ? sum : highestValue;
			}
			Console.WriteLine($"Seat ID is: {highestValue}");
		}
	}
}