using System;
using System.Collections.Generic;
using System.Numerics;

namespace AOC2020.Days
{
	public class Day3Part2
	{
		private int _depth;
		private int _length = 0;
		private List<char[]> _items = new List<char[]>();
		public Day3Part2()
		{
			string[] programList = Utils.LoadFile("Day3-1.txt");
			
			_depth = programList.Length;
			foreach (var line in programList)
			{
				if (_length == 0)
					_length = line.Length;
				
				_items.Add(line.ToCharArray());
			}
			int[,] toCalculate = new int[,] {{1,1}, {3,1}, {5,1}, {7,1}, {1,2}};

			BigInteger  foundTrees = 0;
			for (int i = 0; i < toCalculate.Length / 2; i++)
			{
				int foundTreesDuringSlope = DownTheSlope(toCalculate[i, 0], toCalculate[i, 1]);

				if (foundTrees == 0)
					foundTrees = foundTreesDuringSlope;
				else
					foundTrees *= foundTreesDuringSlope;
			}
			Console.WriteLine($"Found Trees: {foundTrees}");
			
		}

		private int DownTheSlope(int rAmount, int dAmount)
		{
			int row = 0;
			int right = 0;
			int foundTrees = 0;
			while (row != _depth - 1)
			{
				row += dAmount;
				right += rAmount;
				if (right > _length - 1)
					right -= _length;

				if (_items[row][right] == '#')
					foundTrees++;
			}

			return foundTrees;
		}
	}
}