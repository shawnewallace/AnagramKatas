using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Policy;
using NUnit.Framework;
using Permutations.Lib;

namespace AnagramKata.tests
{
	[TestFixture]
	public class StringPermutationTests
	{
		private List<string> _result;
		private const string INPUT = "ABC";

		[SetUp]
		public void SetUp()
		{
			var calculator = new StringPermutationCalculator();
			_result = calculator.ExecuteUsingPermutations(INPUT);
		}

		[TestCase("ABC")]
		[TestCase("ACB")]
		[TestCase("BAC")]
		[TestCase("BCA")]
		[TestCase("CAB")]
		[TestCase("CBA")]
		public void it_returns_the_correct_permutations(string expected)
		{
			Assert.Contains(expected, _result);
		}

		[Test]
		public void it_finds_the_correct_number_of_permutations()
		{
			Assert.AreEqual(6, _result.Count);
		}
	}
}
