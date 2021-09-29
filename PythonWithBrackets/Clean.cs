using System;
using System.IO;

namespace PythonWithBrackets
{
	partial class Program
	{
		static void Clean()
		{
			Console.Write("Cleaning up...");

			DirectoryInfo di = new DirectoryInfo("pwbBuild");
			foreach (FileInfo file in di.GetFiles())
			{
				file.Delete();
			}
			Directory.Delete("pwbBuild");

			Console.WriteLine("done");
		}
	}
}
