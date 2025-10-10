## Agenda
Topics covered in this lecture:
- **Struct**  
- **OOP Definition**  
- **Encapsulation**  
- **Properties**
---

# 1. Struct in C#

## Definition
A **Struct** (short for *Structure*) is a **value type** in C# that is stored in the **stack**, similar to primitive data types (e.g., `int`, `bool`, `double`).

---

## Characteristics
- **Value Type** → Stored in the stack, not in the heap.  
- **Lightweight** → Uses less memory and is faster than reference types.  
- **No Inheritance** → A struct cannot inherit from or be inherited by other structs or classes.  
- **Used for Simple Objects** → Ideal for small, lightweight objects that don’t require inheritance.  
- **Copied by Value** → When you assign one struct to another, a full copy of the data is made.

---

## Constructors in Structs

### Purpose
A **constructor** in a struct is responsible for **initializing the attributes (fields)**.

- The **compiler** always provides a **default (parameterless) constructor** that automatically initializes all fields with their **default values** (e.g., `0`, `false`, `null`).

### Custom Constructors
- If you define your own constructor, you must manually initialize **all fields** of the struct.  
- Starting from **C# 11**, it’s allowed to define a custom constructor **without initializing all fields**.  

### Constructor Rules
- A constructor is a **special function**:
  1. It has **no return type**.  
  2. Its **name matches** the name of the struct (or class).  
- Structs **can have multiple constructors** using **constructor overloading** (a form of *polymorphism*).

### Default Constructor Behavior
- In structs, the **compiler always provides a parameterless constructor**, whether you explicitly define one or not.

---

## Access Modifiers in Structs
In C#, members inside a struct can only use **three access modifiers**:
- `private`
- `internal`
- `public`

---

## Example
```csharp
struct Point
{
    public int X;
    public int Y;

    // Custom constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
Point p1 = new Point();          // Uses default constructor → X=0, Y=0
Point p2 = new Point(10, 20);    // Uses custom constructor
Console.WriteLine($"X: {p2.X}, Y: {p2.Y}");
```
## When to Use Structs
- Use a struct when:
    - You need a small, lightweight object.
    - You don’t need inheritance or complex object hierarchy.
    - You want better performance for temporary or simple data.

- Use a class instead when:
    - You need inheritance or polymorphism.
    - The object is large or used frequently across your program.
    - You want reference behavior (changes in one variable affect the others).

## Summary
| Feature             | Struct               | Class                     |
| ------------------- | -------------------- | ------------------------- |
| Type                | Value Type           | Reference Type            |
| Memory              | Stack                | Heap                      |
| Inheritance         | ❌ Not Supported      | ✅ Supported               |
| Copy Behavior       | By Value             | By Reference              |
| Default Constructor | Provided by Compiler | Must Be Defined           |
| Use Case            | Small, Simple Data   | Complex, Reusable Objects |
---
# 2. Object-Oriented Programming (OOP) in C#

## Definition
**OOP (Object-Oriented Programming)** is a **programming paradigm** based on the concept of **objects**.  
It aims to build **structured, reusable, and maintainable** software that **mimics real-life systems**.  
In OOP, everything is treated as an **object** that contains both **data** (attributes) and **behavior** (methods).

---

## Main Principles of OOP
OOP is built on **four main principles**:

1. **Encapsulation**  
2. **Inheritance**  
3. **Polymorphism**  
4. **Abstraction**

---

## 1. Encapsulation

### Concept
Encapsulation means **grouping data (attributes)** and the **methods that operate on that data** into a single logical unit — usually a **class** or **struct**.

It helps in organizing the code and **protecting data** from unwanted external access.

### Data Hiding
Encapsulation also includes **data hiding**, which means restricting access to internal data using **access modifiers**.  
This ensures that the internal details of an object are **hidden from the user**, allowing only controlled interaction.

### Benefits
- Better **data protection**.  
- Easier **maintenance and debugging**.  
- More **modular and organized** code.

---

## 2. Inheritance

### Concept
**Inheritance** is the process by which one class **acquires the properties and behaviors** of another class.  
The class that inherits is called the **child class (derived class)**, and the class being inherited from is the **parent class (base class)**.

It allows **code reusability** and helps create **hierarchical relationships** between classes.

### Benefits
- Promotes **code reuse**.  
- Supports **hierarchical organization**.  
- Enables **method overriding** and **polymorphism**.  
- Reduces code duplication.

