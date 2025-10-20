using System.Globalization;

namespace Workbook2._2;

public class Matrix
{
    private readonly int _cols, _rows;
    private double[,] _matrix;

    private Matrix(int rows, int cols)
    {
        _cols = cols;
        _rows = rows;
        _matrix = new double[rows, cols];
    }

    public static Matrix CreateMatrix()
    {
        var cols = ConsoleUtils.ReadIntRange("Введите количество столбцов матрицы: ", 1, 100);
        var rows = ConsoleUtils.ReadIntRange("Введите количество строк матрицы: ", 1, 100);
        return new Matrix(rows, cols);
    }

    public void FillFromConsole()
    {
        for (var i = 0; i < _rows; i++)
        {
            while (true)
            {
                Console.WriteLine($"Введите строку {i + 1} матрицы:");
                var line = Console.ReadLine()?.Trim().Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
                if (line == null || line.Length != _cols)
                {
                    Console.WriteLine($"Необходимо ввести ровно {_cols} элементов в строке.");
                    continue;
                }

                if (line.All(p => double.TryParse(p, out _)))
                {
                    for (var j = 0; j < _cols; j++)
                        _matrix[i, j] = double.Parse(line[j]);
                    break;
                }
                Console.WriteLine("Одно или несколько введённых чисел невалидны.");
            }
        }
    }

    public void FillInRandom()
    {
        var min = ConsoleUtils.ReadIntRange("Введите нижний предел диапазона: ", 0, 100);
        var max = ConsoleUtils.ReadIntRange("Введите верхний предел диапазона: ", 0, 100);

        if (min > max)
            (min, max) = (max, min);

        var random = new Random();
        for (var i = 0; i < _rows; i++)
        {
            for (var j = 0; j < _cols; j++)
            {
                _matrix[i, j] = min + random.NextDouble() * (max - min);
            }
        }
    }

    public void PrintMatrix()
    {
        // определяем ширину каждого столбца
        var widths = new int[_cols];
        for (var col = 0; col < _cols; col++)
        {
            widths[col] = Enumerable.Range(0, _rows)
                .Select(i => _matrix[i, col].ToString("0.0", CultureInfo.InvariantCulture).Length)
                .Max();
        }

        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                var s = _matrix[row, col]
                    .ToString("0.0", CultureInfo.InvariantCulture)
                    .PadLeft(widths[col]);
                Console.Write(s);
                if (col < _cols - 1)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    public static Matrix? operator +(Matrix a, Matrix b)
    {
        if (a._cols != b._cols || a._rows != b._rows)
        {
            Console.WriteLine("Невозможно сложить две матрицы.");
            return null;
        }

        var resultMatrix = new Matrix(a._rows, a._cols);
        for (var col = 0; col < a._cols; col++)
        {
            for (var row = 0; row < a._rows; row++)
            {
                resultMatrix._matrix[row, col] = a._matrix[row, col] + b._matrix[row, col];
            }
        }

        return resultMatrix;
    }

    public static Matrix? operator *(Matrix a, Matrix b)
    {
        if (a._cols != b._rows)
        {
            Console.WriteLine("Эти две матрицы перемножить нельзя.");
            return null;
        }

        var resultMatrix = new Matrix(a._rows, b._cols);
        for (var row = 0; row < a._rows; row++)
        {
            for (var col = 0; col < b._cols; col++)
            {
                double sum = 0;
                for (var k = 0; k < a._cols; k++)
                {
                    sum += a._matrix[row, k] * b._matrix[k, col];
                }
                resultMatrix._matrix[row, col] = sum;
            }
        }

        return resultMatrix;
    }

    public double? GetDeterminant()
    {
        if (_rows != _cols)
        {
            Console.WriteLine("Детерминант можно определить только для квадратной матрицы.");
            return null;
        }
        return Determinant(_matrix);
    }

    private double Determinant(double[,] matrix)
    {
        var n = matrix.GetLength(0);
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return matrix[0, 0];
        }

        if (n == 2)
        {
            return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        }

        double determinant = 0;
        for (var col = 0; col < n; col++)
        {
            var minor = GetMinor(matrix, 0, col);
            var sign = col % 2 == 0 ? 1 : -1;
            determinant += sign * matrix[0, col] * Determinant(minor);
        }

        return determinant;
    }

    private double[,] GetMinor(double[,] matrix, int rowToRemove, int columnToRemove)
    {
        var n = matrix.GetLength(0);
        var resultMatrix = new double[n - 1, n - 1];

        var newRow = 0;
        for (var row = 0; row < n; row++)
        {
            if (row == rowToRemove)
            {
                continue;
            }

            var newCol = 0;
            for (var col = 0; col < n; col++)
            {
                if (col == columnToRemove)
                {
                    continue;
                }
                resultMatrix[newRow, newCol] = matrix[row, col];
                newCol++;
            }

            newRow++;
        }

        return resultMatrix;
    }

    public Matrix? GetInverse()
    {
        var determinant = GetDeterminant();
        if (determinant == null)
        {
            return null;
        }

        // проверка на равность детерминанта нулю
        if (Math.Abs(determinant.Value) < 1e-9)
        {
            Console.WriteLine("Определитель равен нулю — обратной матрицы не существует.");
            return null;
        }

        var cofactors = new double[_rows, _cols];

        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                var minor = GetMinor(_matrix, row, col);
                var sign = (row + col) % 2 == 0 ? 1 : -1;
                cofactors[row, col] = sign * Determinant(minor);
            }
        }

        var adjugate = new double[_rows, _cols];
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                adjugate[row, col] = cofactors[col, row];
            }
        }

        var resultMatrix = new Matrix(_rows, _cols);
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                resultMatrix._matrix[row, col] = adjugate[row, col] / determinant.Value;
            }
        }

        return resultMatrix;
    }

    public Matrix GetTransposed()
    {
        var resultMatrix = new Matrix(_cols, _rows);

        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _cols; col++)
            {
                resultMatrix._matrix[col, row] = _matrix[row, col];
            }
        }

        return resultMatrix;
    }

    public static Matrix? SolveLinearSystem(Matrix a, Matrix b)
    {
        if (b._cols != 1 || b._rows != a._rows)
        {
            Console.WriteLine("Матрица B должна быть вектором-столбцом такой же высоты, как A.");
            return null;
        }

        var inverse = a.GetInverse();
        if (inverse == null)
        {
            Console.WriteLine("Невозможно найти корни: матрица A вырождена или не квадратная.");
            return null;
        }
        return inverse * b;
    }
}