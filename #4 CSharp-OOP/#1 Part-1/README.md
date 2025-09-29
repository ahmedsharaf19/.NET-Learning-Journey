## Agenda
Topics covered in this lecture:
- **Class Library**  
- **User Defined Data Types**  
- **Access Modifiers**  
- **Enum**
---

## Class Library

A **Class Library** is a collection of **classes**, **interfaces**, and other data types that can be reused across multiple projects.  
It promotes **code reusability**, so you don’t have to rewrite the same functionality from scratch.

- A class library **does not execute on its own** and does not produce direct output.  
- It is **compiled only up to an intermediate file** (`.dll`), which can then be referenced and used by other applications.

---
## User Defined Data Types

This section explains what each user-defined data type can contain,  
the valid **access modifiers** for its members, and the **default** access level.

### 1. Namespace
- **Can Contain:** `struct`, `enum`, `class`, `interface`
- **Member Access Modifiers:** `internal` (default) or `public`
- **Namespace Access Modifier:** *None* (a namespace itself has no access modifier)

---

### 2. Class
- **Can Contain:** Attributes (fields), Functions (methods), Properties, Events
- **Member Access Modifiers:**  
  `private` (default), `private protected`, `protected`, `internal`, `protected internal`, `public`
- **Class Access Modifier:** `internal` (default) or `public`

---

### 3. Struct
- **Can Contain:** Same as a class (fields, methods, etc.)  
- **Member Access Modifiers:**  
  `private` (default), `internal`, `public`  
  *(No `protected` because structs don’t support inheritance.)*
- **Struct Access Modifier:** `internal` (default) or `public`

---
### 5. Interface

- **Can Contain:**  
  - **Signatures** of properties or functions  
  - **Default implementations** (C# 8.0+)
- **Member Access Modifiers:**  
  - For signatures only: no `private` allowed  
  - For members with a default implementation: any standard access modifier is allowed
- **Interface Access Modifier:** `internal` (default) or `public`
---

### 4. Enum
- **Can Contain:** Named constants representing integer values
- **Member Access Modifiers:** *None* (enum members don’t use access modifiers)
- **Enum Access Modifier:** `internal` (default) or `public`
---
## Access Modifiers

Key access levels in C# covered in this lecture:

### 1. `private`
- **Visibility:** Only within the scope (class/struct) where it is declared.
- **Usage:** Restricts access to the defining type only.

### 2. `internal`
- **Visibility:** Within the same **project/assembly** (any file in the same project).
- **Usage:** Useful when code should be shared across the project but hidden from external projects.

### 3. `public`
- **Visibility:** Accessible from the defining scope, the entire project, **and** other projects that reference this assembly.
- **Usage:** For members or types meant to be fully exposed.
---
## Enum

An **enum** is a special value data type that lets you create a variable
holding a set of named constants, each representing an underlying numeric value.

- By default, enumeration starts at **0** and increments by **1** for each subsequent member,
  unless you assign explicit values.
- The underlying data type is `int` by default, but you can specify another integral type.

### Syntax
```csharp
enum EnumName : DataType // DataType defaults to int
{
    Value1,
    Value2,
    Value3
}
```
- Flags Attribute
If you add the [Flags] attribute, the enum is treated as a bit field,
allowing bitwise combination of its values.
```csharp
[Flags]
enum EnumName : DataType // default int
{
    Value1,
    Value2,
    Value3
}
```
- Usage
```csharp
EnumName myValue = EnumName.Value1;
```
