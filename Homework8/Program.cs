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

        if (list is List<string> stringList)
        {
            foreach (var item in stringList)
                Console.WriteLine(item.ToUpper());
        }
        else if (list is List<int> intList)
        {
            Console.WriteLine(intList.Sum());
        }
        else if (list is List<bool> boolList)
        {
            int middleIndex = boolList.Count / 2;
            Console.WriteLine($"First Element is {boolList[0]}");
            Console.WriteLine($"Last Element is {boolList[^1]}");
            Console.WriteLine($"Middle Element is {boolList[middleIndex]}");
        }
        else
        {
            Console.WriteLine("უცნობი ტიპი.");
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
        Console.WriteLine("1");
        Console.WriteLine(CountPowersInRange(49, 71, 2));  
        Console.WriteLine(CountPowersInRange(2, 27, 4));   

        Console.WriteLine("\n 2");
        Console.WriteLine(CountSockPairs("AA"));       // 1
        Console.WriteLine(CountSockPairs("AABBCC"));   // 3
        Console.WriteLine(CountSockPairs("AABBC"));    // 2
        Console.WriteLine(CountSockPairs("ABABC"));    // 2
        Console.WriteLine(CountSockPairs("AAABB"));    // 2

        Console.WriteLine("\n 3 ");
        Console.WriteLine(LongestCommonSuffix("multiplication", "substraction"));     
        Console.WriteLine(LongestCommonSuffix("Some Random Text", "It is Some Random Text")); 

        Console.WriteLine("\n 4");
        ProcessList(new List<int> { 5, 5 });
        Console.WriteLine();
        ProcessList(new List<string> { "test", "random", "programming", "word" });
        Console.WriteLine();
        ProcessList(new List<bool> { true, false, true, false, true, false, false });

        Console.WriteLine("\n 5");
        PrintDigitsRecursive(12345);
        Console.WriteLine();

        Console.WriteLine("\n 6");
        Console.WriteLine(ContainsDuplicates(new int[] { 1, 2, 3, 1 }));  // True
        Console.WriteLine(ContainsDuplicates(new int[] { 1, 2, 3, 4 }));  // False
    }
}