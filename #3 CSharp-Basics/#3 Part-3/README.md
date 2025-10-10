# C# Course – Session 3

## Agenda

1. Fraction and Discard
2. Casting
3. Operators
4. String Formating
5. Conditional Statements
---
## 1. Fraction and Discard

### Overview
In C#, **fractional numbers** (numbers with decimal points) can be represented using different data types that vary in **precision**, **memory size**, and **performance**.

### Fractional Number Types

#### 1. `float` — *Single Precision Floating Point*
- **Precision:** ~7 digits (total before and after the decimal point)  
- **Size:** 4 bytes  
- **Notes:** Add suffix `f` to indicate a float value.  
  ```csharp
  float price = 12.5f;
  ```
#### 2. double — *Double Precision Floating Point*

- **Precision:** ~15–16 digits
- **Size:** 8 bytes
- **Notes:** This is the default type for floating-point numbers.
```csharp
double distance = 12345.6789;
```
#### 3. decimal — *High Precision Floating Point*

- **Precision:** ~28–29 digits
- **Size:** 16 bytes

- **Notes:** 
1. Higher precision, larger size, slower performance.
2. Add suffix m to indicate a decimal value.
```csharp
decimal salary = 12345.67m;
```

### Discard (Underscore for Readability)
- You can use underscores (_) to make long numbers more readable.
- This does not affect the actual numeric value.
```csharp
int population = 10_000_000;
float pi = 3.14_15f;
```
---
## 2️. Casting

###  Overview
**Casting** refers to the process of converting a variable from one data type to another.  
In C#, there are **two main types of casting** — *implicit* and *explicit*.

---

### 1. Implicit Casting (Automatic)
- Happens **automatically** when converting from a **smaller** data type to a **larger** one.  
- **Safe conversion** — no data loss occurs.  
- Example:
  ```csharp
  int num = 10;
  double result = num; // int → double (automatic)
    ```
### 2. Explicit Casting (Manual)
- Performed **manually** when converting from a **larger** to a **smaller** data type.
- May cause data loss or runtime errors if the conversion is invalid.
Syntax:
```csharp
double value = 9.78;
int intValue = (int)value; // double → int (fraction is lost)
```

#### Methods of Casting
##### 1. Convert Class
- Part of the .NET framework — provides methods to convert between types.
- Handles null values by converting them to 0.
- May throw an exception if the conversion is invalid.
```csharp
string str = "123";
int number = Convert.ToInt32(str);
```

##### 2. Parse() Method
- Commonly used to convert strings to numeric types.
- Throws an exception if the string cannot be converted.
```csharp
string input = "50";
int value = int.Parse(input); // works fine
// int error = int.Parse("abc"); // throws exception
```

##### 3. TryParse() Method
- Works like Parse() but does not throw exceptions.
- Returns true or false depending on whether the conversion succeeded.
- Uses the out keyword to store the converted value.
```csharp
string input = "200";
int result;
bool success = int.TryParse(input, out result);

if (success)
    Console.WriteLine($"Conversion succeeded: {result}");
else
    Console.WriteLine("Conversion failed");
```

---
## 3️. Operators

###  Overview
In C#, **operators** are special symbols used to perform operations on variables and values.  
They can be classified into several categories depending on how many operands they work with and what type of operation they perform.

---

###  1. Unary Operators
- Operate on **a single operand**.  
- Common unary operators:  
  - `++` → Increment by 1  
  - `--` → Decrement by 1  

```csharp
int x = 5;
x++; // 6
x--; // 5
```

### 2. Binary (Arithmetic) Operators
- Work on two operands.
- Used for basic mathematical operations.
| Operator | Description         |
| -------- | ------------------- |
| `+`      | Addition            |
| `-`      | Subtraction         |
| `*`      | Multiplication      |
| `/`      | Division            |
| `%`      | Modulus (remainder) |
```csharp
int a = 10, b = 3;
int sum = a + b;     // 13
int mod = a % b;     // 1
```
### 3. Assignment Operators
- Used to assign values to variables.
- Work from right to left.
| Operator | Example  | Equivalent To |
| -------- | -------- | ------------- |
| `=`      | `x = 5`  | —             |
| `+=`     | `x += 2` | `x = x + 2`   |
| `-=`     | `x -= 2` | `x = x - 2`   |
| `*=`     | `x *= 2` | `x = x * 2`   |
| `/=`     | `x /= 2` | `x = x / 2`   |
| `%=`     | `x %= 2` | `x = x % 2`   |

### 4. Relational (Comparison) Operators
- Compare two values and return a boolean result (true or false).
| Operator | Meaning                  |
| -------- | ------------------------ |
| `==`     | Equal to                 |
| `!=`     | Not equal to             |
| `>`      | Greater than             |
| `<`      | Less than                |
| `>=`     | Greater than or equal to |
| `<=`     | Less than or equal to    |

```csharp
int a = 5, b = 10;
bool result = a < b; // true
```

### 5. Logical Operators
- Used for logical conditions (true/false).
- Represent logic gates and used with conditional expressions.
- They are short-circuit operators, meaning they stop evaluating once the result is known.
| Operator | Meaning |   |    |
| -------- | ------- | - | -- |
| `!`      | NOT     |   |    |
| `&&`     | AND     |   |    |
| `        |         | ` | OR |

