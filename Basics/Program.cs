// Задание 1
Console.WriteLine("Hello, what's your name?");
var name = Console.ReadLine();

Console.WriteLine($"Hello, {name}! What's the current temperature outside?");
var temperature = Convert.ToInt32(Console.ReadLine());

if (temperature >= 20)
{
    Console.WriteLine("It's a good temperature outside! I'd like to go out.");
}
else
{
    Console.WriteLine("I've thought that its warmer today. I'll stay home.");
}

// Задание 2
Console.WriteLine("Введите сегодняшнюю дату (дд мм гггг):");
if (DateTime.TryParse(Console.ReadLine(), out DateTime today))
{
    DateTime tomorrow = today.AddDays(1);
    Console.WriteLine($"Завтрашняя дата: {tomorrow:dd.MM.yyyy}");
}
else
{
    Console.WriteLine("Неверный формат даты! Введите как: 13 09 2025");
}

// Задание 3
Console.WriteLine("Enter the current year:");
var year = Convert.ToInt32(Console.ReadLine());
if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
{
    Console.WriteLine("It's a leap year!");
}
else
{
    Console.WriteLine("It's not a leap year!");
}

// Задание 4
Console.WriteLine("Enter the current week's day number:");
var dayNumber = Convert.ToInt32(Console.ReadLine());
if (dayNumber < 1 || dayNumber > 7)
{
    Console.WriteLine("Invalid day number");
    return;
}
if (dayNumber is >= 1 and <= 5)
{
    Console.WriteLine("Today is a work day!");
}
else
{
    Console.WriteLine("Hooray! A weekend!");
}

// Задание 5
Console.WriteLine("Enter your height:");
var height = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter your weight:");
var weight = Convert.ToInt32(Console.ReadLine());

var goodWeight = height - 100;
if (goodWeight < weight)
{
    Console.WriteLine($"You need to lose some weight! ({weight - goodWeight} kg)");
}
else if (goodWeight > weight)
{
    Console.WriteLine($"You need to gain some weight! ({goodWeight - weight} kg)");
}
else
{
    Console.WriteLine("Good job, your weight is perfect.");
}