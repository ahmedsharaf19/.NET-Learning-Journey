# C# Course – Session 4

## Agenda

1. Evolution of switch in C#
2. Loop Statements
3. String
4. String Builder
5. Arrays
---

## 1. Evolution of `switch` in C#

###  C# 1.0 – C# 6.0
- The `switch` statement could only work with **integral types** (e.g., `int`, `char`, `byte`) or **enums**.
- Each `case` label had to be a **constant expression**.
- Example:
  ```csharp
  int x = 2;
  switch (x)
  {
      case 1:
          Console.WriteLine("One");
          break;
      case 2:
          Console.WriteLine("Two");
          break;
      default:
          Console.WriteLine("Other");
          break;
  }
  ```
### C# 7.0 – Pattern Matching
- `switch` became more powerful and flexible.
- Introduced pattern matching, allowing cases to match based on:
- The type of the variable.
- A condition (called a case guard) using the `when` keyword.
```csharp
object value = 10;

switch (value)
{
    case int i when i > 5:
        Console.WriteLine("Integer greater than 5");
        break;
    case string s:
        Console.WriteLine($"It's a string: {s}");
        break;
    default:
        Console.WriteLine("Unknown type");
        break;
}
```
### C# 8.0 – Switch Expressions
- Introduced switch expressions, making it possible to assign the result of a switch directly to a variable.
- More concise and expressive syntax.

Example 1 – Simple Value Matching:
```csharp 
string option = "1";
string message = option switch
{
    "1" => "Option 1",
    "2" => "Option 2",
    _ => "Discard"
};
```
Example 2 – Property Pattern Matching: 
```csharp 
Person p = new Person() { Id = 10, Name = "Ali", Age = 23 };

string message = p switch
{
    { Name: "Ahmed", Age: 10 } => "Ahmed and age 10",
    { Name: "Ali" } => "Ali",
    { Id: 10 } => "Id 10",
    _ => "Discard"
};
```
### C# 9.0 – Relational and Logical Patterns
- Introduced **relational patterns**: `<`, `>`, `<=`, `>=`.
- Introduced **logical patterns**: `and`, `or`, `not`.
- This allows combining multiple conditions in a `switch` case in a clean way.
- Example:
```csharp
int n = 20;

string result = n switch
{
    < 10 => "< 10",
    >= 10 and <= 20 => ">= 10 and <= 20",
    > 20 => "> 20"
};
```
After C# 9.0, there have been no major updates to the `switch` statement.
---
## 2. Loop (Iteration) Statements

###  Purpose
The main purpose of a **loop** (or **iteration statement**) is to **repeat a set of statements** multiple times automatically, instead of writing them manually.

###  Problems with Manual Repetition
If we repeat code manually instead of using loops, we face several issues:

1. **Increased Code Size**
   - Writing the same statements multiple times leads to a **larger compiled code size**.
   - Loops make the code smaller and more memory-efficient.

2. **Higher Memory Usage and Lower Performance**
   - Each repeated line consumes more memory, which affects runtime performance due to **JIT (Just-In-Time) compilation overhead**.
   - Using loops allows the compiler to **optimize execution**, resulting in faster performance even though loops involve steps like initialization, condition checking, and incrementing.

###  Advantages of Using Loops
- **Smaller and cleaner code.**
- **Better performance** due to compiler optimizations.
- **Easier maintenance** — changes can be made in one place.
- **Improved readability** — the flow of repetition is clear and structured.
---
### Types of Loops in C#

#### 1. **For Loop**
Used when the number of iterations is known in advance.

```csharp
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}
```
- Execution Steps:

1. Initialization → `int i = 1` → executed once at the beginning.
2. Condition Check → `i <= 10` → if true, execute the loop body.
3. Body Execution → the block inside `{ }` runs.
4. Increment → `i++` → increases i by 1, then the loop repeats from step 2.

#### 2. Foreach Loop
Used to iterate over collections (arrays, lists, etc.) without manually handling indexes.
```csharp
foreach (var item in collection)
{
    // Code block
}
```

- How It Works Internally:

1. The compiler uses a function called GetEnumerator() to get an iterator for the collection.

2. The loop repeatedly calls:

    - MoveNext() → checks if there is a next element.

    - Current → retrieves the current element.

    - When there are no more elements, the loop ends.
    
Notes:
- A foreach loop is slower than a for loop because of the internal enumerator mechanism.
- You cannot modify the elements directly inside a foreach loop, because it iterates over values, not references or indexes.

