namespace Workbook2._2;

public class ConsoleUtils
{
    public static int ReadIntRange(string message, int min, int max)
    {
        while (true)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine()?.Trim(), out var number) || number < min || number > max)
            {
                Console.WriteLine($"Введите валидное число в пределе от {min} до {max}.");
                continue;
            }

            return number;
        }
    }
}