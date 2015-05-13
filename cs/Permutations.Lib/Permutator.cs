using System.Collections.Generic;

namespace Permutations.Lib
{
	public class Permutator<T>
	{
		public IEnumerable<List<T>> Permute(List<T> inputList)
		{
			if (inputList.Count == 2)
			{
				yield return new List<T>(inputList); // first element is always the original
				yield return new List<T> { inputList[1], inputList[0] }; // second element is always the two elements swapped
			}
			else
			{
				foreach (var element in inputList)
				{
					var rlist = new List<T>(inputList);
					rlist.Remove(element); // remove the first element
					foreach (var retlist in Permute(rlist)) // find permutations of the rest of the list
					{
						retlist.Insert(0, element);
						yield return retlist;
					}
				}
			}
		}
	}
}