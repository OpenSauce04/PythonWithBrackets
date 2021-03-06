using System;

namespace PythonWithBrackets
{
	partial class Program
	{
		static void IncorrectUsageMessage()
		{
			Console.WriteLine("Invalid arguments specified!\n");
			Console.WriteLine("Usage:");
			Console.WriteLine("pwb -b: Build");
			Console.WriteLine("pwb -r [main file name (NO EXTENSION)]: Run");
			Console.WriteLine("pwb -br [main file name (NO EXTENSION)]: Build and run");
		}
		static void Main(string[] args)
		{
			try
			{
				switch (args[0])
				{
					case "-b":
						Build();
						break;
					case "-r":
						Build();
						Run(args[1]);
						Clean();
						break;
					case "-br":
						Build();
						Run(args[1]);
						break;
					default:
						IncorrectUsageMessage();
						break;
				}
			} catch (IndexOutOfRangeException)
			{
				IncorrectUsageMessage();
			}
		}
	}
}
