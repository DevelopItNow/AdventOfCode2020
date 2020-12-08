using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day8Part2
	{
		public Day8Part2()
		{
			int accumulator = 0;
			int attempt = 0;
			while (true)
			{
				accumulator = HandleInstructions(attempt);
				if (accumulator > 0)
					break;

				attempt++;
			}

			Console.WriteLine($"The accumulator has a value of: {accumulator}");
		}

		private int HandleInstructions(int attempt)
		{
			string[] programList = Utils.LoadFileToStringArray("Day8-1.txt");

			List<int> visitedInstructions = new List<int>();
			int accumulator = 0;
			int i = 0;

			int tryChangingValue = 0;
			while (true)
			{
				if (i > programList.Length - 1) break;
				if (visitedInstructions.Contains(i))
					break;
				
				string text = programList[i];

				if (text.StartsWith("nop") || text.StartsWith("jmp"))
				{
					if (tryChangingValue == attempt)
					{
						if (text.StartsWith("nop"))
							text = text.Replace("nop", "jmp");
						else if (text.StartsWith("jmp"))
							text = text.Replace("jmp", "nop");
					}

					tryChangingValue++;
				}

				visitedInstructions.Add(i);

				string instruction = text.Substring(0, 3);
				switch (instruction)
				{
					case "acc":
						accumulator += Convert.ToInt32(text.Split(" ")[1]);
						i++;
						break;
					case "jmp":
						i += Convert.ToInt32(text.Split(" ")[1]);
						break;
					case "nop":
						i++;
						break;
				}
			}
			return i >= programList.Length - 1 ? accumulator : 0;
		}
	}
}