using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day16Part1
	{
		public Day16Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day16-1.txt");
			
			List<(int, int)> ranges = new List<(int, int)>();

			int step = 0;
			int total = 0;
			foreach (string input in programList)
			{
				switch (input)
				{
					case "":
						continue;
					case "your ticket:":
						step++;
						continue;
					case "nearby tickets:":
						step++;
						continue;
				}

				switch (step)
				{
					case 0:
					{
						string[] types = input.Split(":")[1].Split(" ");

						string[] numbers = types[1].Split("-");
					
						ranges.Add((Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1])));
					
						numbers = types[3].Split("-");
					
						ranges.Add((Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1])));
						break;
					}
					case 2:
					{
						int[] values = input.Split(",").Select(s => Convert.ToInt32(s)).ToArray();
						foreach (int value in values)
						{
							bool inRange = false;
							foreach ((int, int) range in ranges.Where(range => value >= range.Item1 && value <= range.Item2))
							{
								inRange = true;
							}

							if (inRange) continue;
							total += value;
						}

						break;
					}
				}
			}
			
			Console.WriteLine($"The scanning error rate is {total}");
		}
	}
}