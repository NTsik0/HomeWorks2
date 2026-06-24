using System;
using System.Collections.Generic;
#region Task1
public class Company
{
    public bool IsLocal { get; set; }

    public Company(bool isLocal)
    {
        IsLocal = isLocal;
    }

    public double CalculateTax(double totalSalary)
    {
        return IsLocal ? totalSalary * 0.18 : totalSalary * 0.05;
    }
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public int[] WeeklyHours { get; set; }

    public Employee(string firstName, string lastName, int age, string position, int[] weeklyHours)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Position = position;
        WeeklyHours = weeklyHours;
    }

    public double CalculateWeeklySalary()
    {
        double hourlyRate = 10;
        if (Position == "მენეჯერი") hourlyRate = 40;
        else if (Position == "დეველოპერი") hourlyRate = 30;
        else if (Position == "ტესტერი") hourlyRate = 20;

        double totalSalary = 0;
        int totalHours = 0;

        for (int i = 0; i < WeeklyHours.Length; i++)
        {
            int hours = WeeklyHours[i];
            totalHours += hours;
            double dailySalary = 0;

            if (hours <= 8)
            {
                dailySalary = hours * hourlyRate;
            }
            else
            {
                dailySalary = (8 * hourlyRate) + ((hours - 8) * (hourlyRate + 5));
            }

            if (i == 5 || i == 6) // შაბათ-კვირა
            {
                dailySalary *= 2;
            }

            totalSalary += dailySalary;
        }

        if (totalHours > 50)
        {
            totalSalary *= 1.2;
        }

        return totalSalary;
    }
}
#endregion  
#region Task2
public class StudentTask2
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int EnrollmentYear { get; set; }

    public StudentTask2(string name, int age, int enrollmentYear)
    {
        Name = name;
        Age = age;
        EnrollmentYear = enrollmentYear;
    }

    public string GetRandomSubject()
    {
        string[] subjects = { "მათემატიკა", "ქიმია", "ინგლისური", "ისტორია" };
        Random rand = new Random();
        return subjects[rand.Next(subjects.Length)];
    }

    public int YearsLeftToGraduate()
    {
        int currentYear = 2026; 
        int yearsLeft = 4 - (currentYear - EnrollmentYear);
        return yearsLeft < 0 ? 0 : yearsLeft;
    }
}

public class Teacher
{
    public string Name { get; set; }
    public bool IsCertified { get; set; }

    public Teacher(string name, bool isCertified)
    {
        Name = name;
        IsCertified = isCertified;
    }

    public void CheckSubject(string subject)
    {
        Random rand = new Random();

        if (subject == "მათემატიკა")
        {
            int num1 = rand.Next(1, 100);
            int num2 = rand.Next(1, 100);
            Console.WriteLine($"მასწავლებელმა შეამოწმა მათემატიკა: {num1} + {num2} = {num1 + num2}");
        }
        else if (subject == "ქიმია")
        {
            Console.WriteLine("მასწავლებელმა შეამოწმა ქიმია: H2O");
        }
        else if (subject == "ინგლისური")
        {
            Console.WriteLine("მასწავლებელმა შეამოწმა ინგლისური: Oh Captain! My Captain");
        }
        else
        {
            Console.WriteLine($"მასწავლებელი არ არის კომპეტენტური საგანში: {subject}");
        }
    }
}
#endregion
#region Task3
public class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }

    public virtual void Study() => Console.WriteLine($"{Name} სწავლობს");
    public virtual void Read() => Console.WriteLine($"{Name} კითხულობს");
    public virtual void Write() => Console.WriteLine($"{Name} წერს");
    public virtual void Relax() => Console.WriteLine($"{Name} ისვენებს");
}

public class GoodStudent : Student
{
    public GoodStudent(string name) : base(name) { }

    public override void Study() => Console.WriteLine($"{Name} ბევრს სწავლობს");
    public override void Read() => Console.WriteLine($"{Name} ლიტერატურას კითხულობს");
    public override void Write() => Console.WriteLine($"{Name} ლამაზად წერს");
    public override void Relax() => Console.WriteLine($"{Name} ცოტას ისვენებს");
}

public class LazyStudent : Student
{
    public LazyStudent(string name) : base(name) { }

