using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFun
{
	class Program
	{
		public static void Main(string[] args)
		{
			Permutations("", "ABCD");
			SubStrings();

		    Console.ReadLine();
		}

		public static void Permutations(string prefix, string str)
		{
			int length = str.Length;
			if (length == 0)
			{
				Console.WriteLine(prefix);
			}
			else
			{
				for (int i = 0; i < length; i++)
				{
					Permutations(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1));
				}
			}
		}

		public static void SubStrings()
		{
			string set = "abcd";

			// Init list
			var subsets = new List<string>();

			// Loop over individual elements
			for (int i = 0; i < set.Length - 1; i++)
			{
				subsets.Add(set[i].ToString());

				var newSubsets = new List<string>();

				// Loop over existing subsets
				for (int j = 0; j < subsets.Count; j++)
				{
					string newSubset = subsets[j] + set[i + 1];
					newSubsets.Add(newSubset);
				}

				subsets.AddRange(newSubsets);
			}

			// Add in the last element
			subsets.Add(set[set.Length - 1].ToString());
			subsets.Add(String.Empty);
			subsets.Sort();

			Console.WriteLine(string.Join(Environment.NewLine, subsets.ToArray()));
		}
	}
}
