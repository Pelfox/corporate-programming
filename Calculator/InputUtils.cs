using System.Globalization;

namespace Calculator;

public class InputUtils
{
    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) || double.TryParse(s, out v))
            {
                return v;
            }

            Formatter.FormatError("Invalid number. Please try again.");
        }
    }
    
    public static (double, double) RequestNumbers()
    {
        var a = InputUtils.ReadDouble("Enter the first number: ");
        var b = InputUtils.ReadDouble("Enter the second number: ");
        return (a, b);
    }
}