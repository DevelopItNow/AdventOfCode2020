﻿using System;
using System.Diagnostics;
using AOC2020.Days;

namespace AOC2020
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
			
			// Day1Part1 day1Part1 = new Day1Part1();
			// Day1Part2 day1Part2 = new Day1Part2();
			// Day2Part1 day2Part1 = new Day2Part1();
			// Day2Part2 day2Part2 = new Day2Part2();
			// Day3Part1 day3Part1 = new Day3Part1();
			Day3Part2 day3Part2 = new Day3Part2();
			
			watch.Stop();
			long elapsedMs = watch.ElapsedMilliseconds;
			Console.WriteLine($"Time Elapsed: {elapsedMs}");
		}
	}
}