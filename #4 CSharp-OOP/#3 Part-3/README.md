## Agenda
Topics covered in this lecture:
- **Class**  
- **Class Vs Struct**  
- **Inheritance**  
- **Access Modifiers**
- **Relationship Between Classes**
---
# 1. Class in C#

## Definition
A **Class** in C# is a **blueprint** used to create **objects**.  
It defines the **structure** and **behavior** of objects through **fields**, **methods**, **properties**, and **events**.

---

## Key Concepts

### 1. Reference Type
- A **class** is a **reference type** in C#.  
- When you create an object, the **reference (variable name)** is stored in the **stack**, while the **actual object (instance)** is stored in the **heap**.  
- The reference variable in the stack **points to** the object in the heap.

### 2. Declaration
When declaring a class reference:
```csharp
ClassName RefName;
```
```typescript
- `RefName` is stored in the **stack**.  
- It can reference any object of type `ClassName` or any class that **inherits** from it.
```
When creating an instance:
```csharp
new ClassName();
```
- The **instance** is created in the **heap**, and the **reference** in the stack points to it.

---

## Members of a Class
A class can contain:
1. **Fields (Attributes)** – Variables that hold data.  
2. **Methods** – Define behaviors or actions.  
3. **Properties** – Provide controlled access to private data.  
4. **Events** – Used to handle and respond to actions.

Each member can have **any access modifier** (`public`, `private`, `protected`, `internal`, etc.).

---

## Constructor in Classes

### 1. Default (Empty) Constructor
- The **compiler automatically provides** an empty constructor if you don’t define one yourself.  
- This default constructor contains **no code** and simply initializes attributes with **default values**.

### 2. User-Defined Constructor
- Once you define your own constructor, the compiler **stops creating the default one**.  
- Default values for attributes and properties are assigned **implicitly** when the object is created.

---

## Constructor Overloading
- You can create **multiple constructors** within the same class.  
- All constructors must have the **same name** (the class name) but **different parameter lists** (in number, type, or order).  
- This is known as **constructor overloading** and is an example of **compile-time polymorphism**.

---

## Constructor Chaining
**Constructor chaining** is the process of calling one constructor from another to avoid repeating initialization code.

There are two main cases:

1. **Using `this()`** → Calls another constructor **within the same class**.  
2. **Using `base()`** → Calls a constructor from the **base (parent) class**.

When an object is created:
- The **base class constructor** runs **first**.  
- Then the **derived class constructor** runs.  
- Constructor calls execute **from the top (base)** to **bottom (derived)**.

Example flow (conceptually):
- Derived() → calls base()
- Execution Order: Base Constructor → Derived Constructor

---
# 2. Class vs Struct in C#

## Overview
Both **Class** and **Struct** are used to define **custom data types**,  
but they differ fundamentally in how they store data, manage memory, and behave during execution.

---

## Key Differences

| Feature | **Class** | **Struct** |
|----------|------------|-------------|
| **Type** | Reference Type | Value Type |
| **Default Value** | `null` | `0`, `false`, or type default |
| **Storage** | Reference stored in **Stack**, instance stored in **Heap** | Entire instance stored in **Stack** |
| **Nullability** | Can be `null` | Cannot be `null` (unless `Nullable<struct>`), but not recommended |
| **Memory Management** | Managed by **Garbage Collector** | Automatically managed (no garbage collection) |
| **Inheritance** | Supports inheritance | Does **not** support inheritance |
| **Constructors** | Compiler provides an **empty constructor** only if none is defined | Compiler **always** provides a parameterless constructor |
| **Immutability** | Typically used for **large, mutable** objects | Typically used for **small, lightweight** objects |
| **Performance** | Has **heap allocation overhead** | Faster, avoids heap allocation and GC overhead |

---

## Class Details
- A **Class** is a **reference type**; it stores a reference to data in the heap.  
- The reference itself lives in the **stack**, pointing to the **instance** in the **heap**.  
- If not initialized, its default value is `null`.  
- Objects are cleaned up by the **Garbage Collector** when no longer referenced.