---

## 3. Polymorphism

### Concept
The term **Polymorphism** comes from Greek, meaning *“many forms.”*  
It allows the same operation or method name to **behave differently** based on the object that calls it.

### Types of Polymorphism
1. **Compile-Time Polymorphism (Overloading)** → Achieved when multiple methods have the same name but different parameter lists.  
2. **Run-Time Polymorphism (Overriding)** → Achieved through inheritance, where a derived class changes the behavior of a method inherited from the base class.

### Benefits
- Improves **flexibility** and **scalability**.  
- Makes the code **easier to extend**.  
- Supports **dynamic behavior** during runtime.

---

## 4. Abstraction

### Concept
**Abstraction** means **hiding complex implementation details** and exposing only the **essential features** to the user.  
It allows interaction with objects at a **high level** without knowing how their internal logic works.

### Benefits
- Simplifies **complex systems**.  
- Improves **security and clarity** by hiding unnecessary details.  
- Makes the code **easier to use and maintain**.

---

## Summary Table

| Principle | Description | Key Idea |
|------------|--------------|-----------|
| **Encapsulation** | Combine data and behavior into one unit and hide data using access modifiers. | Data protection and modular design. |
| **Inheritance** | Derive new classes from existing ones to reuse code. | Code reusability and hierarchy. |
| **Polymorphism** | Allow the same method to behave differently based on the object. | Many forms — flexibility and extensibility. |
| **Abstraction** | Hide complex details and show only necessary functionality. | Simplicity and focus on essential features. |

---

## Overall Purpose of OOP
- To **model real-world entities** as software objects.  
- To write **organized, modular, and reusable** code.  
- To achieve **better maintainability** and **scalability**.  
- To make software development **more intuitive** and **closer to real-world thinking**.
---
# 3. Encapsulation in C#

## Definition
**Encapsulation** is the process of **separating data from its direct access** and allowing interaction with that data **only through controlled methods or properties**.  
It ensures that internal data is **protected** and can be accessed or modified **safely** through a **defined interface**.

---

## Key Idea
Encapsulation means:
- **Hiding the internal data (attributes)** of an object.  
- **Providing controlled access** through **getter** and **setter** methods (or **properties**).  
- Allowing the developer to **validate and control** the data before it’s changed.

---

## How It Works
1. **Attributes** are declared as **private**, meaning they cannot be accessed directly from outside the class.  
2. To access or modify them, the class exposes **getter** and **setter** members.  
3. These getters and setters act as a **bridge (interface)** between the internal data and the outside world.  
4. This setup enables **data validation** and **safe modification**.

---

## Ways to Implement Encapsulation
There are two main ways to create access points for encapsulated data:
1. Using **Getter and Setter Methods**.  
2. Using **Properties**, which are a cleaner, modern alternative in C#.

Both serve the same purpose — they allow **indirect access** to private data.

---

## Benefits of Encapsulation
- **Data Protection:** Prevents unauthorized access or modification.  
- **Data Validation:** Allows validation before assigning a new value.  
- **Controlled Access:** You decide what can be read or modified externally.  
- **Maintainability:** Changes inside the class don’t affect external code.  
- **Flexibility:** Internal logic can change without breaking the outer code.

---

## Example in Concept (without code)
Think of encapsulation like a **capsule** — data is stored inside, and users can only interact with it through specific, safe openings.  
You control **what goes in** and **what comes out**.

---

## Summary
| Concept | Description |
|----------|-------------|
| **Definition** | Separating data from direct access and controlling it via getters and setters. |
| **Goal** | To protect and validate data before use. |
| **Implementation** | Private attributes + public getters/setters or properties. |
| **Result** | Data integrity, control, and flexible system design. |

---

## In Short
Encapsulation allows you to **change internal logic** freely **without breaking** the external behavior of your program.  
It’s one of the most important principles that keeps code **secure, maintainable, and reliable**.
---
# 4. Properties in C#

## Definition
A **Property** in C# is a special member that provides a **flexible way to read, write, or compute the value** of a private field.  
It acts as a **bridge** between private data (attributes) and the outside world, combining **encapsulation** with **ease of use**.

---

## Types of Properties

### 1. Full Property
A **Full Property** has both:
- A private **attribute (backing field)**.
- A public **property** that provides `get` and `set` accessors.

You can write **custom logic** inside the `getter` and `setter` to validate or process data before reading or writing it.

