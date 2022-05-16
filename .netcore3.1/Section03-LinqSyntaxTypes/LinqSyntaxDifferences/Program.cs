using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSyntaxDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Getting data source
            List<int> numbersLinq = new List<int>() {1,2,3,4,5,6};

            // Step 2: Writing query (Query syntax)
            IEnumerable<int> query = from n in numbersLinq     // Part 1: Data source
                                        where n < 3            // Part 2: Filter    
                                        select n;              // Part 3: Select
            
            // Step 2: Writing query (Method syntax)
            IEnumerable<int> methodQuery = numbersLinq.Where(i => i < 3)
                                                .Select(i => i);

            // Step 3: Executing query
            foreach(int number in query)
                Console.WriteLine(number);
        }
    }
}
