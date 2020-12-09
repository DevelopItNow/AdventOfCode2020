using System;
using System.IO;
using System.Linq;

namespace AOC2020
{
	public class Utils
	{
		public static string[] LoadFileToStringArray(string str)
		{
			return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str));
		}
		public static int[] LoadFileToIntArray(string str)
		{
			return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str)).Select(s => int.Parse(s)).ToArray();
		}
		
		public static long[] LoadFileToLongArray(string str)
		{
			return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str)).Select(s => long.Parse(s)).ToArray();
		}
		
		public static string LoadFile(string str)
		{
			return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str));
		}
	}
}