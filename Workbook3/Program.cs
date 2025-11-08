using Workbook3;

// Задание №1
bool HasZero(int number)
{
    var abs = Math.Abs(number);
    if (abs == 0)
        return true;
    if (number < 10)
        return false;
    return number % 10 == 0 || HasZero(number / 10);
}

int ReverseNumber(int number, int accumulator = 0)
{
    if (number < 0)
        return -ReverseNumber(-number);
    if (number == 0)
        return accumulator;
    return ReverseNumber(number / 10, accumulator * 10 + number % 10);
}

var inputValue = ConsoleUtils.ReadInt("Введите число для переворачивания: ");
if (inputValue == null)
    return;

if (HasZero(inputValue.Value))
{
    Console.WriteLine("Вводимое число не должно содержать ни единого нуля.");
    return;
}

Console.WriteLine($"Перевёрнутое число {inputValue.Value}: {ReverseNumber(inputValue.Value)}");

// Задание №2
Dictionary<(int, int), int> ackermannCache = new();

int AckermannFunction(int m, int n)
{
    if (ackermannCache.TryGetValue((m, n), out var cachedResult))
        return cachedResult;

    int result;
    if (m == 0)
        result = n + 1;
    else if (m > 0 && n == 0)
        result = AckermannFunction(m - 1, 1);
    else
        result = AckermannFunction(m - 1, AckermannFunction(m, n - 1));
    ackermannCache[(m, n)] = result;
    return result;
}

var inputM = ConsoleUtils.ReadInt("Введите первый аргумент функции (m): ", 0);
if (inputM == null)
    return;

var inputN = ConsoleUtils.ReadInt("Введите второй аргумент функции (n): ", 0);
if (inputN == null)
    return;

if (inputM > 3 || inputN > 10)
{
    Console.WriteLine("Слишком большие аргументы — вычисление невозможно (StackOverflow).");
    return;
}

var functionResult = AckermannFunction(inputM.Value, inputN.Value);
Console.WriteLine($"Результат выполнения функции Аккермана A({inputM}, {inputN}): {functionResult}");
