namespace Calculator;

public class Formatter
{
    public static void FormatResult(double result, string prefix = "Result")
    {
        Console.WriteLine($"{prefix}: {result:0.###}");
    }

    public static void FormatError(string message)
    {
        Console.WriteLine($"ERROR: {message}");
    }
}