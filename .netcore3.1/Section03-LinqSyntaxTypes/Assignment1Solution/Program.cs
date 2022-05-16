using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1:
            // Write a simple C# program to declare a list of integer numbers, 
            // followed by writing queries using both query and method syntax 
            // to calculate their square (num * num), and finally print them to the console.

            // Step 1: Getting data source
            List<int> numbers = new List<int>() {1,2,3,4,5};

            // Query syntax
            // Step 2: Writing query 
            // Step 3: Executing query 
            Console.WriteLine("Query syntax:");
            IEnumerable<int> query = from n in numbers    
                                        select n * n;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            // Method syntax
            // Step 2: Writing query 
            // Step 3: Executing query 
            Console.WriteLine("Method syntax:");
            IEnumerable<int> methodQuery = numbers.Select(number => number * number);
            foreach (var item in methodQuery)
            {
                Console.WriteLine(item);
            }            
        }
    }
}