### When to Use a Class
Use a **Class** when:
- You need **inheritance** (OOP hierarchy).  
- You need **nullability**.  
- The object is **large** and **frequently modified**.  
- You want an object with a **long lifetime** in memory.

---

## Struct Details
- A **Struct** is a **value type**; it stores data **directly** in the **stack**.  
- Each struct instance holds its own copy of the data.  
- The default values are the type defaults (`0`, `false`, etc.).  
- Does **not** support inheritance.  
- The **compiler always provides** a parameterless constructor, whether or not you define one.

### When to Use a Struct
Use a **Struct** when:
- You need a **small, lightweight object**.  
- You don’t need inheritance.  
- You won’t modify the object frequently after creation.  
- You want to **avoid heap allocation** and **Garbage Collector overhead**.

---

## Summary Table

| Aspect | **Class** | **Struct** |
|:--|:--|:--|
| **Type** | Reference Type | Value Type |
| **Stored In** | Heap (instance) | Stack |
| **Default Value** | `null` | Type default (`0`, `false`, etc.) |
| **Inheritance** | Supported | Not supported |
| **Null Allowed** | Yes | No (except `Nullable<T>`) |
| **Garbage Collection** | Required | Not required |
| **Performance** | Slower (heap allocation) | Faster (stack allocation) |
| **Ideal Use Case** | Large, complex, long-lived objects | Small, simple, short-lived data structures |

---

## In Short
- **Class** → Heavyweight, reference type, supports inheritance, uses heap memory, managed by GC.  
- **Struct** → Lightweight, value type, no inheritance, uses stack memory, automatically managed.  
Use **Class** for complex entities, and **Struct** for small, fast, short-lived data.
---
# Memory Management in C#

Understanding how **memory** works is crucial to knowing the difference between **Class** and **Struct**,  
since they store and manage data in different memory regions: the **Stack** and the **Heap**.

---

## Memory Regions Overview

C# primarily uses **two memory regions**:

1. **Stack**
2. **Heap**

Each serves a specific purpose in storing data and managing program execution.

---

## 1. Stack

### Purpose
The **stack** is used to store:
- **Local variables**
- **Method call frames** (function call contexts)
- **Value types** like `int`, `bool`, or `struct`

The name **“stack”** comes from the **Stack Data Structure**, which follows the **LIFO (Last In, First Out)** principle —  
the last element added is the first one removed.

---

### Characteristics

| Feature | Description |
|----------|-------------|
| **Access Pattern** | LIFO (Last In, First Out) |
| **Speed** | Very **fast** to allocate and deallocate |
| **Size** | **Fixed size** determined at program start |
| **Allocation** | Handled automatically with each method call |
| **Lifetime** | Variables are destroyed automatically when a method ends |

---

### Advantages
- ⚡ **Extremely fast** memory allocation and deallocation.  
- 📌 **Predictable behavior** due to fixed size and stack pointer tracking.  
- 🧠 **No need for garbage collection** — memory is automatically freed when the function exits.

### Disadvantages
- ❌ **Limited size** — stack memory is fixed and small.  
- ⚠️ **Stack Overflow** error may occur if too many nested calls or large local variables exist.

---

## 2. Heap

### Purpose
The **heap** stores **objects and reference types** (instances created using the `new` keyword).  
Unlike the stack, the heap is **not organized** sequentially.

The term “heap” refers to a **random memory region** — data isn’t stored in a strict order,  
allowing **random access** instead of sequential access.

---

### Characteristics

| Feature | Description |
|----------|-------------|
| **Storage** | Used for **reference types** (e.g., classes, arrays, strings) |
| **Organization** | **Unordered (random access)** |
| **Size** | **Dynamic**, can grow at runtime as long as memory is available |
| **Managed By** | **Garbage Collector (GC)** |
| **Lifetime** | Exists until GC frees unused objects |

---

