using System;
using System.IO;

namespace GkMa
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			SolveUsingOurMa(binary: true);
		}

		private static readonly string[] problemNames
			= new string[]
			  	{
			  		"40d198",
			  		"40kroa200",
			  		"40krob200",
			  		"41gr202",
			  		"45ts225",
			  		"45tsp225",
			  		"46pr226",
			  		"46gr229",
			  		"53gil262",
			  		"53pr264",
			  		"56a280",
			  		"60pr299",
			  		"64lin318",
			  		"65rbg323",
			  		"72rbg358",
			  		"80rd400",
			  		"81rbg403",
			  		"84fl417",
			  		"87gr431",
			  		"88pr439",
			  		"89pcb442",
			  		"89rbg443",
			  		"99d493",
			  		"107ali535",
			  		"107att532",
			  		"107si535",
			  		"113pa561",
			  		"115u574",
			  		"115rat575",
			  		"131p654",
			  		"132d657",
			  		"134gr666",
			  		"145u724",
			  		"157rat783",
			  		"200dsj1000",
			  		"201pr1002",
			  		"207si1032",
			  		"212u1060",
			  		"217vm1084",
			  	};

		public static void SolveUsingOurMa(bool binary)
		{
			foreach (string problemName in problemNames)
			{
				//try
				{
					FileInfo fileInfo = new FileInfo(Helper.GetFullFileName("GTSP\\" + problemName + (binary ? ".gtsp" : ".txt")));

					int vc, cc;
					Helper.ParseGtspFileName(fileInfo.Name, out cc, out vc);

					Helper.ResetRand();

					string instanceName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
					Console.Title = instanceName;
					for (int i = 0; i < 10; i++)
					{
						Console.Title += ".";
						OurSolver solver = new OurSolver(fileInfo.FullName, binary);
						solver.Solve();

						using (StreamWriter writer = new StreamWriter(Helper.GetFullFileName("solved.txt"), true))
						{
							writer.WriteLine(
								"{0}\t{1}\t{2}\t{3}\t{4}",
								DateTime.Now,
								instanceName,
								solver.Len,
								solver.Milliseconds,
								solver.GenerationCount);
						}
					}
				}
/*
				catch (FileNotFoundException ex)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("File not found: \"{0}\"\nProbably, the GTSP instance file is not present at the required location.\n", ex.Message);
					Console.ForegroundColor = ConsoleColor.White;
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Unhandled exception: {0}.\n", ex.Message);
					Console.ForegroundColor = ConsoleColor.White;
					break;
				}
*/
			}
		}
	}
}