    public override void Study() => Console.WriteLine($"{Name} არ სწავლობს");
    public override void Read() => Console.WriteLine($"{Name} არ კითხულობს");
    public override void Write() => Console.WriteLine($"{Name} არაფერს წერს");
    public override void Relax() => Console.WriteLine($"{Name} სულ ისვენებს");
}

public class ClassRoom
{
    private List<Student> students = new List<Student>();

    public ClassRoom(params Student[] inputStudents)
    {
        students.AddRange(inputStudents);
    }

    public void PrintAllActivities()
    {
        foreach (var student in students)
        {
            student.Study();
            student.Read();
            student.Write();
            student.Relax();
            Console.WriteLine();
        }
    }
}
#endregion

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("1: კომპანია და თანამშრომელი");

        Console.Write("ადგილობრივია კომპანია? (yes/no): ");
        bool isLocal = Console.ReadLine().ToLower() == "yes";
        Company myCompany = new Company(isLocal);

        Console.Write("თანამშრომლის სახელი: ");
        string fName = Console.ReadLine();

        Console.Write("თანამშრომლის გვარი: ");
        string lName = Console.ReadLine();

        Console.Write("ასაკი: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("ჩაწერეთ პოზიცია (მენეჯერი, დეველოპერი, ტესტერი, სხვა): ");
        string pos = Console.ReadLine();

        int[] hours = new int[7];
        string[] days = { "ორშაბათი", "სამშაბათი", "ოთხშაბათი", "ხუთშაბათი", "პარასკევი", "შაბათი", "კვირა" };

        Console.WriteLine("შემოიტანეთ ნამუშევარი საათები დღეების მიხედვით:");
        for (int i = 0; i < 7; i++)
        {
            Console.Write($"{days[i]}: ");
            hours[i] = int.Parse(Console.ReadLine());
        }

        Employee emp = new Employee(fName, lName, age, pos, hours);
        double salary = emp.CalculateWeeklySalary();
        double tax = myCompany.CalculateTax(salary);

        Console.WriteLine("------ შედეგი ------");
        Console.WriteLine($"თანამშრომლის ხელფასი: {salary}$");
        Console.WriteLine($"სახელმწიფო გადასახადი: {tax}$");
        Console.WriteLine("--------------------------------------------------\n");


        Console.WriteLine(" 2: მასწავლებელი და სტუდენტი ");

        Console.Write("სტუდენტის სახელი: ");
        string sName = Console.ReadLine();

        Console.Write("სტუდენტის ასაკი: ");
        int sAge = int.Parse(Console.ReadLine());

        Console.Write("უნივერსიტეტში ჩარიცხვის წელი: ");
        int enrollYear = int.Parse(Console.ReadLine());

        StudentTask2 student2 = new StudentTask2(sName, sAge, enrollYear);

        Console.Write("მასწავლებლის სახელი: ");
        string tName = Console.ReadLine();

        Console.Write("სერტიფიცირებულია? (yes/no): ");
        bool isCert = Console.ReadLine().ToLower() == "yes";

        Teacher teacher = new Teacher(tName, isCert);

        Console.WriteLine("------ შედეგი ------");
        Console.WriteLine($"დარჩენილი წლები უნივერსიტეტში: {student2.YearsLeftToGraduate()}");
        string randomSubject = student2.GetRandomSubject();
        Console.WriteLine($"სტუდენტმა შემთხვევითობის პრინციპით აირჩია: {randomSubject}");
        teacher.CheckSubject(randomSubject);
        Console.WriteLine("--------------------------------------------------\n");


        Console.WriteLine("3: საკლასო ოთახი");

        Console.Write("შეიყვანეთ ბეჯითი სტუდენტის სახელი: ");
        string goodName = Console.ReadLine();
        GoodStudent good = new GoodStudent(goodName);

        Console.Write("შეიყვანეთ ზარმაცი სტუდენტის სახელი: ");
        string lazyName = Console.ReadLine();
        LazyStudent lazy = new LazyStudent(lazyName);

        ClassRoom room = new ClassRoom(good, lazy);

        Console.WriteLine("------ სტუდენტების აქტივობები ------");
        room.PrintAllActivities();
        Console.WriteLine("--------------------------------------------");
    }
}