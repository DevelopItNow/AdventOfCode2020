using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day19Part2
	{
		public Day19Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day19-2.txt");

			Dictionary<string, string> rules = new Dictionary<string, string>();
			List<string> messages = new List<string>();
			foreach (string input in programList)
			{
				if (input == "")
					continue;

				string[] split = input.Split(": ");
				if (split.Length > 1)
					rules.Add(split[0], split[1]);
				else
					messages.Add(input);
			}
		

			foreach ((string key, string value) in rules.ToList())
			{
				rules[key] = HandleRule(value, rules, 0);
			}

			int total = 0;
			foreach (string message in messages)
			{
				Regex regex = new Regex(@"^"+rules["0"].Replace(" ", "")+"$");
				if (regex.Matches(message).Count > 0)
					total++;
			}
			
			// 211 too low
			Console.WriteLine($"The total matches are {total}");

		}

		private static string HandleRule(string s, Dictionary<string, string> rules, int depth)
		{
			if (depth > 12)
			{
				return "42 31";
			}
			string[] split = s.Split(" ");
			Regex regex = new Regex(@"\d+");
			for (int i = 0; i < split.Length; i++)
			{
				if (regex.Matches(split[i]).Count > 0)
				{
					split[i] = "(" + HandleRule(rules[split[i]], rules, ++depth) + ")";
				}
			}
			return string.Join(" ", split).Replace("\"", "");
		}
	}
}