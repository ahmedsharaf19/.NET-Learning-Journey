## Agenda
Topics covered in this lecture:
- **Abstraction**  
- **Abstract Class VS Interface**  
- **Static**
- **Sealed**
- **Partial**  
---
## 1. Abstraction

**Definition:**  
Abstraction is the process of hiding complex implementation details and exposing only the necessary functionalities to the user.  
It focuses on **what an object does**, not **how it does it**.

**Purpose:**
- Reduces code complexity.  
- Improves readability and maintainability.  
- Helps focus on the essential behavior of an object.

**Ways to Achieve Abstraction in C#:**
1. **Abstract Classes**
2. **Interfaces**

**Example:**  
When you drive a car, you use the steering wheel, brake, and accelerator (the interface),  
but you don’t need to know how the engine works internally.

---

## 2. Abstract Class vs Interface

| Feature | Abstract Class | Interface |
|----------|----------------|------------|
| **Keyword** | `abstract` | `interface` |
| **Implementation** | Can contain both abstract (no body) and non-abstract (with body) methods | Contains only signatures (until C# 8 — can have default implementations) |
| **Constructor** | Can have a constructor | Cannot have a constructor |
| **Access Modifiers** | Can use access modifiers | All members are public by default |
| **Inheritance** | A class can inherit **only one** abstract class | A class can implement **multiple** interfaces |
| **Usage** | Used when classes share common behavior | Used to define a contract between classes |

**When to Use:**
- Use **Abstract Class** when you want to share **code + structure**.
- Use **Interface** when you only need a **contract of behavior**.

---

## 3. Static

**Definition:**  
A `static` member belongs to the **class itself**, not to any specific object (instance).  
It is shared among all instances of that class.

**Types of Static Members:**
- Static Field  
- Static Method  
- Static Property  
- Static Constructor  
- Static Class  

**Notes:**
- Accessed using the class name, not an object.  
- Static classes cannot be instantiated.  
- Static constructors execute **once**, before any instance or static member is used.

**Use Cases:**
- Utility or Helper classes (e.g., `Math`, `Console`).  
- Shared configurations or constants.

---

## 4. Sealed

**Definition:**  
A `sealed` keyword prevents inheritance.

**Usage:**
- A **sealed class** cannot be inherited.  
- A **sealed method** (inside an inherited class) cannot be overridden again.

**Why Use Sealed:**
- To stop unwanted modifications or extensions.  
- To improve performance (compiler optimization).  
- To protect core or final implementations.

**Examples:**
- Classes like `System.String` are sealed to ensure immutability and prevent inheritance.

---

## 5. Partial

**Definition:**  
`partial` allows splitting a class, struct, or interface definition across multiple files.

**Example:**
```csharp
// File1.cs
public partial class Student
{
    public string Name { get; set; }
}

// File2.cs
public partial class Student
{
    public void Display() => Console.WriteLine(Name);
}
```
### Notes:
- All parts must use the partial keyword.
- All parts must be in the same namespace and assembly.
- At compile time, the compiler merges them into a single class.

### Why Use Partial:
- Improves organization in large projects.
- Allows multiple developers to work on the same class.
- Commonly used in auto-generated code (e.g., Entity Framework, WinForms).

---
## Summary
| Concept                         | Meaning                                                            |
| ------------------------------- | ------------------------------------------------------------------ |
| **Abstraction**                 | Hiding complex implementation and showing only essential features. |
| **Abstract Class vs Interface** | Abstract = partial implementation; Interface = contract only.      |
| **Static**                      | Belongs to the class itself, shared by all instances.              |
| **Sealed**                      | Prevents inheritance or further modification.                      |
| **Partial**                     | Splits one class definition across multiple files.                 |
