using Calculator;

(double memory, double lastOperation) = (0, 0);

while (true)
{
    var isValidOperation = true;
    Console.Write("Enter the operation (+, -, *, /, %, rec, square, sqrt, M+, M-, MR, exit): ");
    
    var operation = Console.ReadLine()?.ToUpperInvariant();
    if (operation == "EXIT")
    {
        Console.WriteLine("Thank you. Goodbye!");
        break;
    }
    
    switch (operation)
    {
        case "+":
        {
            var (a, b) = InputUtils.RequestNumbers();
            lastOperation = a + b;
            break;
        }
        case "-":
        {
            var (a, b) = InputUtils.RequestNumbers();
            lastOperation = a - b;
            break;
        }
        case "*":
        {
            var (a, b) = InputUtils.RequestNumbers();
            lastOperation = a * b;
            break;
        }
        case "/":
        {
            var (a, b) = InputUtils.RequestNumbers();
            if (b == 0)
            {
                isValidOperation = false;
                Formatter.FormatError("Division by zero!");
                break;
            }
            lastOperation = a / b;
            break;
        }
        case "%":
        {
            var (a, b) = InputUtils.RequestNumbers();
            if (b == 0)
            {
                isValidOperation = false;
                Formatter.FormatError("Modulo by zero!");
                break;
            }
            lastOperation = a % b;
            break;
        }
        case "REC":
        {
            var x = InputUtils.ReadDouble("Enter the number: ");
            if (x == 0)
            {
                isValidOperation = false;
                Formatter.FormatError("Reciprocal of zero!");
                break;
            }

            lastOperation = 1 / x;
            break;
        }
        case "SQUARE":
        {
            var x = InputUtils.ReadDouble("Enter the number: ");
            lastOperation = x * x;
            break;
        }
        case "SQRT":
        {
            var x = InputUtils.ReadDouble("Enter the number: ");
            if (x < 0)
            {
                isValidOperation = false;
                Formatter.FormatError("Cannot take sqrt of negative numbers!");
                break;
            }
            lastOperation = Math.Sqrt(x);
            break;
        }
        case "M+":
        {
            isValidOperation = false;
            memory += lastOperation;
            Formatter.FormatResult(memory, "New memory value");
            break;
        }
        case "M-":
        {
            isValidOperation = false;
            memory -= lastOperation;
            Formatter.FormatResult(memory, "New memory value");
            break;
        }
        case "MR":
        {
            isValidOperation = false;
            Formatter.FormatResult(memory, "Current memory value");
            break;
        }
        default:
        {
            isValidOperation = false;
            Formatter.FormatError("Invalid operation!");
            break;
        }
    }

    if (isValidOperation)
    {
        Formatter.FormatResult(lastOperation);
    }
}