#### 3. While Loop
Executes a block of code as long as a condition is true.
```csharp
while (condition)
{
    // Code block
}
```
Behavior:
1. Checks the condition before executing the body.
2. If the condition is false initially, the body will not run at all.

#### 4. Do–While Loop
Executes the block first, then checks the condition.
```csharp
do
{
    // Code block
}
while (condition);
```
Behavior:
- The body runs at least once, even if the condition is false from the start.

---
### Performance (Fastest to Slowest)

1. do–while
2. while
3. for
4. foreach

---
## 3. String

###  Definition
- `string` is a **built-in class** in C#, which means it is a **reference type**.  
- It represents a **sequence of characters** stored as an **array of `char`**, where each character takes **2 bytes** (Unicode).  

###  Immutability
- A `string` in C# is **immutable**, meaning **once it’s created, it cannot be changed**.  
- Any operation that looks like it modifies a string (e.g., concatenation) actually creates a **new string object in the heap**.

```csharp
string name = "Ahmed";
name += " Sharaf"; // Creates a new string object
```
Every time you modify a string, a new object is created, and the old one may eventually be garbage-collected.

#### String Interning (String Pool)
- C# uses a String Pool (Intern Pool) to optimize memory usage.
- When you create a string literal, the runtime checks if the same value already exists in the pool:
    - If yes → it reuses the existing object.
    - If no → it creates a new one and adds it to the pool.

```csharp
string s1 = "Hello";
string s2 = "Hello";

Console.WriteLine(object.ReferenceEquals(s1, s2)); // True (same reference)
```
This caching mechanism improves performance and reduces memory usage.
---
## 4. StringBuilder

### Definition
- StringBuilder is also a built-in class and a reference type.
- It represents a mutable sequence of characters, meaning you can modify it without creating a new object.
- Internally, it stores characters in a dynamic buffer (not necessarily contiguous in memory, like a linked list or resizable array).

### Features
- Mutable → You can modify, append, or remove text without allocating new objects.
- Efficient for repeated concatenations (e.g., building large strings in loops).

```csharp 
using System.Text;

StringBuilder message = new StringBuilder();
message.Append("Ahmed");
message.Append(" ");
message.Append("Sharaf");

Console.WriteLine(message); // Output: Ahmed Sharaf
```
### Performance
- For small or single-use strings, use string.
- For heavy string operations (like in loops or file generation), use StringBuilder for better performance and less memory allocation.
---
## 5. Arrays

### Definition
An **array** is a **data structure** that stores a **fixed-size sequence of elements** of the **same data type**.  
It allows you to group multiple values under a single variable name.

### Characteristics
1. **Fixed Size** → Once an array is created, its size cannot be changed.  
2. **Same Data Type** → All elements must be of the same type.  
3. **Zero-Based Index** → The first element always starts at index `0`.

---

### 1. One-Dimensional Array
A simple, linear list of elements.

```csharp
int[] numbers;              // Reference to a 1D array
numbers = new int[3];       // Creates an array with 3 elements
numbers[1] = 50;
```
Advantages:
- Fast access — you can reach any element in one step using its index.

Disadvantages:
- The size is fixed, so it cannot grow or shrink dynamically.

### 2. Multi-Dimensional Array

Represents data in a table-like structure (rows and columns).
```csharp
int[,] marks = new int[3, 5];
marks[1, 2] = 10;
```
- Also called a rectangular array because all rows have the same number of columns.

### 3. Jagged Array
A “one-dimensional array of arrays.”
Each element of the main array references another array — and each subarray can have a different size.
```csharp
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[2];
jaggedArray[1] = new int[4];
jaggedArray[2] = new int[3];
```
- More flexible than rectangular arrays.
- Each row (subarray) can contain a different number of elements.
---
### Common Array Methods
| Method                | Description                                                           |
| --------------------- | --------------------------------------------------------------------- |
| `Array.Sort()`        | Sorts the elements of the array in ascending order.                   |
| `Array.Reverse()`     | Reverses the order of elements.                                       |
| `Array.Copy()`        | Copies elements from one array to another.                            |
| `Array.Clear()`       | Clears all elements (sets to default value).                          |
| `Array.IndexOf()`     | Returns the index of the first occurrence of an element.              |
| `Array.LastIndexOf()` | Returns the last occurrence index of an element.                      |
| `Array.Resize()`      | Changes the size of an existing array (creates a new one internally). |
