# 01 Introduction to C# and Data Types

## Understanding Data Types

1. What type would you choose for the following "numbers"?

- A person's telephone number: long
- A person's height: double
- A person's age: int
- A person's gender (Male, Female, Prefer Not To Answer): enum
- A person's salary: decimal
- A book's ISBN: long
- A book's price: decimal
- A book's shipping weight: double
- A country's population: uint
- The number of stars in the universe: ulong
- The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business): ushort

2. What are the difference between value type and reference type variables? What is boxing and unboxing?
   A: Value types store the actual value on memory, reference types store a reference to the value on memory. Boxing is the process of converting a value type to a reference type, unboxing is the process of converting a reference type to a value type.

3. What is meant by the terms managed resource and unmanaged resource in .NET
   A: Managed resources are resources that are managed by the .NET runtime, which will be taken care of during garbage collection. Unmanaged resources are resources that are not managed by the .NET runtime.

4. Whats the purpose of Garbage Collector in .NET?
   A: To automatically manage memory in .NET, freeing up memory that is no longer in use. So that developers don't have to manually manage memory and prevent memory leaks.

## Controlling Flow and Converting Types

1. What happens when you divide an int variable by 0?
   A: It throws a `DivideByZeroException`
2. What happens when you divide a double variable by 0?
   A: It returns `Infinity`
3. What happens when you overflow an int variable, that is, set it to a value beyond its
   range?
   A: It throws an `OverflowException`
4. What is the difference between x = y++; and x = ++y;?
   A: `x = y++;` assigns the value of y to x and then increments y. `x = ++y;` increments y and then assigns the value of y to x.
5. What is the difference between break, continue, and return when used inside a loop
   statement?
   A: `break` exits the loop, `continue` skips the current iteration and goes to the next one, `return` exits the method.
6. What are the three parts of a for statement and which of them are required?
   A: Initialization, Condition, Iteration. All are required but can be empty.
7. What is the difference between the = and == operators?
   A: `=` is the assignment operator, which assigns a right to a left. `==` is the equality operator, which checks if two values are equal.
8. Does the following statement compile? for ( ; true; ) ;
   A: Yes, it compiles. It's a infinity loop with no initialization or iteration, but the condition is true.
9. What does the underscore _ represent in a switch expression?
   A: It represents the default case.
10. What interface must an object implement to be enumerated over by using the foreach
    statement?
    A: `IEnumerable` interface.

# 02 Array and Strings

1. When to use String vs. StringBuilder in C#?
   A: Use `String` when you don't need to modify the string, use `StringBuilder` is similar t oa char array, it's mutable and more efficient when you need to modify the string.
2. What is the base class for all arrays in C#?
   A: `System.Array`
3. How do you sort an array in C#?
   A: `Array.Sort(arr)`
4. What property of an array object can be used to get the total number of elements in
   an array?
   A: `arr.Length`
5. Can you store multiple data types in System.Array?
   A: Yes.
6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
   A: `CopyTo()` copies the elements of one array to another array, `Clone()` creates a shallow copy of the array.