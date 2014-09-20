using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFun
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Permutations("", "ABCD");

            //comb1("abc");
            //comb2("abcd");

            //Permutations(new string[] { "A", "B", "C", "D" });

            //Permutations(new string[] { "A", "B", "C" });

           // Permutations(new string[] {"AB", "BC", "CD"});


             //int [] arr = {1, 2, 3};
            // int r = 3;
             //printCombination(arr, arr.Length, r);

            //var arr = new string[] {"A", "B", "C"};
            var arr = new string[] {"AB", "BC", "CDG"};
            //permute(arr, 0);

            //var result = strNumToIntNum("121");
            //Console.WriteLine(result);

            //result = strNumToIntNum2("121");
            //Console.WriteLine(result);


            var result = intToString(124);
            Console.WriteLine(result);

            Console.ReadLine();
        }

        static void permute(string[] array, int index)
        {
            if (array.Length == index)
            {
                printArray(array);
                return;
            }
            int j = index;
            for (j = index; j < array.Length; j++)
            {
                swap(ref array[index], ref array[j]);
                permute(array, index + 1);
                swap(ref array[index], ref array[j]);
            }
        }

        static private void printArray(string[] array)
        {
            foreach (var i in array)
            {
                Console.Write(i);
                Console.Write(" ");
            }

            Console.WriteLine();
        }


        static private void swap(ref string a, ref string b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

/*
        לכתוב פונקציה שמקבלת מחרוזת שמייצגת מספר והופכת אותה למספר.
נתתי פתרון שעובר על המחרוזת משמאל לימין, הוא ביקש גם פתרון שעובר על המחרוזת מימין לשמאל ושאל איזה פתרון יותר יעיל.*/

        public static int strNumToIntNum(string strNumber)
        {
            int result = 0;
            //from left to right
            for (int i = 0; i < strNumber.Length; i++)
            {
                result += (strNumber[i] - '0') * (int)Math.Pow(10, (strNumber.Length - i - 1));
            }

            return result;
        }

        public static int strNumToIntNum2(string strNumber)
        {
            int result = 0;
            //from right to left
            for (int i = strNumber.Length - 1; i >= 0; i--)
            {
                result += (strNumber[i] - '0') * (int)Math.Pow(10, (strNumber.Length - i - 1));
            }

            return result;
        }

        public static string intToString(int num)
        {
            string result = null;
            int length = 0;
            var savedNum = num;

            //calc length of num
            do
            {
                length++;
            } while ((num = num / 10) > 0);


            for (int i = 0; i < length; i++)
            {
                result += savedNum / (int)Math.Pow(10, length - i - 1) % 10;
            }

            return result;
        }
        
        // The main function that prints all combinations of size r
        // in arr[] of size n. This function mainly uses combinationUtil()
/*        public static void printCombination(int[] arr, int n, int size)
        {
            // A temporary array to store all combination one by one
            int [] data = new int[size];
 
            // Print all combination using temprary array 'data[]'
            combinationUtil(arr, data, 0, n - 1, 0, size);
        }
 
        /* arr[]  ---> Input Array
           data[] ---> Temporary array to store current combination
           start & end ---> Staring and Ending indexes in arr[]
           index  ---> Current index in data[]
           r ---> Size of a combination to be printed #1#
        public static void combinationUtil(int[] arr, int[] data, int start, int end, int index, int r)
        {
            // Current combination is ready to be printed, print it
            if (index == r)
            {
                for (int j=0; j<r; j++)
                    Console.Write(data[j]);
                Console.WriteLine();
                return;
            }
 
            // replace index with all possible elements. The condition
            // "end-index+1 >= r-index" makes sure that including one element
            // at index will make a combination with remaining elements
            // at remaining positions
            for (int index=start; index<=end && end-index+1 >= r-index; index++)
            {
                data[index] = arr[index];
                combinationUtil(arr, data, index+1, end, index+1, r);
            }
        }*/

/*	    public static void Permutations(string [] arr)
	    {
	        string str = String.Join("", arr);
            Console.WriteLine(str);

	        permute("", str);
	    }

	    private static void permute(string perfix, string str)
	    {
	        if (str.Length == 0)
	        {
                Console.WriteLine(perfix);
	        }
            for (int index = 0; index < str.Length; index++)
            {
                permute(perfix + str[index], str.Substring(0, index) + str.Substring(index + 1));
            }
	    }*/


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