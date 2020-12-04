using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day4Part2
	{
		private static readonly string REGEX_PATTERN = @"(\w+):(\S+)";

		private static readonly string[] EYE_COLORS = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

		public Day4Part2()
		{
			string[] programList = Utils.LoadFile("Day4-1.txt").Split("\r\n\r\n");
			int numberValidPassports = 0;

			foreach (string passport in programList)
			{
				bool validPassport = true;
				int totalAttributes = 0;
				List<string> passportProperties = Regex.Matches(passport, REGEX_PATTERN).OfType<Match>().Select(m => m.Groups[0].Value).ToList();
				foreach (string[] val in passportProperties.Select(property => property.Split(":")))
				{
					if (!validPassport) break;

					if (val[0] == "cid") continue;
					
					totalAttributes++;
					validPassport =  ValidatePassportProperty(val[0], val[1]);
				}

				if (validPassport && totalAttributes >= 7)
					numberValidPassports++;
			}

			Console.WriteLine($"Number valid passports: {numberValidPassports}");
		}

		private static bool ValidatePassportProperty(string name, string value)
		{
			switch (name)
			{
				case "byr":
					int valByr = int.Parse(value);
					return (valByr >= 1920 && valByr <= 2002);				
				case "iyr":
					int valIyr = int.Parse(value);
					return (valIyr >= 2010 && valIyr <= 2020);				
				case "eyr":
					int valEyr = int.Parse(value);
					return (valEyr >= 2020 && valEyr <= 2030);
				case "hgt":
					if (value.Contains("in"))
					{
						int height = int.Parse(value.Substring(0, value.Length - 2));
						return (height >= 59 && height <= 76);
					} else if (value.Contains("cm"))
					{
						int height = int.Parse(value.Substring(0, value.Length - 2));
						return (height >= 150 && height <= 193);
					}
					break;
				case "hcl":
					const string hexRegex = @"^#([A-Fa-f0-9]{6})$";
					return Regex.Match(value, hexRegex).Success;
				case "ecl":
					return EYE_COLORS.Contains(value);
				case "pid":
					const string pidRegex = @"^(\d{9})$";
					return Regex.Match(value, pidRegex).Success;
			}
			return false;
		}
	}
}