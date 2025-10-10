## Agenda
Topics covered in this lecture:
- **Interface**  
- **Shallow Copy and Deep Copy**  
- **Buit-in interface**  
---
# 1. Interface

**Definition:**  
An **Interface** acts as a **contract** between two parties —  
one defines the contract (the interface itself), and the other **implements** it.

An interface defines **what** should be done, but not **how** it should be done.

---

## 🔹 Members Inside an Interface
An interface can include:
1. **Property Signatures**  
2. **Method Signatures**  
3. **Default Implementations** *(optional in modern C#)*

---

## 🔹 Implementation Rules

When a class **implements** an interface:
- It must implement **all members** exactly as defined.  
- This includes the same:
  - **Access modifier**  
  - **Return type**  
  - **Name**  
  - **Parameters**

If a method or property signature is missing or mismatched, the compiler will throw an error.

---

## 🔹 Instantiation and Referencing

- You **cannot create an instance** of an interface directly,  
  because it contains **no complete implementation**.

- However, you **can create a reference** of an interface type  
  that **points to any class** that implements it.

  Example conceptually:
  > `IShape shape = new Circle();`

This allows flexibility in handling multiple types through a common interface.

---

## 🔹 Default Implementation

Modern C# (starting from C# 8) allows **default implementations** inside interfaces.  
These are methods with **a body**, providing a default behavior.

- A **reference of the interface** can access the default implementation.  
- A **reference of the implementing class** cannot access it directly.

---

## 🔹 Multiple Interface Implementation

A single class **can implement multiple interfaces** simultaneously.  
This enables **a form of multiple inheritance** for behavior definitions,  
without the ambiguity problems of class-based multiple inheritance.

---

**In summary:**
- Interfaces define **what to do**, not **how to do it**.  
- A class that implements an interface must provide **complete implementations**.  
- Interfaces promote **flexibility**, **abstraction**, and **loose coupling** in OOP design.
---
# 2. Shallow Copy & Deep Copy

**Concept Overview:**  
Think of copying objects in C# as copying **data** and **references**.  
The difference between *Shallow Copy* and *Deep Copy* lies in **how the referenced data** is handled.

---

## 🔹 Shallow Copy

- A **Shallow Copy** copies the **value of the variable directly**.  
- For **reference types**, it copies only the **reference (address)** — not the actual object.  
- This means both the original and the copied object **point to the same memory location**.  
- Any change to the object through one reference will **affect the other**.

**Key Idea:**  
> Works on **Identity (Address)** — not on the internal object data.

**Example Conceptually:**  
- If `A` references an object, and you make a shallow copy to `B`,  
  then `A` and `B` point to **the same object** in memory.

---

## 🔹 Deep Copy

- A **Deep Copy** creates a **completely new object** in memory.  
- It copies not only the reference, but also **the actual data (state)** of the object being referenced.  
- The copied object is **independent** of the original — changes in one do **not affect** the other.  
- Typically performed using the **`.Clone()`** method or **manual copying** of all fields and properties.

**Key Idea:**  
> Works on the **Object State (Instance)** — not just the reference.

---

## 🔹 Important Considerations

When working with object copying, always be aware of:
1. **Value Types vs Reference Types**  
   - Value types store data directly (stack).  
   - Reference types store addresses (heap).

2. **Mutable vs Immutable Objects**  
   - *Mutable*: can be modified after creation (e.g., List, custom objects).  
   - *Immutable*: cannot be modified once created (e.g., string, record).

Understanding these distinctions helps you determine **when to use shallow or deep copy**,  
and **how to avoid unintentional side effects** when copying objects.

---

**In Summary:**

| Copy Type     | What It Copies            | Memory Independence | Works On             | Common Method  |
|----------------|---------------------------|---------------------|----------------------|----------------|
| **Shallow Copy** | Variable’s reference (address) | ❌ No                | Identity (Address)   | MemberwiseClone |
| **Deep Copy**    | Full object and its data       | ✅ Yes               | Object State         | `.Clone()` or manual |
---
# 3. Built-in Interfaces in C#

Below is a list of common **built-in interfaces** in C#, along with **when and why** you should use each.

---

## 🔹 `IEnumerable<T>`

**Use it when:**  
You want your class or collection to **support iteration** (using `foreach`).  

**Purpose:**  
- The most basic collection interface.  
- Provides a way to **loop through elements sequentially**.  
- Returns an `IEnumerator<T>` to traverse the collection.

**Example Use Case:**  
Implement it in custom collections that can be iterated over.

---

## 🔹 `ICollection<T>`

**Use it when:**  
You need to represent a **collection of items** that supports **adding, removing, counting, and checking for existence**.

**Purpose:**  
- Extends `IEnumerable<T>`.  
- Adds features like `Add()`, `Remove()`, `Count`, and `Contains()`.

**Example Use Case:**  
Used for collections where you need to **modify the contents** (like a `List<T>`).

---

## 🔹 `IList<T>`

**Use it when:**  
You need an **indexed collection** that allows **random access** by index.

**Purpose:**  
- Extends `ICollection<T>`.  
- Adds indexing (`[ ]`) and methods like `Insert()` and `RemoveAt()`.

**Example Use Case:**  
Used for **ordered, mutable collections** like arrays or lists.

---

## 🔹 `IComparable<T>`

**Use it when:**  
You want your object to be **comparable** to another instance of the same type — usually for **sorting**.

**Purpose:**  
- Defines the `CompareTo()` method.  
- Returns a value:
  - `< 0` → less than  
  - `0` → equal  
  - `> 0` → greater than  

**Example Use Case:**  
Implement in classes when you want to use `Sort()` or comparisons like `<`, `>` on custom objects.

---

## 🔹 `IDisposable`

**Use it when:**  
Your object **uses unmanaged resources** (files, database connections, memory handles, etc.)  
and you need to **release them manually**.

**Purpose:**  
- Defines the `Dispose()` method.  
- Used with the `using` statement for **automatic cleanup**.

**Example Use Case:**  
Database connections, file streams, or any resource that must be explicitly released.

---

## 🔹 `ICloneable`

**Use it when:**  
You want to **create a copy (clone)** of an existing object.

**Purpose:**  
- Defines the `Clone()` method.  
- Returns a new object that is a **copy of the current instance**.

**Example Use Case:**  
Used to implement **Deep Copy** or **Shallow Copy** logic.

---

## 🔹 `IEqualityComparer<T>`

**Use it when:**  
You need to **compare two objects for equality** — often used in **collections** like dictionaries or hash sets.

**Purpose:**  
- Defines `Equals()` and `GetHashCode()`.  
- Provides custom logic for **equality comparison**.

**Example Use Case:**  
Comparing objects by specific properties instead of reference equality.

---

## 🔹 `IComparer<T>`

**Use it when:**  
You need to **customize sorting logic** outside of the class itself.

**Purpose:**  
- Defines `Compare(x, y)` method.  
- Similar to `IComparable<T>`, but implemented **externally** instead of inside the class.

**Example Use Case:**  
When sorting a list by different properties using custom comparison logic.

---

## 🔹 `IReadOnlyCollection<T>`

**Use it when:**  
You want to **expose a collection as read-only** —  
so users can **read data but not modify it**.

**Purpose:**  
- Extends `IEnumerable<T>`.  
- Provides the `Count` property but **no modification methods**.

**Example Use Case:**  
Used when you want to return data safely from a class without allowing changes.

---

## 🧭 Summary Table

| Interface | Purpose | Common Use Case |
|------------|----------|----------------|
| `IEnumerable<T>` | Iteration support | Enable `foreach` loops |
| `ICollection<T>` | Add/remove/count items | Manage basic collections |
| `IList<T>` | Indexed access | Work with ordered lists |
| `IComparable<T>` | Compare two objects | Enable sorting |
| `IDisposable` | Cleanup unmanaged resources | File/DB handling |
| `ICloneable` | Copy an object | Implement clone logic |
| `IEqualityComparer<T>` | Custom equality comparison | Dictionary/HashSet keys |
| `IComparer<T>` | External comparison logic | Custom sorting |
| `IReadOnlyCollection<T>` | Read-only collection | Safe data exposure |
