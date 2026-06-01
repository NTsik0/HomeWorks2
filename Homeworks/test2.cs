using System;

class Program
{
    static void Main()
    {
        int[] arr = { 12, 5, 8, 20, 3, 15 };

        int min = arr[0];
        int max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }

            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        Console.WriteLine("Minimum element: " + min);
        Console.WriteLine("Maximum element: " + max);
    }
}