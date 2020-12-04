using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day2Part1
	{
		public Day2Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day2-1.txt");
			string regexPattern = @"(\d*-\d*) (\w): (.*)";
			int validPasswords = 0;
			foreach (string i in programList)
			{
				MatchCollection  matches = Regex.Matches(i, regexPattern);
				string[] minMaxValues = matches[0].Groups[1].ToString().Split('-');
				int min = Int32.Parse(minMaxValues[0]);
				int max = Int32.Parse(minMaxValues[1]);
				char letter = Char.Parse(matches[0].Groups[2].ToString());
				string password = matches[0].Groups[3].ToString();
				int freq = password.Count(f => (f == letter));
				if (freq >= min && freq <= max)
					validPasswords++;
			}
			
			Console.WriteLine($"Valid Passwords Count: {validPasswords}");
		}
	}
}