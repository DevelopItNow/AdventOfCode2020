using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day23Part1
	{
		private const int MAX_LOOP = 100;

		public Day23Part1()
		{
			// List<int> input = Array.ConvertAll("389125467".ToArray(), c => (int) char.GetNumericValue(c)).ToList();
			List<int> input = Array.ConvertAll("253149867".ToArray(), c => (int) char.GetNumericValue(c)).ToList();

			int length = input.Count;
			int max = input.Max();

			int current = 0;
			List<int> extractedValues = new List<int>();
			for (int i = 0; i < MAX_LOOP; i++)
			{
				int currentValue = input[current];

				int index = (current + 1) % length;

				for (int j = 0; j < 3; j++)
				{
					if (index >= input.Count)
						index = 0;
					extractedValues.Add(input[index]);
					input.RemoveAt(index);
				}

				// find first value
				int newLocationValue = currentValue - 1 <= 0 ? max : currentValue - 1;
				while (true)
				{
					if (!extractedValues.Contains(newLocationValue))
						break;

					newLocationValue = newLocationValue - 1 <= 0 ? max : newLocationValue - 1;
				}
				
				int newLocation = input.IndexOf(newLocationValue) + 1;
				input.InsertRange(newLocation, extractedValues);

				// Cleanup
				extractedValues.Clear();
				current = (input.IndexOf(currentValue) + 1) % length;
			}

			string answer = "";
			int indexOne = input.IndexOf(1);
			while (true)
			{
				indexOne = (indexOne + 1) % length;
				int val = input[indexOne];
				if (val == 1)
					break;

				answer += val;
			}
			
			Console.WriteLine($"The final answer is: {answer}");
		}
	}
}