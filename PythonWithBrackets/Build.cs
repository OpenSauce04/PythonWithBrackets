using System;
using System.IO;

namespace PythonWithBrackets
{
	public class Parse
	{
		private static int indentCount = 0;
		private static int nextIndentCount = 0;
		public static string ParseLine(String lineIn)
		{
			string line = lineIn;
			indentCount += nextIndentCount;
			nextIndentCount = 0;
			if (line.EndsWith('{'))
			{
				line = line.TrimEnd('{');
				line += ':';
				nextIndentCount++;
			}
			if (line == "}") 
			{
				indentCount--;
				return "";
			}
			return new String(' ', indentCount*2) + line;
		}
	}
	partial class Program
	{
		
		static void Build()
		{
			Console.WriteLine("Building...");
			DirectoryCopy.Copy("./", "pwbBuild", true);
			string[] files = Directory.GetFiles("./pwbBuild", "*.pyb", SearchOption.AllDirectories);
			foreach (var file in files)
			{
				var lines = File.ReadLines(file);
				string newFile = "";
				foreach (var line in lines)
				{
					newFile += Parse.ParseLine(line);
					newFile += '\n';
				}
				Console.WriteLine(newFile);
			}

		}
	}
}
