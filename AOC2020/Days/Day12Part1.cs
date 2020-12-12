using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day12Part1
	{
		private int _x = 0;
		private int _y = 0;
		private int _direction = 1;
		private readonly char[] _directions = {'N', 'E', 'S', 'W'};
		public Day12Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day12-1.txt");

			foreach (string instruction in programList)
			{
				char dir = Convert.ToChar(instruction.Substring(0, 1));
				int speed = Convert.ToInt32(instruction.Substring(1, instruction.Length - 1));
				Move(dir, speed);
			}
			Console.WriteLine($"The Manhatten distance is {Math.Abs(_x) + Math.Abs(_y)}");

		}

		private void Move(char dir, int speed)
		{
			switch (dir)
			{
				case 'N':
					_y -= speed;
					break;
				case 'S':
					_y += speed;
					break;
				case 'E':
					_x += speed;
					break;
				case 'W':
					_x -= speed;
					break;
				case 'L':
					int sumL = speed / 90;
					_direction = (_direction - sumL < 0) ? _direction - sumL + 4 : _direction - sumL;
					break;
				case 'R':
					int sumR = speed / 90;
					_direction = (_direction + sumR > 3) ? _direction + sumR - 4 : _direction + sumR;
					break;
				case 'F':
					Move(_directions[_direction], speed);
					break;
			}
		}
	}
}