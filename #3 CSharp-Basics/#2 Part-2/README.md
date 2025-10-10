# C# Course – Session 2

## Agenda

1. Compiler vs Interpreter
2. Error Type
3. Variable Declaration
4. Comments and Regions
5. CTS and CLS
6. Datatypes [Values - References]
7. Object

---

## 1. Compiler vs Interpreter

There are two different ways to process a programming language and convert it from **high-level code** to **machine code**:

### 1. Compiler

* Translates the **entire code** at once into machine code.
* Produces an **executable file** as the output.

### 2. Interpreter

* Performs two tasks: it first translates the code into machine code, then executes it **line by line**.
* Works step by step during runtime.

---

### Comparison Between Compiler and Interpreter

| Feature           | Compiler                                                                              | Interpreter                                            |
| ----------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------ |
| Translation       | Translates the entire code at once                                                    | Translates code line by line                           |
| Execution Speed   | Faster execution                                                                      | Slower execution (line by line)                        |
| Error Handling    | Shows all errors **after compilation**, before execution                              | Detects errors **during execution**                    |
| Output            | Generates an **executable file**                                                      | No output file generated                               |
| Memory Usage      | Requires more memory to store the executable file but uses less memory during runtime | Uses less memory for storage but more during execution |
| Example Languages | C, C++                                                                                | JavaScript, Python, PHP                                |

---

### Hybrid Languages

Some languages use a **hybrid approach**, combining both compilation and interpretation to balance **performance** and **flexibility**.

Example: **C#**

* The code is **compiled** into an **IL file** (Intermediate Language).
* Then it is **interpreted** by the **JIT (Just-In-Time Compiler)** during execution.
---
## 2. Error Type

Types of errors:
1. **Syntax Error**
2. **Logical Error**
3. **Run-time Error**
4. **Warning** (not an error — a warning does not stop code execution)

---

### 1. Compile-time Error (Syntax Error)
These errors result from not following the language rules and are detected by the **compiler**.

---

### 2. Run-time Error
These occur during program execution and are caused by illegal operations, such as division by zero or using a **null reference**.

---

### 3. Logical Error
Not really an "error" in terms of crashing — it produces **incorrect output** (not what we expect).  
This is the hardest to find; we need to **debug** and fix faulty algorithms or incorrect data handling.

---

### 4. File I/O Errors
These occur when trying to read from or write to a file that does not exist or for which the program lacks permission.

---

There are many other types of errors as well.
---
## 3. Comments

**Comments** are used to add notes, explanations, or documentation within the code.  
They make the code easier to understand and maintain.

There are **three main types** of comments:

---

### 1. Single-line Comment
Used for short notes or explanations.

```csharp
// This is a single-line comment
```
### 2. Multi-line Comment
Used for longer explanations that span multiple lines.
```csharp
/*
   This is a multi-line comment
   It can span across multiple lines
*/
```

### 3. XML Comment
- Used for structured documentation — typically for summarizing classes, methods, or properties.
- They begin with /// and can generate XML documentation automatically.
```csharp
/// <summary>This method calculates the total price including tax.</summary>
```
---
## 4. Regions

**Regions** are collapsible sections in code.  
They help organize and group related code blocks together, making it easier to navigate large files.

You can define a region using the `#region` and `#endregion` directives.

```csharp
#region RegionName
// Your code here
#endregion
```
---
## 5. Variable Declaration

To declare a **variable**, you need to specify the **data type** it will hold and give it a **name**.  
You can also assign a value during declaration, or leave it uninitialized to assign later.

**Syntax:**

```csharp
DataType Name = Value;
```
---
## 6. Data Types

The **Data Types** in C# are divided into two main categories:

### 1. Value Types  
These include types like `int`, `char`, and user-defined types such as `struct` and `enum`.  
They are stored in the **stack** because their size is known at compile time.  
Value types contain the **actual data** themselves, which makes them **faster** to access.  

**Examples:**
```csharp
int number = 10;
char letter = 'A';
```

### 2. Reference Types  
These are **non-primitive types** such as `class`, `interface`, `delegate`, `array`, and `string`.  
They store a **reference (pointer)** that points to the actual data stored in the **heap**.

So, we have:
- A **reference** in the stack holding the **address** of the data.  
- The **actual object** in the heap, called the **object state** or **instance**.

**Example:**
```csharp
string name = "Ahmed";
int[] numbers = {1, 2, 3};
```
---
### 🧠 Notes on Variables and Data Types

- Any **unassigned variable** must be given a **value before usage**.  
  ```csharp
  int x;
  Console.WriteLine(x); // ❌ Error: Use of unassigned local variable 'x'
```
- When declaring a reference type, it gets a default value of null.
```csharp
string name;
Console.WriteLine(name); // ❌ Error: Use of unassigned local variable 'name'
```
- Default values for value types depend on their data type:
| Data Type | Default Value |
| --------- | ------------- |
| `int`     | `0`           |
| `float`   | `0.0f`        |
| `double`  | `0.0d`        |
| `char`    | `'\0'`        |
| `bool`    | `false`       |
| `string`  | `""`          |
| `object`  | `null`        |

- Every reference type stores an address (reference) pointing to the actual data in the heap.
* The size of this reference is typically:
1. 4 bytes on 32-bit systems.
2. 8 bytes on 64-bit systems.
---
# 7. Object in C#

The **Object** class is the **base class** for all classes and data types in C#.  
Every type — whether **value type** or **reference type** — **inherits** from it.

---

## 🧱 Common Methods in Object

All objects in C# share the same four methods inherited from `System.Object`:

1. **ToString()** → Returns a string representation of the object.  
2. **Equals()** → Compares two objects for equality.  
3. **GetHashCode()** → Returns a unique hash code for the object (used in hashing).  
4. **GetType()** → Returns the runtime type information of the object.

> 🔹 You can **override** `ToString()`, `Equals()`, and `GetHashCode()` in your own classes to change their default behavior.  
> 🔸 `GetType()` **cannot** be overridden — it always returns the type in the format:  
> `Namespace.TypeName`

---

## 💡 Example

```csharp
int x = 10;
Console.WriteLine(x.ToString());       // "10"
Console.WriteLine(x.GetType());        // System.Int32
Console.WriteLine(x.Equals(10));       // True
Console.WriteLine(x.GetHashCode());    // Unique hash code
```
## ⚙️ Object as a Reference Type
- Any reference of type object can point to any data type in C#.
- This was commonly used before generics were introduced.
```csharp
object obj = 5;     // Boxing: Value type → Reference type
int num = (int)obj; // Unboxing: Reference type → Value type
```
## ⚠️ Boxing & Unboxing

- Boxing: Converting a value type to an object (reference type).
- Unboxing: Converting an object back to a value type.

These conversions cause:
1. Performance overhead.
2. Loss of type safety.

➡️ To avoid these issues, Generics were introduced later in C#.