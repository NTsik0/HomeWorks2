#region Task1
// r = 5, S2 gverdi = 2r , S(s2) = (2R)^2 = 4R^2
// r = 5, S1 gverdi = 2r/ sqrt(2) , S(s1) = gverdi^2 = 2R^2
// sxvaoba = 4R^2 - 2R^2 = 2R^2

Console.WriteLine("Enter The Radius");
int r = int.Parse(Console.ReadLine());
int Sdidi = 4 * r * r;
int Spatara = 2 * r * r;
int difference  = Sdidi - Spatara;
Console.WriteLine($"S of the big square is {Sdidi} , S of the small square is {Spatara}, The difference is {difference}");
#endregion
#region Task2

Console.WriteLine("Wanna Become Rich?");
var yesOrNo = Console.ReadLine();
if (yesOrNo == "yes")
{
    Console.WriteLine("Enter The Number Of Slots");
    var numOfSlots = int.Parse(Console.ReadLine());
    String[] n = new String[numOfSlots];
    for (int i = 0; i < n.Length; i++)
    {
        Console.WriteLine($"Slot {i + 1} is:");
        n[i] = Console.ReadLine();
    }

    bool mdidari = true;

    for (int i = 0; i < n.Length; i++)
    {
        if (n[i] != n[0])
        {
            mdidari = false;
            break;
        }
    }

    if (mdidari)
    {
        Console.WriteLine("MDIDARI");
    }
    else Console.WriteLine("GARIBI");

}
else Console.WriteLine("Goodbye");

#endregion
#region Task3

int mogeba = 3;
int fre = 1;
int wageba = 0;
Console.WriteLine("Enter The number of games:");
int numOfGames = int.Parse(Console.ReadLine());
string[] result = new String[numOfGames];

// jer ubralod arrayshi shevinaxavt win draw or loss s mere davitvlit sxva loopit

for (int i = 0; i < result.Length; i++)
{
    Console.Write($"Game {i + 1} (win/draw/loss): ");
    result[i] = Console.ReadLine().ToLower();
}

int totalPoints = 0;

for (int i = 0; i < result.Length; i++)
{
    if (result[i] == "win")
        totalPoints += 3;
    else if (result[i] == "draw")
        totalPoints += 1;
    else if (result[i] == "loss")
        totalPoints += 0;
    else
    {
        Console.BackgroundColor = ConsoleColor.Red; 
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Learn How To Write -_- ");
        Console.ResetColor();
    }
}

Console.WriteLine($"Total Points: {totalPoints}");
    Console.ResetColor();

#endregion
#region Task4
int[] saatebi = new int[7];
for (int i = 0; i < saatebi.Length; i++)
{
    Console.Write($"Day {i + 1} hours: ");
    saatebi[i] = int.Parse(Console.ReadLine());
}

int totalSalary = 0;

for (int i = 0; i < saatebi.Length; i++)
{
    int workhrs = saatebi[i];
    int dailyPay = 0;

    bool isWeekend = (i == 5 || i == 6); // shabati = index 5ze, kvira = index 6ze

    if (workhrs <= 8)
    {
        dailyPay = workhrs * 10;
    }
    else
    {
        dailyPay = (8 * 10) + ((workhrs - 8) * 15); // overtimis dros 10 + 5 extra
    }

    if (isWeekend)
        dailyPay *= 2;

    totalSalary += dailyPay;
}

Console.WriteLine($"Total Salary: ${totalSalary}");


#endregion
#region Task5

Console.WriteLine("Ramden Dgian Streakze Xar?");
var streak = int.Parse(Console.ReadLine());
int[] resultt = new int[streak];
for (int i = 0; i < resultt.Length; i++)
{
    Console.Write($"Day {i+1}: ");
    resultt[i] = int.Parse(Console.ReadLine());
}

int moxodvisdoneprogress = 0;

for (int i = 1; i < resultt.Length; i++) // start from 1, compare to previous
{
    if (resultt[i] > resultt[i - 1])
        moxodvisdoneprogress++;
}

Console.WriteLine($"Days improved: {moxodvisdoneprogress}");






#endregion
#region Task6

Console.WriteLine("Sheiyvane Arrays Sigrdze");
var size = int.Parse(Console.ReadLine());
string[] arrayi = new string[size];
for (int i = 0; i < arrayi.Length; i++)
{
    Console.WriteLine($"{i+1}'st element of the array is: ");
    arrayi[i] =Console.ReadLine();
}
Console.WriteLine("Enter The Length Of Words You wanna see: ");
var lengthOfWords = int.Parse(Console.ReadLine());
var resulttt = arrayi.Where(word => word.Length == lengthOfWords).ToArray();
foreach (var word in resulttt) 
{
    Console.WriteLine(word);
}


#endregion