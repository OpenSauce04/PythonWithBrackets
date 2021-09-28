using System;

namespace PythonWithBrackets
{
	partial class Program
	{
		static void ParseLine(String line)
		{
			if (line.EndsWith('{'))
			{
				line.TrimEnd('{');
				line += ':';
			}
		}
		static void Build()
		{
			Console.WriteLine("Building...");
			DirectoryCopy.Copy("./", "pwbBuild", true);
		}
	}
}
