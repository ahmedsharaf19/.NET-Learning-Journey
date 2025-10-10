# C# Course – Session 1

## Agenda

1. Programming Paradigm
2. Pre .NET Framework
3. .NET Framework
4. .NET Code Run Life Cycle
5. .NET & C# Version
6. Solution, Namespace, Project

---

## 1. Programming Paradigm

The **paradigm** is a style or approach to programming.

There are three main types:

### 1. Linear / Sequential

Writing code line by line without any structure — no functions or code blocks. There was no concept of functions, so the code was written as **spaghetti code**, with everything mixed together and repeated multiple times.

### 2. Structural / Functional

This approach started to organize the code better and reduce repetition. Two main concepts appeared: **Functions** and **Structs**.

Developers could now group blocks of code and call them from anywhere. However, the problem was that it was hard to **trace variables** and know which part of the code modified them.

### 3. Object-Oriented Programming (OOP)

This is a more organized approach where we divide the business entities into **units called classes**. Each class contains **methods** and **data**, meaning everything related is **encapsulated** in one place.

This allows developers to **control access** — defining who can interact with which part of the data or functionality.

---
## 2. C, C++ and C#
### C
At first, the **C language** appeared, which followed the **Structural / Functional Programming** paradigm.  
It was developed by **ANSI** in the 1980s and went through many versions and updates.

### C++

Known as **C with Objects**, it is **not a pure OOP** language because it doesn’t fully follow all OOP rules.  
It inherits some features from C, making it **backward compatible** — meaning it can use features or interfaces from older versions or other languages.

### COOL

This stands for **Classroom/Constraint Object-Oriented Language**.  
It was a **pure OOP** language but had **limited features and capabilities**.

### C#

C# is a **pure Object-Oriented Programming language** that applies all OOP principles completely.
---

## 3. Pre .NET

Before .NET, the process was that developers would write code and give it to the **compiler** to translate it into machine language (0s and 1s). However, this code depended heavily on the **platform** — meaning the operating system and hardware.

Each platform required **a separate compilation** from scratch, and sometimes even a completely different version of the code.

---

## 4. With .NET

Developers started asking: why not create something **cross-platform**, where you write code once and run it anywhere — independent of the platform?

That’s how **.NET** was created.

When you install the **SDK**, it includes two main components:

### 1. CLR (Common Language Runtime)

The CLR itself contains four main parts:

#### • CLS (Common Language Specification)

Responsible for converting a .NET program into a form that the CLR can understand.
This means you can write multiple **.NET languages** in the same file.

#### • CTS (Common Type Specification)

Converts all data types into a format the CLR can understand.

#### • GC (Garbage Collector)

Manages and cleans up memory automatically — it handles **memory management** and **deallocation**.

#### • JIT (Just-In-Time Compiler)

Converts the code into **native code** depending on the platform it’s running on.

### 2. FCL (Framework Class Library)

Contains libraries with built-in classes, interfaces, and data types used in the .NET Framework.

During the **runtime phase**, both the **CLR** and **FCL** work together to generate the executable file that runs the program.
---
## 5. Compilation Steps

In the **.NET** environment, the code doesn’t get compiled directly into native code.  
Instead, it first goes through a compilation process that produces an **intermediate file**.  

Then, the **JIT (Just-In-Time Compiler)** takes this intermediate file and translates it into **machine code** that matches the specific **platform** it’s running on.

---

### Intermediate File

The **intermediate file** has several names:
- **CIL (Common Intermediate Language)**
- **IL (Intermediate Language)**
- **MSIL (Microsoft Intermediate Language)**

It is saved with the **`.dll`** extension (**Dynamic Link Library**) and is a **managed file**, meaning it cannot be directly modified.

The **JIT** acts like a tiny operating system that converts this IL code into native code during execution.

---

### Compilation Flow

1. **C# code** → Compiled into **IL file**  
2. **JIT Compiler** → Converts IL into **machine code** based on the platform  

---

### Performance Note

Does this affect performance?  
The answer is **no**, because to overcome the overhead:
- The **JIT compiler (64-bit)** is now extremely fast.  
- **Jitting** happens **only the first time** a function is called. Subsequent calls run directly from the compiled machine code.
---
## 6. .NET and C# Versions

When installing the **SDK**, you need to know which **.NET version** and **C# version** it supports.

| .NET Version  | C# Version |
|----------------|-------------|
| .NET Core 1    | C# 6        |
| .NET Core 2    | C# 7        |
| .NET Core 3    | C# 8        |
| .NET 5         | C# 9        |
| .NET 6         | C# 10       |
| .NET 7         | C# 11       |
| .NET 8         | C# 12       |
| .NET 9         | C# 13       |

Each **.NET Core** version can work with the **C# version** released with it **and all previous versions**,  
but it **cannot** work with newer versions.
---
## 7. Project, Solution, and Namespace

### Project
A **Project** is the actual application you are building, such as:
- Desktop App  
- Web App  
- Console App  

---

### Solution
A **Solution** is a collection of one or more **Projects**.  
It can represent:
- Multiple projects for the **same client**, or  
- Different parts of the **same system** (for example, a web app and a desktop app together).  

Keeping them in one **Solution** helps manage and organize related projects easily.

---

### Namespace
A **Namespace** is used to organize code into logical groups.  
It allows you to group related classes, methods, and data together in one place.  

You can also have **multiple classes with the same name** as long as they belong to **different namespaces**.
