namespace _03OOP;

public class Assignment3
{
    // Run this separately in a new project in Visual Studio or Rider
    public static void Run()
    {
        /*
         * Let’s make a program that uses methods to accomplish a task. Let’s take an array and
reverse the contents of it. For example, if you have 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, it would
become 10, 9, 8, 7, 6, 5, 4, 3, 2, 1.
To accomplish this, you’ll create three methods: one to create the array, one to reverse the
array, and one to print the array at the end.
Your Mainmethod will look something like this:
static void Main(string[] args) {
int[] numbers = GenerateNumbers();
Reverse(numbers);
PrintNumbers(numbers);
}
    */
        int[] numbers = GenerateNumbers();
        Reverse(numbers);
        PrintNumbers(numbers);

        // Fibonacci
        Console.WriteLine("Fibonacci");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }
    }

    private static int[] GenerateNumbers(int length = 10)
    {
        int[] numbers = new int[length];
        for (var i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        return numbers;
    }

    private static void Reverse(int[] numbers)
    {
        for (var i = 0; i < numbers.Length / 2; i++)
        {
            (numbers[i], numbers[numbers.Length - i - 1]) = (numbers[numbers.Length - i - 1], numbers[i]);
        }
    }

    private static void PrintNumbers(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }

        Console.WriteLine();
    }

    /**
     * The Fibonacci sequence
        */
    private static int Fibonacci(int n)

    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}