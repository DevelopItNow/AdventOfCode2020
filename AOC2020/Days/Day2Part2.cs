using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day2Part2
	{
		public Day2Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day2-1.txt");
			string regexPattern = @"(\d*-\d*) (\w): (.*)";
			int validPasswords = 0;
			foreach (string i in programList)
			{
				MatchCollection  matches = Regex.Matches(i, regexPattern);
				string[] minMaxValues = matches[0].Groups[1].ToString().Split('-');
				int pos1 = Int32.Parse(minMaxValues[0]) - 1;
				int pos2 = Int32.Parse(minMaxValues[1]) - 1;
				char letter = Char.Parse(matches[0].Groups[2].ToString());
				char[] password = matches[0].Groups[3].ToString().ToCharArray();
				bool pos1HasLetter = (password[pos1] == letter);
				bool pos2HasLetter = (password[pos2] == letter);
				if ((pos1HasLetter && !pos2HasLetter) || (!pos1HasLetter && pos2HasLetter) )
					validPasswords++;
			}
			
			Console.WriteLine($"Valid Passwords Count: {validPasswords}");
		}
	}
}