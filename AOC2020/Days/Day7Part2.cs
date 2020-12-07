using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day7Part2
	{
		private IDictionary<string, List<Bag>> _bags = new Dictionary<string, List<Bag>>();
		private string _bagRegex = @"\d+ (\w* \w* \w*)";

		public Day7Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day7-1.txt");
			
			foreach (string rule in programList)
			{
				string bagName = rule.Split(" contain ")[0];
				if (rule.Contains("contain no other bags"))
				{
					_bags.Add(bagName, new List<Bag>());
				}
				else
				{
					List<Bag> groups = Regex.Matches(rule, _bagRegex).Select(match =>
					{
						int spaceLocation = match.Value.IndexOf(" ");
						int count = Convert.ToInt32(match.Value.Substring(0, spaceLocation));
						string name = match.Value.Substring(spaceLocation + 1);
						return new Bag() {Count = count, Name = name};
					}).ToList();
					_bags.Add(bagName, groups);
				}
			}

			List<Bag> shinyGoldBag = _bags.FirstOrDefault(f => f.Key == "shiny gold bags").Value;
			int total = BagsCount(shinyGoldBag);
			
			Console.WriteLine($"Total bags: {total}");
		}

		private int BagsCount(List<Bag> bag)
		{
			int counter = 0;
			foreach (Bag bagInfo in bag)
			{
				string name = bagInfo.Name;
				if (!name.EndsWith("s"))
					name += "s";
				List<Bag> bagList = _bags.FirstOrDefault(f => f.Key == name).Value;
				if (bagList.Count != 0)
					counter += bagInfo.Count * BagsCount(bagList);
				
				counter += bagInfo.Count;
			}
			return counter;
		}
	}

	public class Bag
	{
		public int Count { get; set; }
		public string Name { get; set; }
	}
}