- Short-Circuit Behavior:
```csharp
// In an AND (&&), if the first is false, the result is false — no need to continue
bool result1 = false && (10 > 5); // false

// In an OR (||), if the first is true, the result is true — no need to continue
bool result2 = true || (5 > 10); // true
```

### 6. Bitwise Operators
- Work at the bit level (operate directly on binary representations).
- They are long-circuit operators — the full expression is always evaluated.
| Operator | Meaning                  |    |
| -------- | ------------------------ | -- |
| `&`      | AND                      |    |
| `        | `                        | OR |
| `^`      | XOR (exclusive OR)       |    |
| `~`      | NOT (bitwise complement) |    |
| `<<`     | Left shift               |    |
| `>>`     | Right shift              |    |

```csharp
int a = 5;   // 0101 in binary
int b = 3;   // 0011 in binary
int result = a & b; // 0001 → 1
```
- Shift Operators Explanation
Right Shift (>>) | Moves bits to the right → equivalent to dividing by 2ⁿ
```mathematica
M >> N  ≈  M / (2^N)
```
Left Shift (<<) | Moves bits to the left → equivalent to multiplying by 2ⁿ
```mathematica
M << N  ≈  M * (2^N)
```

```csharp
int x = 8;  // 1000
int rightShift = x >> 1; // 0100 → 4
int leftShift  = x << 1; // 10000 → 16
```
---
## 4️. String Formatting

###  Overview
**String formatting** in C# allows you to combine text with variable values in a clear and readable way.  
There are several methods to create formatted strings.

---

###  1. String Interpolation
- Introduced in C# 6.  
- Allows embedding **expressions** directly inside a string.  
- Starts with the `$` symbol before the string.  
- Variables or expressions are written inside `{}` braces.

```csharp
string name = "Ahmed";
int age = 25;

string message = $"Name = {name}, Age = {age}";
Console.WriteLine(message); // Output: Name = Ahmed, Age = 25
```
### 2. String.Format() Method
- Allows using placeholders {} inside the string, replaced by variable values in order.
- Each placeholder uses a zero-based index.
```csharp
string name = "Ahmed";
int age = 25;

string message = string.Format("Name = {0}, Age = {1}", name, age);
Console.WriteLine(message); // Output: Name = Ahmed, Age = 25
```

### 3. Composite Formatting
- Similar to String.Format(), but used directly inside Console.WriteLine().
- Makes the code shorter when printing formatted text.
```csharp
string name = "Ahmed";
int age = 25;

Console.WriteLine("Name = {0}, Age = {1}", name, age);
// Output: Name = Ahmed, Age = 25
```
### 4. String Concatenation
- Used to combine multiple strings together.
- You can use the + operator or the String.Concat() method.
- Not recommended for heavy string operations because strings are immutable — each concatenation creates a new string in memory.
```csharp
string firstName = "Ahmed";
string lastName = "Sharaf";

string fullName1 = firstName + " " + lastName;
string fullName2 = string.Concat(firstName, " ", lastName);

Console.WriteLine(fullName1); // Output: Ahmed Sharaf
```
---
## 5️. Control Statements

###  Overview
**Control statements** in C# are commands used to control the **flow of program execution**.  
They allow you to make decisions, repeat code, or jump to specific parts of the program.

---

###  1. Conditional / Selection Statements
These statements execute code **based on specific conditions**.

####  `if`, `else if`, `else`
Used to check one or more conditions and execute code accordingly.

```csharp
int age = 18;

if (age < 13)
{
    Console.WriteLine("Child");
}
else if (age < 18)
{
    Console.WriteLine("Teenager");
}
else
{
    Console.WriteLine("Adult");
}
```
#### switch
Used to execute one block of code among multiple options based on a specific value.
```csharp
int day = 3;

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}
```

### 2. Looping / Iteration Statements
- These statements are used to repeat code multiple times until a condition is met.

#### for Loop
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteration {i}");
}
```

#### while Loop
```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine(i);
    i++;
}
```

#### do-while Loop
- Executes the code at least once, even if the condition is false.
```csharp
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 5);
```

#### foreach Loop
- Used to iterate through collections like arrays or lists.
```csharp
string[] names = { "Ahmed", "Omar", "Sara" };
foreach (string name in names)
{
    Console.WriteLine(name);
}
```

### 3. Jump Statements
- Used to change the normal flow of execution — skip parts, break loops, or exit methods.
| Statement  | Description                                                     |
| ---------- | --------------------------------------------------------------- |
| `break`    | Exits from the current loop or switch block.                    |
| `continue` | Skips the current iteration and moves to the next one.          |
| `return`   | Exits from a method and optionally returns a value.             |
| `goto`     | Jumps to a labeled statement (not recommended for regular use). |


```csharp
for (int i = 0; i < 5; i++)
{
    if (i == 2)
        continue; // skips number 2

    if (i == 4)
        break; // stops loop when i == 4

    Console.WriteLine(i);
}

void SayHello()
{
    Console.WriteLine("Hello!");
    return; // exits the method
}
```

---
### ⚡ Notes on `switch` Statement

- Each `case` **must end with a `break` statement** (unless you intentionally use `goto` or `return`).  
  This prevents the program from “falling through” into the next case.

- Internally, the **`switch` statement** can build a **jump table**, which stores all the case values and allows the program to **jump directly** to the matching case in **one step** — making it faster than multiple `if-else` checks.

- However, the compiler **does not always** create a jump table.  
  It only does so **when it’s beneficial** (for example, when the case values are continuous or close in range).
