using System;
namespace Homework2Friend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Nikoloz Tskiaridze"); 

            // Input
            Console.Write("Input text: ");
            string inputData = Console.ReadLine();

            Console.WriteLine("Output:");
            Console.WriteLine(inputData);
        }
    }
}