**Use Case:**  
When you need to perform additional logic inside the property (e.g., validation, calculations, conditions).

---

### 2. Automatic Property
An **Automatic Property** is a simplified form of property where:
- You don’t explicitly declare a private attribute.
- The **compiler automatically creates a hidden backing field** to store the value.

You cannot write custom logic inside the `get` or `set` because the compiler handles the storage automatically.

**Use Case:**  
When you just need to store and access a value without adding any extra logic.

---

### 3. Indexer
An **Indexer** allows an object to be accessed using an **index**, similar to how elements are accessed in an array or list.  
It gives the object an index-like behavior by using `this[]`.

**Use Case:**  
When you want your object to hold a collection of values that can be accessed by index.

---

## Naming Conventions
- **Properties** → Written in **PascalCase** (e.g., `Name`, `Age`, `Salary`).  
- **Attributes (Fields)** → Written in **camelCase** (e.g., `name`, `age`, `salary`).

---

## Access Rules
- Use a **Property** when accessing data **from outside the class**.  
- Use an **Attribute** (field) when working **inside the same class**.

---

## Choosing Between Property Types
| Property Type | When to Use | Notes |
|----------------|-------------|-------|
| **Full Property** | When you need logic inside `get` or `set` | Example: data validation, logging, or conditional assignment |
| **Automatic Property** | When no custom logic is needed | Simple and concise syntax |
| **Indexer** | When you want objects to be accessed like arrays | Enables index-based access |

---

## Additional Notes
- If a property contains only a `get` accessor and no `set`, it is considered **read-only**.  
- Properties are generally **preferred** over traditional `getter` and `setter` methods because they are **easier to use**, **more readable**, and **integrate better** with C# language features.  
- Properties maintain **encapsulation** while keeping syntax **clean and intuitive**.

---

## Summary
| Concept | Description |
|----------|-------------|
| **Property** | A member that controls access to private data (read/write). |
| **Full Property** | Has logic inside `get` and `set`. |
| **Automatic Property** | Simplified form; compiler handles storage. |
| **Indexer** | Allows objects to be accessed using an index. |
| **Read-Only Property** | Has only a `get` accessor. |
| **Best Practice** | Use properties for external access and fields for internal class logic. |
---
# Examples 
```csharp
// -----------------------------
// 1. Struct Example
// -----------------------------
using System;

struct Point
{
    public int X;
    public int Y;

    // Custom Constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Print()
    {
        Console.WriteLine($"X: {X}, Y: {Y}");
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(10, 20);
        p1.Print();   // Output: X: 10, Y: 20
    }
}
```

```csharp 
// -----------------------------
// 2. OOP Definition Example
// -----------------------------
using System;

// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating...");
    }
}

// Derived class (Inheritance)
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Barking...");
    }
}

class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();   // Inherited behavior
        dog.Bark();  // Dog-specific behavior
    }
}
```

```csharp
// -----------------------------
// 3. Encapsulation Example
// -----------------------------
using System;

class Person
{
    // Private attribute (hidden)
    private int age;

    // Property for controlled access
    public int Age
    {
        get { return age; }
        set
        {
            // Data validation
            if (value >= 0 && value <= 120)
                age = value;
            else
                Console.WriteLine("Invalid age!");
        }
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person();
        p.Age = 25;           // Valid
        Console.WriteLine(p.Age);

        p.Age = -5;           // Invalid
    }
}
```

```csharp
// -----------------------------
// 4. Properties Example
// -----------------------------
using System;

class Employee
{
    // 1. Full Property
    private double salary;
    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
                salary = value;
            else
                Console.WriteLine("Salary cannot be negative!");
        }
    }

    // 2. Automatic Property
    public string Name { get; set; }

    // 3. Read-Only Property
    public string Department { get; } = "IT";

    // 4. Indexer
    private string[] skills = new string[3];
    public string this[int index]
    {
        get { return skills[index]; }
        set { skills[index] = value; }
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.Name = "Ahmed";
        emp.Salary = 5000;

        emp[0] = "C#";
        emp[1] = "SQL";
        emp[2] = "OOP";

        Console.WriteLine($"Name: {emp.Name}");
        Console.WriteLine($"Department: {emp.Department}");
        Console.WriteLine($"Salary: {emp.Salary}");
        Console.WriteLine($"Skill[1]: {emp[1]}");
    }
}
```
