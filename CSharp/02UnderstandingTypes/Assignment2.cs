using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace _02UnderstandingTypes;

using static System.Console;

public class Assignment2
{
    public static void Main()
    {
        FindPrimsInRange(2, 40);

    }

    /**
     * Copying an Array
Write code to create a copy of an array. First, start by creating an initial array. (You can use
whatever type of data you want.) Let’s start with 10 items. Declare an array variable and
assign it a new array with 10 items in it. Use the things we’ve discussed to put some values
in the array.
Now create a second array variable. Give it a new array with the same length as the first.
Instead of using a number for this length, use the Lengthproperty to get the size of the
original array.
Use a loop to read values from the original array and place them in the new array. Also
print out the contents of both arrays, to be sure everything copied correctly.
     */
    public static void CopyArray()
    {
        int[] originalArray = new int[10];
        for (int i = 0; i < originalArray.Length; i++)
        {
            originalArray[i] = i;
        }

        int[] copyArray = new int[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++)
        {
            copyArray[i] = originalArray[i];
        }

        WriteLine("Original Array:");
        foreach (int item in originalArray)
        {
            Write($"{item} ");
        }

        WriteLine("\nCopy Array:");
        foreach (int item in copyArray)
        {
            Write($"{item} ");
        }
    }

    /**
     * Write a simple program that lets the user manage a list of elements. It can be a grocery list,
"to do" list, etc. Refer to Looping Based on a Logical Expression if necessary to see how to
implement an infinite loop. Each time through the loop, ask the user to perform an
operation, and then show the current contents of their list. The operations available should
be Add, Remove, and Clear. The syntax should be as follows:
+ some item
- some item
--
Your program should read in the user's input and determine if it begins with a “+” or “-“ or
if it is simply “—“ . In the first two cases, your program should add or remove the string
given ("some item" in the example). If the user enters just “—“ then the program should
clear the current list. Your program can start each iteration through its loop with the
following instruction:
Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
     */
    public static void ManageList()
    {
        List<string> list = new List<string>();
        while (true)
        {
            WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                WriteLine("Invalid input. Please enter a valid command.");
                continue;
            }

            if (input.StartsWith("+"))
            {
                list.Add(input.Substring(1).Trim());
            }
            else if (input.StartsWith("-"))
            {
                list.Remove(input.Substring(1).Trim());
            }
            else if (input == "--")
            {
                list.Clear();
            }

            WriteLine("Current List:");
            foreach (string item in list)
            {
                Write($"{item},");
            }

            WriteLine();
        }
    }

    /**
     * Write a method that calculates all prime numbers in given range and returns them as array of integers
     */
    public static int[] FindPrimsInRange(int startNum, int endNum)
    {
        // chopped Sieve of Eratosthenes
        bool[] isPrimes = new bool[endNum + 1];
        for (int i = 2; i <= endNum; i++)
        {
            isPrimes[i] = true;
        }

        for (int i = 2; i * i <= endNum; i++)
        {
            if (isPrimes[i])
            {
                for (int j = i * i; j <= endNum; j += i)
                {
                    isPrimes[j] = false;
                }
            }
        }

        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            if (isPrimes[i])
            {
                primes.Add(i);
                Write($"{i} ");
            }
        }

        return primes.ToArray();
    }

    /**
     * Write a program to read an array of n integers (space separated on a single line) and an
integer k, rotate the array right k times and sum the obtained arrays after each rotation as
shown below.
After r rotations the element at position I goes to position (I + r) % n.
The sum[] array can be calculated by two nested loops: for r = 1 ... k; for I = 0 ... n-1.
     */
    public static void RotateArray()
    {
        WriteLine("Enter an array of integers (space separated):");
        int[] arr = ReadLine().Split(' ').Select(int.Parse).ToArray();
        WriteLine("Enter the number of rotations:");
        int k = int.Parse(ReadLine());
        int n = arr.Length;
        int[] sum = new int[n];
        for (int r = 1; r <= k; r++)
        {
            for (int i = 0; i < n; i++)
            {
                sum[(i + r) % n] += arr[i];
            }
        }

        WriteLine(string.Join(" ", sum));
    }

    /**
     * Write a program that finds the longest sequence of equal elements in an array of integers.
If several longest sequences exist, print the leftmost one.
     */
    public static void LongestSequence()
    {
        WriteLine("Enter an array of integers (space separated):");
        int[] arr = ReadLine().Split(' ').Select(int.Parse).ToArray();
        int maxCount = 0;
        int count = 1;
        int num = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                count++;
            }
            else
            {
                count = 1;
            }

            if (count > maxCount)
            {
                maxCount = count;
                num = arr[i];
            }
        }

        WriteLine(string.Join(" ", Enumerable.Repeat(num, maxCount)));
    }

    /**
     * Write a program that finds the most frequent number in a given sequence of numbers. In
case of multiple numbers with the same maximal frequency, print the leftmost of them
Input Output
4 1 1 4 2 3 4 4 1 2 4 9 3 The number 4 is the most frequent (occurs 5 times)
7 7 7 0 2 2 2 0 10 10 10 The numbers 2, 7 and 10 have the same maximal frequence (each occurs 3 times). The leftmost of them is 7.
     */
    public static void MostFrequentNumber()
    {
        WriteLine("Enter a sequence of numbers (space separated):");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var freq = new Dictionary<int, int>();

        foreach (int num in arr)
        {
            freq.TryGetValue(num, out int count);
            freq[num] = count + 1;
        }

        int maxFreq = freq.Values.Max();
        int mostFrequentNumber = freq.First(kvp => kvp.Value == maxFreq).Key;

        WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFreq} times)");
    }

    /**
     * Write a program that reads a string from the console, reverses its letters and prints the
result back at the console.
Write in two ways
Convert the string to char array, reverse it, then convert it to string again
Print the letters of the string in back direction (from the last to the first) in a for-loop
     */
    public static void ReverseString()
    {
        Console.WriteLine("Enter a string to reverse:");
        string str = ReadLine();
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        WriteLine(new string(charArray));
    }

    /**
     * Write a program that reverses the words in a given sentence without changing the
punctuation and spaces
Use the following separators between the words: . , : ; = ( ) & [ ] " ' \ / ! ? (space).
All other characters are considered part of words, e.g. C++, a+b, and a77 are
considered valid words.
The sentences always start by word and end by separator
     */
    public static void ReverseWords()
    {
        WriteLine("Enter a sentence to reverse:");
        string sentence = ReadLine();
        string[] words = sentence.Split(new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        // WriteLine(String.Join("|", words));
        string[] separators = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries);
        // WriteLine(String.Join("|", separators));
        Array.Reverse(words);
        StringBuilder reversedSentence = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            // WriteLine("word: " + words[i]);
            reversedSentence.Append(words[i]);
            if (i < separators.Length)
            {
                // WriteLine("sep: " + separators[i]);
                reversedSentence.Append(separators[i]);
            }
        }

        WriteLine(reversedSentence);
    }

    /**
     * Write a program that extracts from a given text all palindromes, e.g. “ABBA”, “lamal”, “exe”
and prints them on the console on a single line, separated by comma and space.Print all
unique palindromes (no duplicates), sorted
Hi,exe? ABBA! Hog fully a string: ExE. Bob
a, ABBA, exe, ExE
     */
    public static void ExtractPalindromes()
    {
        WriteLine("Enter a text to extract palindromes:");
        string sentence = ReadLine();
        string pattern = "[^a-zA-Z]+";
        string[] words = Regex.Split(sentence, pattern);
        List<string> palindromes = new List<string>();
        foreach (string word in words)
        {
            if (IsPalindrome(word) && !palindromes.Contains(word))
            {
                palindromes.Add(word);
            }
        }

        palindromes.Sort();
        WriteLine(string.Join(", ", palindromes));
    }

    private static bool IsPalindrome(string word)
    {
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    /**
     * Write a program that parses an URL given in the following format:
[protocol]://[server]/[resource]
The parsing extracts its parts: protocol, server and resource.
The [server] part is mandatory.
The [protocol] and [resource] parts are optional.
     */
    public static void ParseUrl()
    {
        WriteLine("Enter an URL:");
        string url = ReadLine();
        string protocol = "", server = "", resource = "";

        int protocolEndIndex = url.IndexOf("://");
        if (protocolEndIndex > -1)
        {
            protocol = url.Substring(0, protocolEndIndex);
            url = url.Substring(protocolEndIndex + 3);
        }

        int resourceStartIndex = url.IndexOf("/");
        if (resourceStartIndex > -1)
        {
            server = url.Substring(0, resourceStartIndex);
            resource = url.Substring(resourceStartIndex + 1);
        }
        else
        {
            server = url;
        }

        // Print the parsed parts
        WriteLine("Parsed URL Parts:");
        WriteLine($"Protocol: {protocol}");
        WriteLine($"Server: {server}");
        WriteLine($"Resource: {resource}");
    }
}