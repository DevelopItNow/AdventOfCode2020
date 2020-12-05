using System;
using System.Text.RegularExpressions;

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
				int lastValueRow = 0;
				
				int minSeat = 0;
				int maxSeat = SEAT_NUMBERS;
				int lastValueSeat = 0;
				
				
				foreach (char rowChar in boardingCard)
				{
					int rowDifference = maxRow - minRow;
					int seatDifference = maxSeat - minSeat;

					switch (rowChar)
					{
						case 'F':
							maxRow -= (int)Math.Ceiling((double)rowDifference / 2);
							lastValueRow = maxRow;
							break;
						case 'B':
							minRow += (int) Math.Floor((double)rowDifference / 2);
							lastValueRow = minRow;
							break;						
						case 'R':
							minSeat += (int) Math.Floor((double)seatDifference / 2);
							lastValueSeat = minSeat + 1;
							break;						
						case 'L':
							maxSeat -= (int)Math.Ceiling((double)seatDifference / 2);
							lastValueSeat = maxSeat;
							break;
					}
				}

				int sum = lastValueRow * 8 + lastValueSeat;
				highestValue = (sum > highestValue) ? sum : highestValue;
			}
			Console.WriteLine($"Seat ID is: {highestValue}");
		}
	}
}