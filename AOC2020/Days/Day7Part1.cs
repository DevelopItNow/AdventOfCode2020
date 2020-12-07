using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day7Part1
	{
		private List<string> _bagsWithShinyGold = new List<string>();
		private IDictionary<string, List<string>> _bags = new Dictionary<string, List<string>>();
		private string _bagRegex = @"\d+ (\w* \w* \w*)";

		public Day7Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day7-1.txt");
			
			foreach (string rule in programList)
			{
				if (rule.Contains("shiny gold bag") && !rule.StartsWith("shiny gold bag"))
				{
					_bagsWithShinyGold.Add(rule.Split(" contain")[0]);
					string bagName = rule.Split(" contain ")[0];
					List<string> groups = Regex.Matches(rule, _bagRegex).Select(match => match.Value.Substring(match.Value.IndexOf(" ") + 1)).ToList();
					_bags.Add(bagName, groups);
				}
				else
				{
					string bagName = rule.Split(" contain ")[0];
					if (rule.Contains("contain no other bags"))
					{
						_bags.Add(bagName, new List<string>());
					}
					else
					{
						List<string> groups = Regex.Matches(rule, _bagRegex).Select(match => match.Value.Substring(match.Value.IndexOf(" ") + 1)).ToList();
						_bags.Add(bagName, groups);
					}
					
				}
			}

			int total = 0;
			foreach (KeyValuePair<string, List<string>> rule in _bags)
			{
				if (rule.Value.Contains("shiny gold bag") || rule.Value.Contains("shiny gold bags"))
				{
					total++;
					continue;
				}
				if (CanHoldShinyBag(rule))
					total++;
			}
			
			Console.WriteLine($"Total bags: {total}");
		}

		private bool CanHoldShinyBag(KeyValuePair<string, List<string>> rule)
		{
			if (rule.Key == null)
				return false;
			
			if(rule.Value.Count == 0)
				return false;

			foreach (string item in rule.Value)
			{
				bool returnValue = _bagsWithShinyGold.Contains(item) || _bagsWithShinyGold.Contains(item + "s");
				if (returnValue)
					return true;
				string name = item;
				if (!name.EndsWith("s"))
					name += "s";
				returnValue = CanHoldShinyBag(new KeyValuePair<string, List<string>>(name, _bags[name]));
				if (returnValue)
					return true;
			}
			
			
			return false;
		}
	}
}