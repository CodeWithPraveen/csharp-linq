using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Existing .NET Features");
            List<int> numbers = new List<int>() {1,2,3,4,5,6};
            foreach(var number in numbers)
            {
                if(number < 3)
                    Console.WriteLine(number);
            }

            Console.WriteLine("Using LINQ");
            // Step 1: Getting data source
            List<int> numbersLinq = new List<int>() {1,2,3,4,5,6};

            // Step 2: Writing query
            IEnumerable<int> query = from n in numbersLinq  // Part 1: Data source
                                        where n < 3            // Part 2: Filter    
                                        select n;              // Part 3: Select

            // Step 3: Executing query
            foreach(int number in query)
                Console.WriteLine(number);
        }
    }
}
