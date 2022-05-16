using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMethodSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using LINQ Method Syntax");
            // Step 1: Getting data source
            List<int> numbersLinq = new List<int>() {1,2,3,4,5,6};

            // Step 2: Writing query
            // IEnumerable<int> query = from n in numbersLinq  // Part 1: Data source
            //                             where n < 3            // Part 2: Filter    
            //                             select n;              // Part 3: Select

            // IEnumerable<int> query = numbersLinq.Where(CheckNumber);

            IEnumerable<int> query = numbersLinq.Where(i => i < 3);

            // Step 3: Executing query
            foreach(int number in query)
                Console.WriteLine(number);
        }

        static bool CheckNumber(int i)
        {
            return i < 3;
        }
    }
}
