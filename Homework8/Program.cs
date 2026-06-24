using System;
using System.Collections.Generic;
using System.Linq;

class Solutions
{
    static int CountPowersInRange(int a, int b, int n)
    {
        int count = 0;
        for (int i = 1; ; i++)
        {
            double power = Math.Pow(i, n);
            if (power > b) break;
            if (power >= a && power <= b)
                count++;
        }
        return count;
    }
    
    static int CountSockPairs(string socks)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach (char sock in socks)
        {
            if (counts.ContainsKey(sock))
                counts[sock]++;
            else
                counts[sock] = 1;
        }

        int pairs = 0;
        foreach (var kvp in counts)
            pairs += kvp.Value / 2;

        return pairs;
    }

    static string LongestCommonSuffix(string s1, string s2)
    {
        int i = s1.Length - 1;
        int j = s2.Length - 1;
        int length = 0;

        while (i >= 0 && j >= 0 && s1[i] == s2[j])
        {
            length++;
            i--;
            j--;
        }

        return s1.Substring(s1.Length - length);
    }
    
    static void ProcessList<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Console.WriteLine("სია ცარიელია.");
            return;
        }

        switch (list)
        {
            case List<string> stringList:
                stringList.ForEach(item => Console.WriteLine(item.ToUpper()));
                break;

            case List<int> intList:
                Console.WriteLine(intList.Sum());
                break;

            case List<bool> boolList:
                Console.WriteLine($"First Element is {boolList.First()}");
                Console.WriteLine($"Last Element is {boolList.Last()}");
                Console.WriteLine($"Middle Element is {boolList[boolList.Count / 2]}");
                break;

            default:
                Console.WriteLine("type not defined correctly");
                break;
        }
    }

    static void PrintDigitsRecursive(int number, bool isFirst = true)
    {
        if (number < 0) number = -number;

        if (number < 10)
        {
            if (!isFirst) Console.Write(" - ");
            Console.Write(number);
            return;
        }

        PrintDigitsRecursive(number / 10, isFirst);
        Console.Write(" - ");
        Console.Write(number % 10);
    }

    static bool ContainsDuplicates(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in nums)
        {
            if (!seen.Add(num))
                return true;
        }
        return false;
    }

    static void Main(string[] args)
{
    bool running = true;
    while (running)
    {
        Console.WriteLine("\n Choose a function");
        Console.WriteLine("1. CountPowersInRange");
        Console.WriteLine("2. CountSockPairs");
        Console.WriteLine("3. LongestCommonSuffix");
        Console.WriteLine("4. ProcessList");
        Console.WriteLine("5. PrintDigitsRecursive");
        Console.WriteLine("6. ContainsDuplicates");
        Console.WriteLine("0. Exit");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter a (lower bound): ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter b (upper bound): ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Enter n (exponent): ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {CountPowersInRange(a, b, n)}");
                break;

            case "2":
                Console.Write("Enter socks string (e.g. AABBCC): ");
                string socks = Console.ReadLine();
                Console.WriteLine($"Pairs: {CountSockPairs(socks)}");
                break;

            case "3":
                Console.Write("Enter first string: ");
                string s1 = Console.ReadLine();
                Console.Write("Enter second string: ");
                string s2 = Console.ReadLine();
                Console.WriteLine($"Longest Common Suffix: \"{LongestCommonSuffix(s1, s2)}\"");
                break;

            case "4":
                Console.WriteLine("Choose list type:");
                Console.WriteLine("  1. List<int>");
                Console.WriteLine("  2. List<string>");
                Console.WriteLine("  3. List<bool>");
                Console.Write("Your choice: ");
                string listType = Console.ReadLine();

                Console.Write("Enter elements separated by spaces: ");
                string[] elements = Console.ReadLine().Split(' ');

                if (listType == "1")
                {
                    var intList = elements.Select(int.Parse).ToList();
                    ProcessList(intList);
                }
                else if (listType == "2")
                {
                    var stringList = elements.ToList();
                    ProcessList(stringList);
                }
                else if (listType == "3")
                {
                    var boolList = elements.Select(e => e.ToLower() == "true").ToList();
                    ProcessList(boolList);
                }
                else
                {
                    Console.WriteLine("Invalid list type.");
                }
                break;

            case "5":
                Console.Write("Enter a number: ");
                int number = int.Parse(Console.ReadLine());
                PrintDigitsRecursive(number);
                Console.WriteLine();
                break;

            case "6":
                Console.Write("Enter numbers separated by spaces: ");
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine($"Contains duplicates: {ContainsDuplicates(nums)}");
                break;

            case "0":
                running = false;
                break;

            default:
                Console.WriteLine("Invalid choice, try again.");
                break;
        }
    }
}
}