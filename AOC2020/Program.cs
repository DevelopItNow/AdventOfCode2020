using System;
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
			// Day3Part2 day3Part2 = new Day3Part2();
			// Day4Part1 day4Part1 = new Day4Part1();
			// Day4Part2 day4Part2 = new Day4Part2();
			// Day5Part1 day5Part1 = new Day5Part1();
			// Day5Part2 day5Part2 = new Day5Part2();
			// Day6Part1 day6Part1 = new Day6Part1();
			// Day6Part2 day6Part2 = new Day6Part2();
			// Day7Part1 day7Part1 = new Day7Part1();
			Day7Part2 day7Part2 = new Day7Part2();

			watch.Stop();
			long elapsedMs = watch.ElapsedMilliseconds;
			Console.WriteLine($"Time Elapsed: {elapsedMs}");
		}
	}
}