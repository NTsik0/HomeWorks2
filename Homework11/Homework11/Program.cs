using System;
using System.IO;
using System.Text.Json;
using System.Xml;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Task 1 ===");
        Task1();

        Console.WriteLine("\n=== Task 2 ===");
        Task2();

        Console.WriteLine("\n=== Task 3 ===");
        Task3();

        Console.WriteLine("\n=== Task 4 ===");
        Task4();

        Console.WriteLine("\n=== Task 5 ===");
        Task5();
    }

    #region Task1
    static void Task1()
    {
        string path = "lines.txt";
        if (!File.Exists(path))
            File.Create(path).Close();

        Console.Write("რამდენი ხაზი? ");
        int n = int.Parse(Console.ReadLine()!);

        string[] lines = new string[n];
        for (int i = 0; i < n; i++)
            lines[i] = Console.ReadLine()!;

        File.WriteAllLines(path, lines);

        string[] saved = File.ReadAllLines(path);
        Console.WriteLine(saved[^1]);
    }
    #endregion

    #region Task2
    static void Task2()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine()!);

        string path = "multiplication.txt";
        using var sw = new StreamWriter(path);

        for (int row = 1; row <= 9; row++)
        {
            string line = "";
            for (int col = 1; col <= n; col++)
            {
                line += $"{col} * {row} = {col * row}";
                if (col < n) line += " | ";
            }
            sw.WriteLine(line);
        }

        Console.WriteLine($"ტაბულა შენახულია: {path}");
    }
    #endregion

    #region Task3
    static void Task3()
    {
        Console.Write("სტრინგი: ");
        string input = Console.ReadLine()!;
        Console.Write("N (ნაწილები): ");
        int n = int.Parse(Console.ReadLine()!);

        int size = (int)Math.Ceiling((double)input.Length / n);
        string xmlPath = "output.xml";

        var settings = new XmlWriterSettings { Indent = true };
        using var writer = XmlWriter.Create(xmlPath, settings);
        writer.WriteStartDocument();
        writer.WriteStartElement("root");

        for (int i = 0; i < n; i++)
        {
            int start = i * size;
            if (start >= input.Length) break;
            string part = input.Substring(start, Math.Min(size, input.Length - start));
            writer.WriteStartElement(part);
            writer.WriteString($"string {i + 1}");
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        Console.WriteLine($"XML შენახულია: {xmlPath}");
    }
    #endregion

    #region Task4
    static void Task4()
    {
        string jsonPath = "birthday.json";
        if (!File.Exists(jsonPath))
        {
            File.WriteAllText(jsonPath, """
            {
                "currentDate": "June 14, 2022",
                "birthday": "June 20, 2022"
            }
            """);
        }

        string json = File.ReadAllText(jsonPath);
        var doc = JsonDocument.Parse(json);
        string currentStr = doc.RootElement.GetProperty("currentDate").GetString()!;
        string birthdayStr = doc.RootElement.GetProperty("birthday").GetString()!;

        DateTime current = DateTime.Parse(currentStr);
        DateTime birthday = DateTime.Parse(birthdayStr);
        int days = (birthday - current).Days;

        Console.WriteLine(days >= 0 ? days.ToString() : "დაბადების დღე გასულია!");
    }
    #endregion

    #region Task5
    static void Task5()
    {
        string jsonPath = "cipher_input.json";
        if (!File.Exists(jsonPath))
        {
            File.WriteAllText(jsonPath, """
            {
                "word": "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "key": "7"
            }
            """);
        }

        string json = File.ReadAllText(jsonPath);
        var doc = JsonDocument.Parse(json);
        string word = doc.RootElement.GetProperty("word").GetString()!;
        int key = int.Parse(doc.RootElement.GetProperty("key").GetString()!);

        string cipher = "";
        foreach (char c in word.ToUpper())
            cipher += char.IsLetter(c) ? (char)(((c - 'A' + key) % 26) + 'A') : c;

        var result = new { Cipher = cipher };
        string output = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText("cipher_output.json", output);
        Console.WriteLine(output);
    }
    #endregion
}
