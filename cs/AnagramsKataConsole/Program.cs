using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Permutations.Lib;

namespace AnagramsKataConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var calculator = new StringPermutationCalculator();

			var result = new List<string>();

			Console.WriteLine("**** START WITH LINQ");

			var start = DateTime.Now;

			result = calculator.ExecuteLinq(File.ReadAllLines(@"..\..\..\..\wordlist.txt"));

			var finish = DateTime.Now;
			var duration = finish - start;

			Console.WriteLine("**** Finished LINQ in {0} seconds.", duration.TotalSeconds);
			Console.WriteLine("**** {0} sets of anagrams", result.Count);

			//foreach (var line in result)
			//{
			//	Console.WriteLine(line);
			//}

			Console.WriteLine("**** START RECURSIVE");

			start = DateTime.Now;
			
			var lines = File.ReadAllLines(@"..\..\..\..\wordlist.txt");

			foreach (var line in lines)
			{
				result = calculator.ExecuteUsingPermutations(line);
			}

			finish = DateTime.Now;
			duration = finish - start;

			Console.WriteLine("**** Finished RECURSIVE in {0} seconds.", duration.TotalSeconds);
			
			Console.WriteLine("**** DONE ****");
			Console.ReadLine();
		}
	}
}
