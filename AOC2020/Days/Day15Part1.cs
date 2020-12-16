using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Days
{
	public class Day15Part1
	{
		public Day15Part1()
		{
			Dictionary<int, int> numbersUsed = new Dictionary<int, int>();
			List<int> spokenNumbers = new List<int>();
			// Test data
			// string[] inputString = "0,3,6".Split(',');
			// string[] inputString = "1,3,2".Split(',');
			// string[] inputString = "2,1,3".Split(',');
			// string[] inputString = "1,2,3".Split(',');
			// string[] inputString = "2,3,1".Split(',');
			// string[] inputString = "3,2,1".Split(',');
			// string[] inputString = "3,1,2".Split(',');
			
			// Real input
			string[] inputString = "20,0,1,11,6,3".Split(',');
			int[] input = Array.ConvertAll(inputString, int.Parse);

			int i = 1;
			foreach (int number in input)
			{
				spokenNumbers.Add(number);
				numbersUsed.Add(i, number);
				i++;
			}
			
			spokenNumbers.Add(0);
			numbersUsed.Add(i, 0);
			i++;

			int lastNumber = spokenNumbers[^1];
			while(i <= 2020)
			{
				if (numbersUsed.ContainsValue(lastNumber))
				{
					List<KeyValuePair<int, int>> a = numbersUsed.Where(a => a.Value == lastNumber).ToList();
					if (a.Count < 2)
					{
						spokenNumbers.Add(0);
						numbersUsed.Add(i, 0);
						lastNumber = 0;
						i++;
						continue;
					}
					KeyValuePair<int, int> last = a[^1];
					KeyValuePair<int, int> second = a[^2];
					int diff = last.Key - second.Key;
					lastNumber = diff;
					spokenNumbers.Add(diff);
					numbersUsed.Add(i, diff);
				}
				
				i++;
			}
			Console.WriteLine($"The last number was {lastNumber}");
		}
	}
}