using System;

namespace PythonWithBrackets
{
	internal class Program
	{
		static void Main(string[] args)
		{
			switch(args[0])
			{
				case "-b":
					Console.WriteLine("Build");
					break;
				case "-r":
					Console.WriteLine("Run");
					break;
				case "-k":
					Console.WriteLine("Run and keep");
					break;
			}
		}
	}
}