### Advantages
- ✅ **Flexible size** — can dynamically grow during program execution.  
- 🧩 Suitable for **complex, long-lived objects**.

### Disadvantages
- 🐢 **Slower allocation and deallocation** compared to the stack.  
- 🧹 Requires **Garbage Collector**, which introduces overhead to monitor and clean up unused objects.

---

## How `new` Works
When you use the `new` keyword:
- C# **allocates the required bytes** for the object **in the heap**.  
- A **reference** (pointer) to that memory location is stored **in the stack**.

So:
- **Heap:** Holds the **actual object**.  
- **Stack:** Holds a **reference** pointing to it.

---

## Summary Table

| Aspect | **Stack** | **Heap** |
|:--|:--|:--|
| **Used For** | Local variables, method frames, value types | Objects, reference types |
| **Access Pattern** | LIFO | Random |
| **Speed** | Very fast | Slower |
| **Size** | Fixed | Dynamic |
| **Lifetime** | Ends when function exits | Managed by Garbage Collector |
| **GC Required** | No | Yes |
| **Typical Error** | Stack Overflow | Memory Fragmentation / GC pauses |
| **Best For** | Small, short-lived data | Large, complex, long-lived objects |

---

## In Short
- **Stack** = Fast, fixed-size, automatically managed.  
  → Used for **temporary, small data**.  
- **Heap** = Flexible, slower, managed by **Garbage Collector**.  
  → Used for **large, complex, long-lived objects**.

Together, they form the foundation of **memory management in C#** — balancing performance and flexibility.
---
# 3. Inheritance in C#

## Definition
**Inheritance** is an Object-Oriented Programming (OOP) concept that allows one **class (child/derived)**  
to **inherit attributes and methods** from another **class (parent/base)**.

It enables classes to **reuse existing code**, **extend functionality**, and **avoid redundancy**.

---

## Why Use Inheritance?

### 1. Avoid Code Duplication
- Shared functionality is written once in the **base class**.  
- Changes or fixes are made in **one place only**.

### 2. Code Reuse
- Derived classes can **reuse and extend** the code of the base class.  
- Promotes **cleaner, maintainable**, and **modular** design.

---

## Types of Inheritance in C#

| Type | Description | Example Structure |
|-------|--------------|------------------|
| **Single (Simple) Inheritance** | One class inherits from one base class. | `Child → Parent` |
| **Multilevel Inheritance** | A class inherits from another derived class (a chain of inheritance). | `Grandchild → Child → Parent` |
| **Hierarchical Inheritance** | Multiple classes inherit from the same base class. | `Child1, Child2 → Parent` |

---

## Not Supported: Multiple Inheritance
C# **does not support multiple inheritance** —  
a class **cannot inherit from more than one base class**.

### Why?
Because if two parent classes have members with the same name,  
the compiler wouldn’t know **which one to use**, leading to ambiguity.

---

## The Alternative: Interfaces
To achieve behavior similar to multiple inheritance,  
C# provides **interfaces**, which allow a class to **implement multiple contracts** safely  
without ambiguity or shared data.

---

## Method Overriding vs Hiding

### 1. Overriding
- A derived class can **override** a method from its base class to **change its behavior**.  
- The base method must be marked as **`virtual`**, and the derived method as **`override`**.

### 2. Hiding (Using `new`)
- If a derived class defines a method with the **same name** as one in the base class,  
  and marks it with the **`new` keyword**, it **hides** the base method instead of overriding it.  
- This **breaks the inheritance chain** — the derived class creates a **new, independent method**.

---

## Summary

| Concept | Description |
|----------|-------------|
| **Definition** | Mechanism for one class to inherit members from another. |
| **Goal** | Code reuse and easier maintenance. |
| **Supported Types** | Single, Multilevel, Hierarchical. |
| **Not Supported** | Multiple inheritance (use interfaces instead). |
| **Override** | Replaces base class behavior (requires `virtual` keyword in base). |
| **new Keyword** | Hides base method; creates a new independent version. |

---

