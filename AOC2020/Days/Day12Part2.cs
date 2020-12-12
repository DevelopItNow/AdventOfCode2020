using System;
using System.Numerics;

namespace AOC2020.Days
{
	public class Day12Part2
	{
		Vector2 _shipVector = new Vector2(0,0);

		Vector2 _waypointVector = new Vector2(10, 1);
		public Day12Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day12-1.txt");

			foreach (string instruction in programList)
			{
				char dir = Convert.ToChar(instruction.Substring(0, 1));
				int speed = Convert.ToInt32(instruction.Substring(1, instruction.Length - 1));
				Move(dir, speed);
			}
			Console.WriteLine($"The Manhatten distance is {Math.Abs(_shipVector.X) + Math.Abs(_shipVector.Y)}");
		}

		private void Move(char dir, int speed)
		{
			switch (dir)
			{
				
				case 'N':
					_waypointVector = Vector2.Add(_waypointVector, new Vector2(0, speed));
					break;
				case 'S':
					_waypointVector = Vector2.Add(_waypointVector, new Vector2(0, -speed));
					break;
				case 'E':
					_waypointVector = Vector2.Add(_waypointVector, new Vector2(speed, 0));
					break;
				case 'W':
					_waypointVector = Vector2.Add(_waypointVector, new Vector2(-speed, 0));
					break;
				case 'L':
					for (int i = 0; i < speed / 90; i++)
					{
						float oldWaypointX = _waypointVector.X;
						_waypointVector.X = -_waypointVector.Y;
						_waypointVector.Y = oldWaypointX;
					}
					break;
				case 'R':
					for (int i = 0; i < speed / 90; i++)
					{
						float oldWaypointX = _waypointVector.X;
						_waypointVector.X = _waypointVector.Y;
						_waypointVector.Y = -oldWaypointX;
					}
					break;
				case 'F':
					_shipVector = _shipVector + speed * _waypointVector;
					break;
			}
		}
	}
}