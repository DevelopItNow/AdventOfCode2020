using System;
using System.IO;

namespace AOC2020
{
	public class Utils
	{
		public static string[] LoadFileToStringArray(string str)
		{
			return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str));
		}
		
		public static string LoadFile(string str)
		{
			return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Res\\" + str));
		}
	}
}