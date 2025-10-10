# C# Course – Session 5

## Agenda

1. Functions
2. Boxing, Unboxing
3. Nullable Type
4. Null Propagation
---
# 1. Functions

## What is a Function (Method)?
A **Function** (also called a **Method**) is a **code block** that contains a set of statements executed when the method is **called**.

In C#, the `Main()` method is the **starting point** of the program — the C# runtime looks for it to begin execution.

---

## Method Prototype
A method prototype defines how the method looks. It consists of:

1. **Access Modifier** – defines the visibility of the method (e.g., `public`, `private`).
2. **Return Type** – specifies the type of value the method returns (e.g., `int`, `void`).
3. **Method Name** – the identifier of the method.
4. **Parameters** – input values passed to the method.

###  Example:
```csharp
public int AddNumbers(int a, int b)
{
    return a + b;
}
```
## Method Signature
The method signature in C# includes:
1. Return Type
2. Method Name
3. Parameter List

### Naming Conventions
In C#, method names use PascalCase.
- 👉 Example: `CalculateTotal()`, `GetStudentInfo()`

## Function Parameters

Functions in C# can accept **different types of parameters**.  
There are **5 main types** of parameters:

1. **Value**
2. **Default**
3. **Reference**
4. **Out**
5. **Params**

---

### 1.  Value Parameters
These are parameters of any **value type** (like `int`, `float`, `bool`, etc.).

There are **two ways** to pass value parameters:

#### a. Passing by Value
- A **copy** of the variable’s value is sent to the function.  
- Any changes made inside the function **do not affect** the original variable.

#### b. Passing by Reference (`ref`)
- The **memory address** of the variable is passed.  
- Any modification inside the function **affects the original value**.

💡 In both cases, **a memory location** is allocated for the parameter, but in `ref`, it points directly to the original variable.

---

### 2. Default Parameters
A **default parameter** is assigned a **default value** in the method definition.  
If the caller does **not** provide a value, the **default value** is used.

```csharp
void PrintMessage(string message = "Hello, World!")
{
    Console.WriteLine(message);
}

PrintMessage();          // Output: Hello, World!
PrintMessage("Hi!");     // Output: Hi!

```
### 3. Reference Parameters
- These are parameters that are of reference types such as classes or interfaces.
- There are two ways to pass reference types:

#### a. Passing by Value
- A copy of the reference (address) is passed.
- The parameter itself has its own memory space, but both refer to the same object.

#### b. Passing by Reference (ref)
- The actual reference itself is passed — no new memory space is created.
- It’s like giving the method an alias to the original variable.

### 4. Out Parameters
- out parameters allow a method to return multiple values.
- The method must assign a value to each out parameter before exiting.
- It’s similar to returning multiple results from one function.

```csharp
void GetNumbers(out int a, out int b)
{
    a = 10;
    b = 20;
}

int x, y;
GetNumbers(out x, out y);
Console.WriteLine($"{x}, {y}"); // Output: 10, 20
```

### 5. Params Parameters
- Used when you don’t know how many arguments will be passed.
- They allow you to pass a variable number of arguments as a collection (array).
```csharp
void PrintNumbers(params int[] numbers)
{
    foreach (int num in numbers)
        Console.WriteLine(num);
}

PrintNumbers(1, 2, 3, 4, 5);
```
⚠️ Notes:

- A method can have only one params parameter.
- It must appear last in the parameter list.

## Parameter Order Convention
When defining parameters, the order should be:
1. Required parameters
2. Default parameters
3. Params parameter
---
# 2. Boxing & Unboxing

###  What is Boxing?
**Boxing** is the process of **converting a Value Type to a Reference Type**.

It happens **implicitly** in C#.  
The **value type** is **wrapped (boxed)** inside an **object** and stored in the **heap**, while a **reference** to it is placed on the **stack**.

####  Example:
```csharp
int num = 10;        // Value type stored in Stack
object obj = num;    // Boxing: num is wrapped into an object and moved to the Heap
```
#### 💡 Notes:
- Boxing is implicit (happens automatically).
- It’s slow because of the memory allocation and data copy between the stack and the heap.
- Used when a value type needs to be treated as an object (e.g., storing in a collection of objects).

