// Задание №1
using System.Globalization;

static double Factorial(int n)
{
    double result = 1;
    for (var i = 2; i <= n; i++)
    {
        result *= i;
    }
    return result;
}

static double SinhBySeries(double x, double eps)
{
    var term = x; // первый член ряда
    var sum = term;
    var n = 1;

    while (Math.Abs(term) > eps)
    {
        term = Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1);
        sum += term;
        n++;
    }

    return sum;
}

static double NthTerm(double x, int n)
{
    return Math.Pow(x, 2 * n + 1) / Factorial(2 * n + 1);
}

Console.WriteLine("Выберите режим:");
Console.WriteLine("1 - Вычисление sinh(x) с точностью ε;");
Console.WriteLine("2 - Вычисление n-го члена ряда;");

var modeInput = Console.ReadLine();
if (!int.TryParse(modeInput, out var mode) || (mode != 1 && mode != 2))
{
    Console.WriteLine("Ошибка: выберите 1 или 2.");
    return;
}

switch (mode)
{
    case 1:
    {
        Console.Write("Введите x: ");
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var x))
        {
            Console.WriteLine("Ошибка ввода x.");
            return;
        }

        Console.Write("Введите e (<0.01): ");
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var e) || e <= 0 || e >= 0.01)
        {
            Console.WriteLine("Ошибка: e должно быть >0 и <0.01.");
            return;
        }

        Console.WriteLine($"sinh({x}) = {SinhBySeries(x, e)}.");
        Console.WriteLine($"Проверка через Math.Sinh: {Math.Sinh(x)}.");
        break;
    }
    case 2:
    {
        Console.Write("Введите x: ");
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var x))
        {
            Console.WriteLine("Ошибка ввода x.");
            return;
        }

        Console.Write("Введите n (номер члена ряда, начиная с 0): ");
        if (!int.TryParse(Console.ReadLine(), out var n) || n < 0)
        {
            Console.WriteLine("Ошибка: n должно быть целым неотрицательным.");
            return;
        }

        Console.WriteLine($"{n}-й член ряда: {NthTerm(x, n)}.");
        break;
    }
}

// Задание №2
Console.Write("Введите номер билета (6 цифр): ");
if (!int.TryParse(Console.ReadLine(), out var ticket) || ticket < 0 || ticket > 999999)
{
    Console.WriteLine("Ошибка: нужно ввести шестизначное число.");
    return;
}

var d1 = ticket / 100000 % 10;
var d2 = ticket / 10000 % 10;
var d3 = ticket / 1000 % 10;
var d4 = ticket / 100 % 10;
var d5 = ticket / 10 % 10;
var d6 = ticket % 10;

Console.WriteLine(d1 + d2 + d3 == d4 + d5 + d6 ? "True" : "False");

