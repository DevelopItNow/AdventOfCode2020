using System;

namespace AOC2020.Days
{
	public class Day4Part1
	{
		public Day4Part1()
		{
			string[] programList = Utils.LoadFile("Day4-1.txt").Split("\r\n\r\n");
			int numberValidPassports = 0;
			foreach (string passport in programList)
			{
				if (passport.Contains("byr:") && passport.Contains("iyr:") && passport.Contains("eyr:") && passport.Contains("hgt:") &&  passport.Contains("hcl:") &&  passport.Contains("ecl:") &&  passport.Contains("pid:"))
					numberValidPassports++;
			}
			Console.WriteLine($"Number valid passports: {numberValidPassports}");

		}
	}
}