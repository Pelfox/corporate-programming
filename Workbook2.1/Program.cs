// Задание №1
Console.Write("Введите число n: ");
if (!int.TryParse(Console.ReadLine(), out var number))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

for (var i = 1; i < 11; i++)
{
    Console.WriteLine($"{number} * {i} = {number * i}");
}

// Задание №2
double F(int x)
{
    return Math.Pow(5 * x, 2) - x + 2;
}

double Trapezoidal(int a, int b, int n)
{
    var h = (b - a) / n;
    var s = (F(a) + F(b)) / 2;
    for (var i = 1; i < n; i++)
    {
        s += F(a + i * h);
    }
    return s;
}

Console.Write("Введите нижний предел интеграла a: ");
if (!int.TryParse(Console.ReadLine(), out var aIn))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

Console.Write("Введите верхний предел интеграла b: ");
if (!int.TryParse(Console.ReadLine(), out var bIn))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

Console.Write("Введите количество разбиений n: ");
if (!int.TryParse(Console.ReadLine(), out var nIn))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

Console.WriteLine($"Приближённое значение интеграла: {Trapezoidal(aIn, bIn, nIn)}.");

// Задание №3
double Term(int k)
{
    return (3 * k - 1) / (7 * Math.Pow(k, 2) + 9);
}

Console.Write("Введите число N ряда: ");
if (!int.TryParse(Console.ReadLine(), out var n))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

var sum = 0.0D;
for (var k = 1; k <= n; k++)
{
    sum += Term(k);
}

Console.WriteLine($"Сумма {n} элементов ряда: {sum}.");

// Задание №4
Console.Write("Введите число: ");
if (!int.TryParse(Console.ReadLine(), out var x))
{
    Console.WriteLine("Введите корректное число.");
    return;
}

Console.WriteLine($"Число {x} в 2-й СС: {Convert.ToString(x, 2)}.");

// Задание №5
Console.WriteLine("Введите ряд чисел. Чтобы закончить ввод, напишите `exit`:");

var numbers = new List<int>();
var currentInput = Console.ReadLine();
while (currentInput?.ToLower() != "exit")
{
    if (!int.TryParse(currentInput, out var i))
    {
        Console.WriteLine("Введите корректное число.");
        continue;
    }
    numbers.Add(i);
    currentInput = Console.ReadLine();
}

Console.WriteLine($"Максимум в введённом ряде чисел: {numbers.Max()}");
