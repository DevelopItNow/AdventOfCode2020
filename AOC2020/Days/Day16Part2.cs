using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2020.Days
{
	public class Day16Part2
	{
		public Day16Part2()
		{
			string[] programList = Utils.LoadFileToStringArray("Day16-1.txt");
			
			Dictionary<string, Tuple<int, int, int, int>> ranges = new Dictionary<string, Tuple<int, int, int, int>>();

			string myTicket = "";
			List<string> validTickets = new List<string>();
			int step = 0;
			
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
						Match match = Regex.Match(input, @"([a-z ]+): (\d+)-(\d+) or (\d+)-(\d+)", RegexOptions.Compiled);
						if (match.Success)
						{
							ranges[match.Groups[1].Value] = new Tuple<int, int, int, int>(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
						}
						break;
					}
					case 1:
						myTicket = input;
						break;
					case 2:
					{
						int[] values = input.Split(",").Select(s => Convert.ToInt32(s)).ToArray();
						bool inRange = true;
						foreach (int value in values)
						{
							bool foundSomething = false;
							foreach (KeyValuePair<string, Tuple<int, int, int, int>> range in ranges)
							{
								if ((range.Value.Item1 <= value && value <= range.Value.Item2) || (range.Value.Item3 <= value && value <= range.Value.Item4))
								{
									foundSomething = true;
									break;
								}
							}

							if (foundSomething) continue;
							inRange = false;
							break;
						}
						if (inRange)
							validTickets.Add(input);

						break;
					}
				}
			}

			List<Dictionary<int, List<string>>> validationList = new List<Dictionary<int, List<string>>>();

			int t = 0;
			while (t < validTickets.Count)
			{
				int[] values = validTickets[t].Split(",").Select(s => Convert.ToInt32(s)).ToArray();
				Dictionary<int, List<string>> matches = new Dictionary<int, List<string>>();
				for (int i = 0; i < values.Length; i++)
				{
					int val = values[i];
					matches.Add(i, new List<string>());
					foreach (KeyValuePair<string, Tuple<int, int, int, int>> range in ranges.Where(range => (range.Value.Item1 <= val && val <= range.Value.Item2) || (range.Value.Item3 <= val && val <= range.Value.Item4)))
					{
						matches[i].Add(range.Key);
					}
				}
				validationList.Add(matches);
				t++;
			}
			
			Dictionary<int, List<string>> columnWithNameList = new Dictionary<int, List<string>>();

			while (columnWithNameList.Count < ranges.Count)
			{
				Dictionary<int, List<string>> validation = validationList[0];

				for (int j = 0; j < validation.Count; j++)
				{
					List<string> line = validation.ElementAt(j).Value;
					for (int i = 1; i < validationList.Count; i++)
					{
						if (line.Count == 1)
							break;
						List<string> values = validationList[i][j];
						if (values.Count != 20)
						{
							int q = 0;
						}

						List<string> newLine = values.Where(value => line.Contains(value)).ToList();

						line = newLine;
					}

					columnWithNameList.Add(j, line);
				}
			}

			
			Dictionary<int, string> columnWithName = new Dictionary<int, string>();

			while (true)
			{
				bool foundSomething = false;
				for (int i = 0; i < columnWithNameList.Count; i++)
				{
					KeyValuePair<int, List<string>> pair = columnWithNameList.ElementAt(i);
					if (pair.Value.Count != 1) continue;
					columnWithName.Add(pair.Key, pair.Value[^1]);
					for (int j = 0; j < columnWithNameList.Count; j++)
					{
						if (i == j)
							continue;
						KeyValuePair<int, List<string>> inner = columnWithNameList.ElementAt(j);

						if (inner.Value.Contains(pair.Value[^1]))
							inner.Value.Remove(pair.Value[^1]);
					}
					foundSomething = true;
					columnWithNameList.Remove(pair.Key);

				}

				if (!foundSomething)
					break;
			}
			
			int[] myTicketArr = myTicket.Split(",").Select(s => Convert.ToInt32(s)).ToArray();
			long total = columnWithName.Where(value => value.Value.StartsWith("departure")).Aggregate<KeyValuePair<int, string>, long>(0, (current, value) => (current == 0) ? myTicketArr[value.Key] : current * myTicketArr[value.Key]);
			
			Console.WriteLine($"The scanning error rate is {total}");
		}
	}
}