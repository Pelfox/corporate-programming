using System.Globalization;

namespace Workbook3;

public abstract class ConsoleUtils
{
    public static int? ReadInt(string prompt, int? min = null, int? max = null)
    {
        Console.Write(prompt);

        var input = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Требуется ввести целое число.");
            return null;
        }

        if (!int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
        {
            Console.WriteLine("Требуется ввести валидное число.");
            return null;
        }

        if (result < min)
        {
            Console.WriteLine($"Требуется ввести число большее {min}.");
            return null;
        }

        if (result > max)
        {
            Console.WriteLine($"Требуется ввести число не больше {max}.");
            return null;
        }

        return result;
    }
}