## In Short
- Inheritance connects classes in a **hierarchical relationship**.  
- The **base class** defines shared logic, while **derived classes** extend or modify it.  
- C# keeps inheritance **safe and predictable** by preventing multiple inheritance conflicts  
  and allowing controlled overriding through `virtual`, `override`, and `new` keywords.
---
# 4. Access Modifiers (Focus on `protected`)

## Overview
Access Modifiers in C# control **visibility and accessibility** of class members.  
The `protected` modifier in particular behaves differently depending on **whether inheritance exists** and **where it occurs** (same project or different project).

---

## Step 1: Ask — Is There Inheritance?

### ✅ Case 1: **No Inheritance**
If there’s **no inheritance**, the `protected` part of any modifier is **ignored (removed)** automatically.  
It behaves as if it’s replaced with the most restrictive applicable modifier.

| Modifier | Becomes (No Inheritance) |
|-----------|--------------------------|
| `private protected` | `private` |
| `protected` | `private` |
| `internal protected` | `internal` |

So, when there’s no inheritance, members behave just like normal **private or internal** members depending on the context.

---

### ✅ Case 2: **With Inheritance**
When inheritance exists, we ask an additional question:

> “Is the derived (child) class in the **same project** or in a **different project**?”

---

## Step 2: Same Project (Inheritance Within the Same Assembly)

| Modifier | Behavior in Child Class |
|-----------|-------------------------|
| `private` | ❌ Not inherited |
| `internal` | ✅ Inherited (accessible) |
| `public` | ✅ Inherited (accessible) |
| `protected` | ✅ Inherited → becomes accessible as `private` inside the derived class |
| `private protected` | ✅ Inherited → becomes `private` |
| `internal protected` | ✅ Inherited → becomes `internal` |

> In short: Inside the **same project**, `protected` members are inherited and accessible,  
> but they lose the “protected” part in the derived class.

---

## Step 3: Different Project (Inheritance Across Assemblies)

| Modifier | Behavior in Child Class (Different Project) |
|-----------|---------------------------------------------|
| `private` | ❌ Not inherited |
| `internal` | ❌ Not inherited (internal = same project only) |
| `public` | ✅ Inherited normally |
| `protected` | ✅ Inherited → becomes `private` in the derived class |
| `private protected` | ❌ Not inherited (too restricted) |
| `internal protected` | ✅ Inherited → becomes `private` |

> So, when inheritance happens **across projects**,  
> only members marked `protected`, `internal protected`, or `public` can cross boundaries.  
> But inside the derived class, they act as **private** (not visible to others).

---

## Step 4: Summary Logic

| Scenario | Modifier | Behavior |
|-----------|-----------|-----------|
| **No Inheritance** | `protected`, `private protected` | Acts as `private` |
| **No Inheritance** | `internal protected` | Acts as `internal` |
| **Inheritance (Same Project)** | `private protected` | Inherited as `private` |
|  | `internal protected` | Inherited as `internal` |
| **Inheritance (Different Project)** | `private protected` | ❌ Not inherited |
|  | `internal protected` | Inherited as `private` |
|  | `protected` | Inherited as `private` |
|  | `public` | Inherited normally |

---

## In Short
Think of `protected` as **“visible to children”**.  
But depending on where and how inheritance occurs:

- **No inheritance → behaves like private/internal.**  
- **Same project inheritance → accessible as private/internal.**  
- **Different project inheritance → only protected/public members survive, and they become private inside the derived class.**

---

### Quick Mental Model 💡
| Question | Yes | No |
|-----------|-----|----|
| Is there inheritance? | Check project boundary | Treated as private/internal |
| Is it the same project? | `protected` acts as internal/private | `protected` acts as private |
| Is it a different project? | Only `protected` and `public` survive | Everything else hidden |

---

## Summary
The `protected` family of modifiers allows **controlled inheritance visibility**.  
They let members be inherited by child classes but **not freely accessible** elsewhere.  
C# enforces this structure to maintain **encapsulation and safety** while still supporting **flexible code reuse**.
---
# 5. Relationship Between Classes in C#

