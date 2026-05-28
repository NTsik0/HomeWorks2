using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Task 1: Divisible by 5");
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(num % 5 == 0 ? "Yes" : "NO");

        Console.WriteLine("\nTask 2: Calculator");
        Console.Write("Enter X: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter Y: ");
        int y = int.Parse(Console.ReadLine());

        int bigger  = Math.Max(x, y);
        int smaller = Math.Min(x, y);

        Console.WriteLine($"X+Y {x + y}");
        Console.WriteLine($"X-Y {bigger - smaller}");
        Console.WriteLine($"X*Y {x * y}");

        if (smaller == 0)
            Console.WriteLine("X/Y Not Allowed To Divide By Zero");
        else
            Console.WriteLine($"X/Y {bigger / smaller}");

        Console.WriteLine("\nTask 3: Swap Variables");
        Console.Write("Enter x: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter y: ");
        int b = int.Parse(Console.ReadLine());
        (a, b) = (b, a);
        Console.WriteLine($"x = {a} ; y = {b}");

        Console.WriteLine("\nTask 4: Multiplication Table");
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 9; i++)
            Console.WriteLine($"{n} * {i} = {n * i}");

        Console.WriteLine("\nTask 5: Even Numbers & Their Squares");
        Console.Write("Enter n: ");
        int limit = int.Parse(Console.ReadLine());
        for (int i = 2; i <= limit; i += 2)
            Console.WriteLine(i * i);
    }
}