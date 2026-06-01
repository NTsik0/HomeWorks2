using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

    static void Task1()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .ToArray();

        int[] evens = numbers.Where(x => x % 2 == 0).ToArray();
        int[] odds  = numbers.Where(x => x % 2 != 0).ToArray();

        Console.WriteLine("array1 : " + string.Join(" ", evens));
        Console.WriteLine("array2 : " + string.Join(" ", odds));
    }

    static void Task2()
    {
        var contacts = new Dictionary<string, string>();

        while (true)
        {
            Console.WriteLine("\n1. Add  2. Update  3. Delete  4. List  5. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Phone: ");
                string phone = Console.ReadLine();
                contacts[name] = phone;
                Console.WriteLine("Contact added!");
            }
            else if (choice == "2")
            {
                Console.Write("Name to update: ");
                string name = Console.ReadLine();
                if (contacts.ContainsKey(name))
                {
                    Console.Write("New phone: ");
                    contacts[name] = Console.ReadLine();
                    Console.WriteLine("Updated!");
                }
                else Console.WriteLine("Not found.");
            }
            else if (choice == "3")
            {
                Console.Write("Name to delete: ");
                string name = Console.ReadLine();
                if (contacts.Remove(name))
                    Console.WriteLine("Deleted!");
                else
                    Console.WriteLine("Not found.");
            }
            else if (choice == "4")
            {
                var sorted = contacts
                    .OrderBy(c => c.Key)
                    .ToList();

                foreach (var c in sorted)
                    Console.WriteLine($"{c.Key} -> {c.Value}");
            }
            else if (choice == "5") break;
        }
    }

    static void Task3()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .ToArray();

        numbers
            .GroupBy(x => x)
            .OrderBy(g => g.Key)
            .Select(g => new { Value = g.Key, Count = g.Count(), Sum = g.Sum() })
            .ToList()
            .ForEach(g => Console.WriteLine($"{g.Value} appears {g.Count} times sum {g.Sum}"));
    }

    static void Task4()
    {
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        numbers
            .OrderByDescending(x => x)
            .Take(n)
            .OrderBy(x => x)
            .ToList()
            .ForEach(x => Console.Write(x + " "));
    }
}