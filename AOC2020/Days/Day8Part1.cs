using System;
using System.Collections.Generic;

namespace AOC2020.Days
{
	public class Day8Part1
	{

		public Day8Part1()
		{
			string[] programList = Utils.LoadFileToStringArray("Day8-1.txt");
			
			List<int> visitedInstructions = new List<int>();
			int accumulator = 0;
			int i = 0;
			while (true)
			{
				if (i > programList.Length) break;
				if (visitedInstructions.Contains(i)) break;
				string text = programList[i];
				
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
			
			Console.WriteLine($"The accumulator has a value of: {accumulator}");
		}
	}
}