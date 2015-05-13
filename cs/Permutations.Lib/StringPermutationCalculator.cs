using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations.Lib
{
	/// <summary>
	/// All the permutations of a list of n items
	/// consist of each of the n items combined with all
	/// the permutations of the list without the actual item.
	/// So if you have a list of items (a,b,c), all the permutations
	/// are ((a + permutations(b,c) + (b + permutations(a, c) + (c + permutations(a,b)).
	/// 
	/// http://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
	/// </summary>
	public class StringPermutationCalculator
	{
		public List<string> ExecuteUsingPermutations(string input)
		{
			var permutator = new Permutator<char>();

			var converted = input.ToCharArray().ToList();
			var result = new List<string>();
			foreach (var permutation in permutator.Permute(converted))
			{
				var output = new string(permutation.ToArray());
				result.Add(output);
			}

			return result;
		}

		public List<string> ExecuteLinq(string[] input)
		{
			var result = new List<string>();

			input
				.GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
				.Where(g => g.Count() > 1)
				.ToList()
				.ForEach(g => result.Add(string.Join(" ", g)));

			return result;
		}
	}
}