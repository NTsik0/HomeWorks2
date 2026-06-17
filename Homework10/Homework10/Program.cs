using System;

#region Task1

public abstract class FileWorker
{
    public long MaxFileSize { get; }
    public abstract string Extension { get; }

    protected FileWorker(long maxFileSize)
    {
        MaxFileSize = maxFileSize;
    }

    public virtual void Read() => Console.WriteLine($"Reading {Extension} file (max size: {MaxFileSize} bytes)");
    public virtual void Write() => Console.WriteLine($"Writing to {Extension} file (max size: {MaxFileSize} bytes)");
    public virtual void Edit() => Console.WriteLine($"Editing {Extension} file (max size: {MaxFileSize} bytes)");
    public virtual void Delete() => Console.WriteLine($"Deleting {Extension} file");
}

public class TextFileWorker : FileWorker
{
    public override string Extension => ".txt";

    public TextFileWorker(long maxFileSize) : base(maxFileSize) { }

    public override void Read() => Console.WriteLine($"[TextFileWorker] Reading from {Extension} | limit: {MaxFileSize} bytes");
    public override void Write() => Console.WriteLine($"[TextFileWorker] Writing to {Extension} | limit: {MaxFileSize} bytes");
    public override void Edit() => Console.WriteLine($"[TextFileWorker] Editing {Extension} | limit: {MaxFileSize} bytes");
    public override void Delete() => Console.WriteLine($"[TextFileWorker] Deleting {Extension} file from disk");
}

#endregion

#region Task2

public interface FinanceOperations
{
    double CalculateLoanPercent(int month, double amountPerMonth);
    bool CheckUserHistory();
}

public class Bank : FinanceOperations
{
    private Random _rand = new Random();

    public bool CheckUserHistory() => _rand.Next(2) == 1;

    public double CalculateLoanPercent(int month, double amountPerMonth)
    {
        double total = amountPerMonth * month;
        return total + total * 0.05;
    }
}

public class MicroFinance : FinanceOperations
{
    public bool CheckUserHistory() => true;

    public double CalculateLoanPercent(int month, double amountPerMonth)
    {
        double total = amountPerMonth * month;
        double interest = total * 0.10;
        double serviceFee = month * 4;
        return total + interest + serviceFee;
    }
}

#endregion

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Task 1: FileWorker ===");
        Console.Write("შეიყვანეთ ფაილის მაქსიმალური ზომა (bytes): ");
        long maxSize = long.Parse(Console.ReadLine()!);

        TextFileWorker worker = new TextFileWorker(maxSize);
        worker.Read();
        worker.Write();
        worker.Edit();
        worker.Delete();

        Console.WriteLine("\n=== Task 2: FinanceOperations ===");
        Console.Write("სესხის ვადა (თვეებში): ");
        int months = int.Parse(Console.ReadLine()!);

        Console.Write("ყოველთვიური გადასახადი ($): ");
        double amountPerMonth = double.Parse(Console.ReadLine()!);

        Console.WriteLine("\n--- ბანკი ---");
        Bank bank = new Bank();
        bool bankApproved = bank.CheckUserHistory();
        Console.WriteLine($"ბანკის გადაწყვეტილება: {(bankApproved ? "დამტკიცდა" : "უარყოფილია")}");
        if (bankApproved)
        {
            double bankTotal = bank.CalculateLoanPercent(months, amountPerMonth);
            Console.WriteLine($"სრული გადასახდელი თანხა (5% პროცენტით): {bankTotal:F2}$");
        }

        Console.WriteLine("\n--- მიკროფინანსური ორგანიზაცია ---");
        MicroFinance mf = new MicroFinance();
        bool mfApproved = mf.CheckUserHistory();
        Console.WriteLine($"მიკროფინანსური გადაწყვეტილება: {(mfApproved ? "დამტკიცდა" : "უარყოფილია")}");
        double mfTotal = mf.CalculateLoanPercent(months, amountPerMonth);
        Console.WriteLine($"სრული გადასახდელი თანხა (10% + {months * 4}$ სერვისი): {mfTotal:F2}$");
    }
}
