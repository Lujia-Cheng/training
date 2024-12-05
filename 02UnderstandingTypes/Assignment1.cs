using System.Numerics;
using static System.Console;

namespace _02UnderstandingTypes
{
    internal class Assignment1
    {


        public static void NumberTypes()
        {
            WriteLine(
                $"sbyte: {sizeof(sbyte)} bytes, Min: {sbyte.MinValue}, Max: {sbyte.MaxValue}");
            WriteLine(
                $"byte: {sizeof(byte)} bytes, Min: {byte.MinValue}, Max: {byte.MaxValue}");
            WriteLine(
                $"short: {sizeof(short)} bytes, Min: {short.MinValue}, Max: {short.MaxValue}");
            WriteLine(
                $"ushort: {sizeof(ushort)} bytes, Min: {ushort.MinValue}, Max: {ushort.MaxValue}");
            WriteLine(
                $"int: {sizeof(int)} bytes, Min: {int.MinValue}, Max: {int.MaxValue}");
            WriteLine(
                $"uint: {sizeof(uint)} bytes, Min: {uint.MinValue}, Max: {uint.MaxValue}");
            WriteLine(
                $"long: {sizeof(long)} bytes, Min: {long.MinValue}, Max: {long.MaxValue}");
            WriteLine(
                $"ulong: {sizeof(ulong)} bytes, Min: {ulong.MinValue}, Max: {ulong.MaxValue}");
            WriteLine(
                $"float: {sizeof(float)} bytes, Min: {float.MinValue}, Max: {float.MaxValue}");
            WriteLine(
                $"double: {sizeof(double)} bytes, Min: {double.MinValue}, Max: {double.MaxValue}");
            WriteLine(
                $"decimal: {sizeof(decimal)} bytes, Min: {decimal.MinValue}, Max: {decimal.MaxValue}");
        }

        public static void ConvertCenturies()
        {
            WriteLine("Enter number of centuries: ");
            string input = ReadLine();
            int centuries = int.Parse(input);
            if (string.IsNullOrEmpty(input) || centuries <= 0)
            {
                WriteLine(
                    "Invalid input. Please enter a valid number of centuries.");
                return;
            }

            int years = centuries * 100;
            int days = (int)(years * 365.24);
            int hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            BigInteger milliseconds = seconds * 1000;
            BigInteger microseconds = milliseconds * 1000;
            BigInteger nanoseconds = microseconds * 1000;
            WriteLine(
                $"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }

        /**
         * FizzBuzzis a group word game for children to teach them about division. Players take turns
        to count incrementally, replacing any number divisible by three with the word /fizz/, any
        number divisible by five with the word /buzz/, and any number divisible by both with /
        fizzbuzz/.
         */
        public static void FizzBuzzis()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    WriteLine("Buzz");
                }
                else
                {
                    WriteLine(i);
                }
            }
        }

        public static void InfinityByteLoop()
        {
            int max = 500;

            if (max > byte.MaxValue)
            {
                Error.WriteLine("Max value is too large for a byte");
                return;
            }

            for (byte i = 0; i < max; i++)
            {
                WriteLine(i);
            }
        }

        /**
         * Write a program that generates a random number between 1 and 3 and asks the user to
guess what the number is. Tell the user if they guess low, high, or get the correct answer.
Also, tell the user if their answer is outside of the range of numbers that are valid guesses
(less than 1 or more than 3).
         */
        public static void GuessNumber()
        {
            int correctNumber = new Random().Next(3) + 1;
            int guess = 0;
            WriteLine("Guess the number between 1 and 3: ");
            while (guess != correctNumber)
            {
                guess = int.Parse(ReadLine());

                if (guess < 1 || guess > 3)
                {
                    WriteLine("Invalid guess. Please enter a number between 1 and 3.");
                    continue;
                }

                if (guess == correctNumber)
                {
                    WriteLine("Correct!");
                    return;
                }

                WriteLine((guess < correctNumber) ? "Too low!" : "Too high!");
            }
        }

        /**
         * Print-a-Pyramid.Like the star pattern examples that we saw earlier, create a program that
will print the following pattern: If you find yourself getting stuck, try recreating the two
examples that we just talked about in this chapter first. They’re simpler, and you can
compare your results with the code included above.
         */
        public static void PrintAPyramid(int height = 5)
        {
            int cntStar = -1;
            while (height-- > 0)
            {
                cntStar += 2;
                int cntBlank = height;

                while (cntBlank-- > 0)
                {
                    Write(" ");
                }

                for (int i = 0; i < cntStar; i++)
                {
                    Write("*");
                }

                WriteLine();
            }
        }

        /**
         * Write a simple program that defines a variable representing a birth date and calculates
how many days old the person with that birth date is currently.
         */
        public static void CalculateAge()
        {
            WriteLine("Enter your birth date (yyyy/mm/dd): ");
            string input = ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                WriteLine("Invalid input. Please enter a valid date.");
                return;
            }

            DateTime birthDate = DateTime.Parse(input);

            TimeSpan age = DateTime.Now - birthDate;
            WriteLine($"You are {age.Days} days old.");
            WriteLine($"Your next 10,000 day anniversary is in {10000 - (age.Days % 10000)} days.");
        }

        /**
         * Write a program that greets the user using the appropriate greeting for the time of day.
Use only if , not else or switch , statements to do so. Be sure to include the following
greetings:
"Good Morning"
"Good Afternoon"
"Good Evening"
"Good Night"
         */
        public static void ProperGreeting()
        {
            int hour = DateTime.Now.Hour;
            WriteLine(
                hour switch
                {
                    < 12 => "Good Morning",
                    < 17 => "Good Afternoon",
                    < 21 => "Good Evening",
                    _ => "Good Night"
                }
            );
        }

        /**
        Write a program that prints the result of counting up to 24 using four different increments.
First, count by 1s, then by 2s, by 3s, and finally by 4s.
Use nested for loops with your outer loop counting from 1 to 4. You inner loop should
count from 0 to 24, but increase the value of its /loop control variable/ by the value of the /
loop control variable/ from the outer loop. This means the incrementing in the /
afterthought/ expression will be based on a variable.
Your output should look something like this*/
        public static void CountingIncrements()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 24; j += i)
                {
                    Write($"{j},");
                }

                WriteLine();
            }
        }
    }
}