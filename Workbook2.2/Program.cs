using Workbook2._2;

var matrixA = Matrix.CreateMatrix();
var matrixB = Matrix.CreateMatrix();

Matrix SelectMatrix()
{
    while (true)
    {
        Console.Write("Выберите матрицу для операции (A или B): ");
        var selectedMatrix = Console.ReadLine()?.Trim().ToLower();
        switch (selectedMatrix)
        {
            case "a": return matrixA;
            case "b": return matrixB;
            default:
            {
                Console.WriteLine("Введена неизвестная матрица.");
                continue;
            }
        }
    }
}

while (true)
{
    Console.WriteLine(
        "1) Заполнение матрицы вручную\n"
        + "2) Заполнение матрицы случайными числами\n"
        + "3) A + B\n"
        + "4) A * B\n"
        + "5) Поиск детерминанта\n"
        + "6) Обратная матрица\n"
        + "7) Транспонирование матриц\n"
        + "8) Нахождение корней системы уравнений через матрицу\n"
        + "9) Вывести матрицу\n"
        + "0) Выход\n"
        + "Ваш выбор?:"
    );

    var inputKey = Console.ReadLine()?.Trim();
    switch (inputKey)
    {
        case "0": Environment.Exit(0); break;
        case "1":
        {
            var matrix = SelectMatrix();
            matrix.FillFromConsole();
            break;
        }
        case "2":
        {
            var matrix = SelectMatrix();
            matrix.FillInRandom();
            break;
        }
        case "3":
        {
            var resultMatrix = matrixA + matrixB;
            if (resultMatrix == null)
            {
                break;
            }

            Console.WriteLine("Матрица сложения: ");
            resultMatrix.PrintMatrix();
            break;
        }
        case "4":
        {
            var resultMatrix = matrixA * matrixB;
            if (resultMatrix == null)
            {
                break;
            }

            Console.WriteLine("Матрица умножения: ");
            resultMatrix.PrintMatrix();
            break;
        }
        case "5":
        {
            var matrix = SelectMatrix();
            var determinant = matrix.GetDeterminant();
            if (determinant == null)
            {
                break;
            }

            Console.WriteLine($"Детерминант матрицы: {determinant}");
            break;
        }
        case "6":
        {
            var matrix = SelectMatrix();
            var inverseMatrix = matrix.GetInverse();
            if (inverseMatrix == null)
            {
                break;
            }

            inverseMatrix.PrintMatrix();
            break;
        }
        case "7":
        {
            var matrix = SelectMatrix();
            var transposedMatrix = matrix.GetTransposed();
            transposedMatrix.PrintMatrix();
            break;
        }
        case "8":
        {
            var resultMatrix = Matrix.SolveLinearSystem(matrixA, matrixB);
            if (resultMatrix == null)
            {
                break;
            }
            resultMatrix.PrintMatrix();
            break;
        }
        case "9":
        {
            var matrix = SelectMatrix();
            matrix.PrintMatrix();
            break;
        }
        default:
        {
            Console.WriteLine("Введена неизвестная операция.");
            break;
        }
    }
}
