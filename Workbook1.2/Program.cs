// Задание 1
const int daysInMay = 31;

Dictionary<int, int> CreateCalendar(int startDay)
{
    if (startDay is < 1 or > 7)
    {
        throw new ArgumentException("Week day should be in range from 1 to 7.");
    }
    var calendar = new Dictionary<int, int>();
    for (var day = 1; day <= daysInMay; day++)
    {
        calendar[day] = (startDay + day - 2) % 7 + 1;
    }
    return calendar;
}

bool IsHoliday(int day, Dictionary<int, int> calendar)
{
    // официальные праздничные дни в мае
    if (day is >= 1 and <= 5 or >= 8 and <= 10)
    {
        return true;
    }
    return calendar[day] is 6 or 7;
}

Console.Write("Enter the start date of the month (1 - monday, ..., 7 - sunday): ");
var startDate = Convert.ToInt32(Console.ReadLine());
var calendar = CreateCalendar(startDate);

Console.Write("Enter the day to check whether it is a holiday: ");
var day = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(IsHoliday(day, calendar) ? "It is a holiday!" : "It is not a holiday!");

// Задание 2
Console.Write("Enter the withdrawal sum: ");
var withdrawalSum = Convert.ToInt32(Console.ReadLine());

if (withdrawalSum > 150_000)
{
    Console.WriteLine("Maximum withdrawal sum is 150000");
}
else if (withdrawalSum % 100 != 0)
{
    Console.WriteLine("Invalid withdrawal sum. It must be divisible by 100");
}
else
{
    int[] denominations = [5000, 2000, 1000, 500, 200, 100];
    foreach (var nominal in denominations)
    {
        if (withdrawalSum / nominal == 0)
        {
            continue;
        }
        Console.WriteLine($" - {nominal} x {withdrawalSum / nominal}");
        withdrawalSum %= nominal;
    }
}
