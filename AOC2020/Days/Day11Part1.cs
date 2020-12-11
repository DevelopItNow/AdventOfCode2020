using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day11Part1
	{
		private char[][] programList;

		private static readonly char EMPTY_SEAT = 'L';
		private static readonly char OCCUPIED_SEAT = '#';

		private int _height = 0;
		private int _width = 0;
		private List<(int, int)> _directions;

		public Day11Part1()
		{
			string[] stringArray = Utils.LoadFileToStringArray("Day11-1.txt");
			programList = new char[stringArray.Length][];
			_directions = new List<(int, int)>
			{
				(-1, -1),
				(-1, 0),
				(-1, 1),
				
				(0, -1),
				(0, 1),
				
				(1, -1),
				(1, 0),
				(1, 1),
			};
			int i = 0;
			foreach (string line in stringArray)
			{
				programList[i] = line.ToCharArray();
				if (_width == 0)
					_width = line.Length;
				i++;
			}

			_height = programList.Length;

			bool isRunning = true;
			while (isRunning)
			{
				isRunning = HandleMap();
			}

			int numberOccupiedSeats = programList.Sum(line => line.Count(seat => seat == OCCUPIED_SEAT));
			
			Console.WriteLine($"The number of occupied seats are {numberOccupiedSeats}");
		}

		private bool HandleMap()
		{
			char[][] newList = programList.Select(a => a.ToArray()).ToArray();
			int x = 0;
			int y = 0;
			bool valueChanged = false;
			foreach (char[] line in programList)
			{
				foreach (char seat in line)
				{
					if (seat == EMPTY_SEAT)
						if (NumberOccupiedSeat(x, y) == 0)
						{
							newList[y][x] = OCCUPIED_SEAT;
							valueChanged = true;
						}
					if (seat == OCCUPIED_SEAT)
						if (NumberOccupiedSeat(x, y) >= 4)
						{
							newList[y][x] = EMPTY_SEAT;
							valueChanged = true;
						}
					x++;
				}

				y++;
				x = 0;
			}

			programList = newList;

			return valueChanged;
		}

		private int NumberOccupiedSeat(int x, int y)
		{
			int total = 0;
			foreach ((int, int) direction in _directions)
			{
				int tempX = x + direction.Item2;
				int tempY = y + direction.Item1;
				if (tempX >= 0 && tempY >= 0 && tempX < _width && tempY < _height)
					if (programList[tempY][tempX] == OCCUPIED_SEAT)
						total++;
			}
			return total;
		}

	}
}