## Overview
The relationship between classes defines **how objects interact** and **depend** on each other in an OOP system.  
These relationships describe **how classes collaborate** to achieve a specific goal.

There are three main types of relationships:
1. **Inheritance**  
2. **Association**  
3. **Composition & Aggregation**

---

## 1. Inheritance — *“is-a” Relationship*

**Definition:**  
Inheritance expresses an **“is-a”** relationship between two classes, where the **child class** is a **specialized version** of the **parent class**.

Example (Conceptually):  
> `Dog` **is an** `Animal`.

- The **child class (Dog)** inherits attributes and methods from the **base class (Animal)**.  
- Promotes **code reuse** and **hierarchical design**.

**Represents:** Strong relationship based on **shared behavior and characteristics**.  
**Keyword to remember:** → *is-a* relationship.

---

## 2. Association — *“uses-a” Relationship*

**Definition:**  
Association represents a **general connection or interaction** between two independent classes.  
Neither class fully owns the other; they simply **use** or **reference** each other.

**Represents:**  
The **cardinality** (relationship count) between two entities — similar to relationships in databases.

### Common Association Types
| Type | Description |
|------|--------------|
| **One-to-One** | One object is associated with one object of another class. |
| **One-to-Many** | One object can be linked to many objects of another class. |
| **Many-to-Many** | Multiple objects from each class are linked to each other. |

**Keyword to remember:** → *uses-a* relationship.

---

## 3. Aggregation — *“part-of but optional” Relationship*

**Definition:**  
Aggregation represents a **weak “part-of”** relationship.  
It means one class contains another, but the **contained object can exist independently**.

**Example (Conceptually):**  
> An `Employee` is **part of** a `Department`,  
> but the `Department` can still exist even if that `Employee` is removed.

**Key Idea:**  
- The **part** (Employee) can exist without the **whole** (Department).  
- It’s a **loose ownership** relationship.

**Keyword to remember:** → *has-a* / *part-of (optional)* relationship.

---

## 4. Composition — *“part-of and mandatory” Relationship*

**Definition:**  
Composition is a **strong “part-of”** relationship.  
The lifetime of the contained object **depends** on the container —  
if the container is destroyed, the part is destroyed too.

**Example (Conceptually):**  
> A `Room` **cannot exist without** an `Apartment`.  
> If the apartment is deleted, all its rooms are deleted.

**Key Idea:**  
- The **part** (Room) cannot exist independently of the **whole** (Apartment).  
- Represents **strong ownership** and **lifetime dependency**.

**Keyword to remember:** → *part-of (mandatory)* relationship.

---

## Summary Table

| Relationship Type | Description | Example | Dependency | Lifetime |
|-------------------|-------------|----------|-------------|-----------|
| **Inheritance** | One class derives from another (is-a). | `Dog → Animal` | Strong | Shared |
| **Association** | Classes interact (uses-a). | `Student → Course` | Weak | Independent |
| **Aggregation** | One class contains another (optional part-of). | `Department → Employee` | Moderate | Independent |
| **Composition** | One class owns another (mandatory part-of). | `Apartment → Room` | Strong | Dependent |

---

## In Short

| Type | Meaning | Example | Ownership |
|------|----------|----------|-----------|
| **Inheritance** | is-a | Dog → Animal | Inherits behavior |
| **Association** | uses-a | Student → Course | No ownership |
| **Aggregation** | part-of (optional) | Department → Employee | Weak ownership |
| **Composition** | part-of (mandatory) | Apartment → Room | Strong ownership |

---

## Summary
- **Inheritance:** Defines hierarchy and reusability (*is-a*).  
- **Association:** Defines cooperation between independent objects (*uses-a*).  
- **Aggregation:** Weak containment; the part can exist alone.  
- **Composition:** Strong containment; the part’s lifetime depends on the whole.  
Together, they describe **how objects and classes work together** in an OOP design.
