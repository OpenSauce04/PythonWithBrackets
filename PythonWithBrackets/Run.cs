using System;
using System.Diagnostics;
namespace PythonWithBrackets
{
	partial class Program
	{
		static void Run(String mainFile)
		{
			Console.Write("Running...");

			var cmdStartInfo = new ProcessStartInfo("CMD.exe", "/C python pwbBuild/" + mainFile + ".py");
			cmdStartInfo.UseShellExecute = true;
			cmdStartInfo.CreateNoWindow = false;
			cmdStartInfo.WindowStyle = ProcessWindowStyle.Normal;

			var cmdProcess = new Process();
			cmdProcess.StartInfo = cmdStartInfo;

			cmdProcess.Start();

			Console.WriteLine("done");
		}
	}
}
