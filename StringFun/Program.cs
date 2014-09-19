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

            //comb1("abc");
            comb2("abcd");


		    Console.ReadLine();
		}

        // print all subsets of the characters in s
	    public static void comb1(String s)
	    {
	        comb1("", s);
	    }

        // print all subsets of the remaining elements, with given prefix 
        private static void comb1(String prefix, String s)
        {
            if (s.Length > 0) 
            {
                Console.WriteLine(prefix + s[0]);
                comb1(prefix + s[0], s.Substring(1));
                comb1(prefix, s.Substring(1));
            }
        }

        // alternate implementation
	    public static void comb2(String s) 
        {
	        comb2("", s);
	    }

        private static void comb2(String prefix, String s)
        {
            Console.WriteLine(prefix);
            for (int i = 0; i < s.Length; i++)
            {
                comb2(prefix + s[i], s.Substring(i + 1));
            }   
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
