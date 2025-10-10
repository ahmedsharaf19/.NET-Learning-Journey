## Agenda
Topics covered in this lecture:
- **Polymorphism**  
- **Overloading**  
- **Overriding**  
- **Binding**
---

# 1. Polymorphism

**Definition:**  
Polymorphism means **"many forms"**.  
It allows the same method name or behavior to act in **different ways** depending on the context or the type of object calling it.

Polymorphism provides flexibility and reusability in object-oriented programming.

---

## Types of Polymorphism

### 1. Static Polymorphism (Compile-Time)
- Determined during the **compilation phase**.  
- **Faster**, since the method resolution happens early (before runtime).  
- Examples:
  - **Method Overloading**
  - **Method Hiding** using the `new` keyword.  

---

###  2. Dynamic Polymorphism (Run-Time)
- Determined during the **execution phase** (runtime).  
- **Slower**, since the method to be called is identified while the program is running.  
- Example:
  - **Method Overriding**

---

## Achieving Polymorphism
Polymorphism in C# can be achieved in two main ways:
1. **Overloading**
2. **Overriding**
---
# 2. Overloading

**Definition:**  
Method Overloading occurs when **multiple methods have the same name** but **different signatures**.  
The **compiler distinguishes** between them based on the **parameter list** — meaning the **number, order, and types** of parameters.

This concept improves **readability** and **maintainability**, as you can use the same method name for similar logic but with different data types or parameter combinations.

The most common example of method overloading is the built-in **`WriteLine()`** method.

---

## Operator Overloading

In C#, you can also overload **operators** to define custom behavior for user-defined types.

### ✅ Rules:
1. The operator must be one of the **allowed operators** in C#.  
2. The operator overloading method must be defined **inside the class** that uses it.  
3. You must follow the **correct syntax and rules** for operator overloading.

---

### 🧩 Syntax
```csharp
public static returnType operator Symbol(parameters)
{
    // Custom logic
}
```
### Notes on Specific Operators
- Unary operators automatically handle both prefix and postfix forms.
- Relational operators must be defined in pairs.
    For example:
        - If you overload ==, you must also overload !=.
---
## Casting Operator Overloading
You can overload casting operators to define how to convert between types, especially when dealing with user-defined types.
### 🧩 Syntax
```csharp
public static [explicit | implicit] operator targetType(parameters)
{
    // Conversion logic
}
```
---
# ⚠️ Notes
- If you implement implicit, the explicit version is not automatically created.
- However, if you implement explicit, you often add implicit only when it's truly needed.
- In practice, it’s better to use explicit unless the conversion is guaranteed to be safe.
---

## Models and ViewModels in C#

- When working with databases:
    - Each table in the database is represented as a Class, called a Model.
    - The Model represents the actual data structure (attributes only, no behavior).
    - A ViewModel represents the data to be displayed, and may contain a subset or combination of data from multiple models.
- This separation helps maintain clean architecture and easier data handling.
---
# 3. Overriding

**Definition:**  
Method **Overriding** requires **Inheritance**.  
It allows a derived class to **modify or completely replace** a behavior that it inherited from its base class.

Overriding enables **Dynamic Polymorphism**, meaning the method that gets executed depends on the **object type**, not the reference type.

---

## 🔹 `override` Keyword

When a method in the base class is marked as **`virtual`**, it can be **overridden** in the derived class using the **`override`** keyword.

This lets you **change or extend** the behavior of an inherited method.

### Key Points:
- The base class method **must** be marked as `virtual` (or `abstract`).  
- The derived class method **must** use the `override` keyword.  
- Determined at **runtime** → **Dynamic Polymorphism**.

---

## 🔹 `new` Keyword (Method Hiding)

If you use the **`new`** keyword, you’re not overriding — you’re **hiding** the base method.  
This means you **stop the inheritance chain** for that specific method and create a **new, unrelated version** in the derived class.

This is considered **Static Polymorphism**, as the method that gets called depends on the **reference type**, not the object type.

### Key Points:
- Hides the base method instead of overriding it.  
- Determined at **compile time** → **Static Polymorphism**.  
- The compiler assumes `new` is used **implicitly** if you define a method with the same name but without `override`.

---

## 🔹 Summary of Behavior

| Keyword      | Type of Polymorphism | Determined By         | Description |
|---------------|----------------------|------------------------|--------------|
| `new`         | Static               | Reference Type         | Creates a new method that hides the base one. |
| `override`    | Dynamic              | Object Type            | Changes the behavior of the inherited method. |
| *(none)*      | Static (default)     | Reference Type         | Treated as if it used `new` implicitly. |

---

## 🔹 Additional Notes
- **Non-virtual methods** exhibit **Static Polymorphism** (resolved at compile time).  
- **Virtual methods** exhibit **Dynamic Polymorphism** (resolved at runtime).  
- In **Static Polymorphism**, the method called depends on the **reference type**.  
- In **Dynamic Polymorphism**, the method called depends on the **actual object type**.
---
# 4. Binding

**Definition:**  
*Binding* refers to the process of determining **which method or member** a reference will call —  
in other words, deciding **the link between a reference (caller)** and **the actual object** it points to.

It’s essentially about how the compiler or runtime **“binds”** the reference to the correct method implementation.

In C#, this often happens when a **reference of a parent class** points to an **object of a child class** —  
and the system must decide **which version** of the method to execute.

---

## 🔹 1. Static Binding (Compile-Time Binding / Early Binding)

- The method call is **resolved during compilation**.  
- It’s called **early binding** because the decision happens **before execution**.  
- This makes it **faster** than dynamic binding.  
- Example: **Method Hiding** using the `new` keyword.  

**Key Points:**
- Happens at **compile time**.  
- Depends on the **reference type**.  
- Used in **Static Polymorphism**.  
- Example scenario: calling a hidden method with `new`.

---

## 🔹 2. Dynamic Binding (Run-Time Binding / Late Binding)

- The method call is **resolved during runtime**.  
- It’s called **late binding** because the decision happens **while the program is running**.  
- This makes it **slower** but more **flexible** and **powerful**.  
- Example: **Method Overriding** using the `override` keyword.

**Key Points:**
- Happens at **runtime**.  
- Depends on the **actual object type** (not the reference type).  
- Used in **Dynamic Polymorphism**.  
- Example scenario: overriding a virtual method.

---

## 🔹 Summary Table

| Type of Binding | Also Known As       | Determined At  | Depends On        | Example             | Performance |
|------------------|--------------------|----------------|-------------------|---------------------|--------------|
| **Static Binding** | Early / Compile-Time | Compilation    | Reference Type    | `new` keyword (method hiding) | Faster |
| **Dynamic Binding** | Late / Run-Time      | Execution Time | Object Type       | `override` keyword (method overriding) | Slower |
---