### what is Unboxing?
- Unboxing is the reverse process — converting a Reference Type back into a Value Type.
- It happens explicitly, because the compiler needs to know what value type to extract from the object.

#### Example:
```csharp
object obj = 10;        // Boxing
int num = (int)obj;     // Unboxing: extracting the value from the object back to a value type
```
#### 💡 Notes:

- Unboxing is explicit — you must specify the target value type.
- It’s also slow, because it involves:
    - Accessing the object in the heap.
    - Copying its data back to the stack.
- If the cast type doesn’t match, a runtime error occurs.

---
## Summary
| Operation    | Direction         | Implicit/Explicit | Location     | Performance |
| ------------ | ----------------- | ----------------- | ------------ | ----------- |
| **Boxing**   | Value → Reference | Implicit          | Stack → Heap | Slow        |
| **Unboxing** | Reference → Value | Explicit          | Heap → Stack | Slow        |
---
# Nullable Types & Null Propagation


###  Nullable Value Types
By default, **Value Types** (like `int`, `double`, `bool`, etc.) **cannot hold `null`**.  
But sometimes we need to represent the **absence of a value** — for example, when reading optional data from a database.  
That’s where **Nullable Value Types** come in.

You can make any value type **nullable** by adding a `?` after its type.

####  Example:
```csharp
int? age = null;      // Nullable int can hold null
bool? isActive = true;
```
- You can check whether a nullable variable has a value using:
    - .HasValue
    - .Value

#### Example:
```csharp
int? number = null;

if (number.HasValue)
    Console.WriteLine(number.Value);
else
    Console.WriteLine("No value found");
```
#### Note:
- `Nullable<T>` is the underlying structure. So int? is just shorthand for `Nullable<int>`.

### Nullable Reference Types (C# 8.0+)
- Before C# 8.0, reference types (like string, class, object) could always be null, which caused NullReferenceExceptions at runtime.
- From C# 8.0, you can enable Nullable Reference Types to make your code safer by distinguishing between:
- Nullable reference (can hold null)
- Non-nullable reference (should never hold null)
- You enable this feature using:
```csharp 
#nullable enable
```
```csharp
#nullable enable

string name = "Ahmed";    // Non-nullable (cannot be null)
string? address = null;   // Nullable reference type
```
If you try to assign null to name, the compiler will give you a warning.

#### Purpose:
It helps developers avoid null reference errors at compile-time instead of runtime.
---
## 5. Null-Conditional (Null Propagation) Operator
- The Null-Conditional Operator `(?.)` allows you to safely access members of an object that might be `null`.
- Instead of throwing an exception, it returns null if the object before `?`. is `null`.
```csharp
Person person = null;

// Without null propagation → would throw NullReferenceException
// Console.WriteLine(person.Name);

Console.WriteLine(person?.Name);  // Safe — prints nothing instead of crashing
```
You can also use it with method calls and indexers:
```csharp
int? length = person?.Name?.Length;
```
If person or Name is `null`, the entire expression returns `null` safely.
---
## 6. Null-Coalescing Operator (??)
Often used together with `?`., this operator provides a default value if the result is null.

#### Example:
```csharp
string name = person?.Name ?? "Unknown";
```
If person or Name is `null` → "Unknown" is used instead.
---
## Summary
| Concept                       | Description                       | Example                 | Null Safe? |
| ----------------------------- | --------------------------------- | ----------------------- | ---------- |
| **Nullable Value Type**       | Value type that can hold `null`   | `int? age = null;`      | ✅          |
| **Nullable Reference Type**   | Reference type marked as nullable | `string? name;`         | ✅          |
| **Null-Conditional Operator** | Safe access for possible nulls    | `person?.Name`          | ✅          |
| **Null-Coalescing Operator**  | Provides fallback value if null   | `person?.Name ?? "N/A"` | ✅          |