// Задание №3
int Gcd(int a, int b)
{
    a = Math.Abs(a);
    b = Math.Abs(b);
    while (b != 0)
    {
        var temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

Console.Write("Введите числитель: ");
if (!int.TryParse(Console.ReadLine(), out var m))
{
    Console.WriteLine("Ошибка: неверный ввод числителя.");
    return;
}

Console.Write("Введите знаменатель: ");
if (!int.TryParse(Console.ReadLine(), out var n2) || n2 == 0)
{
    Console.WriteLine("Ошибка: неверный ввод знаменателя.");
    return;
}

var gcd = Gcd(m, n2);
m /= gcd;
n2 /= gcd;

if (n2 < 0)
{
    m = -m;
    n2 = -n2;
}

Console.WriteLine($"Результат: {m} / {n2}.");

// Задание №4
Console.WriteLine("Загадайте число от 0 до 63. Я попробую его угадать.");
Console.WriteLine("Отвечайте 1 - если ДА, 0 - если НЕТ.");

var low = 0;
var high = 63;
var questions = 0;

while (low < high && questions < 7)
{
    var mid = (low + high) / 2;
    Console.Write($"Ваше число больше {mid}? (1 - да / 0 - нет): ");

    var input = Console.ReadLine();
    if (input != "0" && input != "1")
    {
        Console.WriteLine("Ошибка ввода. Введите 1 или 0.");
        continue;
    }

    questions++;
    if (input == "1")
        low = mid + 1;
    else
        high = mid;
}

Console.WriteLine($"Ваше число: {low}.");
Console.WriteLine($"Я угадал за {questions} вопросов.");

// Задание №5
const int waterForAmericano = 300;
const int priceAmericano = 150;

const int waterForLatte = 30;
const int milkForLatte = 270;
const int priceLatte = 170;

// Ввод исходных запасов
Console.Write("Введите количество воды в мл: ");
if (!int.TryParse(Console.ReadLine(), out var water) || water < 0)
{
    Console.WriteLine("Ошибка: нужно ввести неотрицательное число.");
    return;
}

Console.Write("Введите количество молока в мл: ");
if (!int.TryParse(Console.ReadLine(), out var milk) || milk < 0)
{
    Console.WriteLine("Ошибка: нужно ввести неотрицательное число.");
    return;
}

// Статистика
var americanoCount = 0;
var latteCount = 0;
var totalMoney = 0;

while (true)
{
    // Проверяем, может ли аппарат сделать хоть один напиток
    var canAmericano = water >= waterForAmericano;
    var canLatte = water >= waterForLatte && milk >= milkForLatte;

    if (!canAmericano && !canLatte)
    {
        Console.WriteLine("Отчёт:");
        Console.WriteLine("Ингредиенты закончились.");
        Console.WriteLine($"Вода: {water} мл.");
        Console.WriteLine($"Молоко: {milk} мл.");
        Console.WriteLine($"Кружек американо приготовлено: {americanoCount}.");
        Console.WriteLine($"Кружек латте приготовлено: {latteCount}.");
        Console.WriteLine($"Итого: {totalMoney} рублей.");
        break;
    }

    Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
        {
            if (water >= waterForAmericano)
            {
                water -= waterForAmericano;
                americanoCount++;
                totalMoney += priceAmericano;
                Console.WriteLine("Ваш напиток готов.");
            }
            else
            {
                Console.WriteLine("Не хватает воды.");
            }
            break;
        }
        case "2":
        {
            if (water >= waterForLatte && milk >= milkForLatte)
            {
                water -= waterForLatte;
                milk -= milkForLatte;
                latteCount++;
                totalMoney += priceLatte;
                Console.WriteLine("Ваш напиток готов.");
            }
            else if (water < waterForLatte)
            {
                Console.WriteLine("Не хватает воды.");
            }
            else
            {
                Console.WriteLine("Не хватает молока.");
            }
            break;
        }
        default:
        {
            Console.WriteLine("Ошибка: выберите 1 или 2.");
            break;
        }
    }
}

// Задание №6
Console.Write("Введите количество бактерий: ");
if (!int.TryParse(Console.ReadLine(), out var bacteria) || bacteria < 0)
{
    Console.WriteLine("Ошибка: нужно ввести неотрицательное число.");
    return;
}

Console.Write("Введите количество антибиотика (капель): ");
if (!int.TryParse(Console.ReadLine(), out var drops) || drops < 0)
{
    Console.WriteLine("Ошибка: нужно ввести неотрицательное число.");
    return;
}

var hour = 0;
var killPower = 10;

while (bacteria > 0 && killPower > 0 && drops > 0)
{
    hour++;
    bacteria *= 2;

    var killed = killPower * drops;
    bacteria -= killed;

    if (bacteria < 0)
    {
        bacteria = 0;
    }

    Console.WriteLine($"После {hour} часа бактерий осталось: {bacteria}.");
    killPower--;
}

// Задание №7
int ReadInt(string message)
{
    Console.Write(message);
    if (!int.TryParse(Console.ReadLine(), out var value) || value <= 0)
    {
        Console.WriteLine("Ошибка ввода. Нужно ввести положительное целое число.");
        Environment.Exit(1);
    }
    return value;
}

bool CanFit(int n, int a, int b, int w, int h, int d)
{
    var count1 = w / (a + 2 * d) * (h / (b + 2 * d));
    var count2 = w / (b + 2 * d) * (h / (a + 2 * d));
    return Math.Max(count1, count2) >= n;
}

var n3 = ReadInt("Введите n: ");
var a = ReadInt("Введите a: ");
var b = ReadInt("Введите b: ");
var w = ReadInt("Введите w: ");
var h = ReadInt("Введите h: ");

var left = 0;
var right = Math.Max(w, h);
var answer = 0;

while (left <= right)
{
    var mid = (left + right) / 2;
    if (CanFit(n3, a, b, w, h, mid))
    {
        answer = mid;
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

Console.WriteLine($"Ответ d = {answer}.");
