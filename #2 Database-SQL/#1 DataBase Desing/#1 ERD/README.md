# 1. File-Based System

A **File-Based System** is the process of storing data in simple text files. There are two common types:

- **Delimited File** → Data is stored and separated by a specific delimiter (e.g., comma, semicolon).  
- **Fixed-Width File** → Data is stored using fixed column widths and separated only by spacing.

---

## ❌ Disadvantages of File-Based Systems

1. **Data Duplication (Redundancy)**  
   - The same data may exist in multiple files, leading to inconsistency.

2. **No Data Sharing**  
   - Each user works with their own copy of the file.  
   - Changes made by one user are not reflected for others.

3. **Inefficient Search**  
   - Searching is done linearly, making it slow for large files.

4. **No Constraints**  
   - No way to enforce rules on data type, format, or structure.

5. **No Standardization**  
   - No metadata or unified schema to describe how data is structured.

6. **Program–Data Dependence**  
   - Applications rely directly on the stored values rather than metadata, making maintenance harder.

7. **Lack of Security**  
   - No **authentication** or **authorization**.  
   - Anyone with the file can access or modify it without restrictions.

8. **Manual Backup**  
   - Backup must be performed manually, which risks being forgotten.

9. **No Relationships Between Files**  
   - Files are isolated with no support for relational links.

---

# 2. Database System

A **Database System** is a structured collection of objects.  
The most common representation is the **table**, which consists of **columns** (with names and data types) and **rows** (the actual data).  

For a database to be considered well-designed:  
1. It should minimize **data redundancy** (avoid unnecessary duplication).  
2. It should avoid **NULL values**, unless they are logically justified.  

The **Metadata** describes the database objects — including table names, column names, data types, and constraints.

---

## ✅ Advantages of Database Systems

1. **Standardization with Metadata**  
   - Provides a unified schema that defines how data is structured.

2. **Data Sharing**  
   - Multiple users and applications can access the same data resource concurrently.

3. **Enforcing Integrity Constraints**  
   - Rules can be applied on data (e.g., type, range, uniqueness) to ensure consistency.

4. **Restricting Unauthorized Access**  
   - Authentication and authorization mechanisms control who can access or modify data.

5. **Backup and Recovery**  
   - Automated processes (tasks or jobs) ensure data is regularly backed up and can be restored.

6. **Minimal Data Redundancy**  
   - Reduces duplication of data across the system.

7. **Program–Data Independence**  
   - Applications depend on **metadata** rather than hard-coded values, simplifying maintenance.

---

## ❌ Disadvantages of Database Systems

1. **Requires Expertise**  
   - Using and managing a DBMS demands specialized knowledge.

2. **High Cost of DBMS**  
   - Licensed database systems are often expensive.

3. **Compatibility Issues**  
   - A DBMS may not be directly compatible with another DBMS.  
   - Migration often requires exporting to an intermediate format (e.g., XML) before importing into the target system.

---

## 🗂️ Types of Databases

1. **Traditional Database**  
   - Data is stored on the hard disk.  
   - Access requires a **trip** from disk → RAM → application.  
   - Best suited for long-term storage and persistence.

2. **In-Memory Database**  
   - Data is stored directly in **RAM**, making access extremely fast.  
   - ⚠️ RAM is **volatile** → data can be lost if power is cut.  
   - Use cases:  
     - Temporary data storage.  
     - **Caching**, to avoid repeated trips between disk and memory.

---

# 3. Database Life Cycle

The **Database Life Cycle (DBLC)** defines the stages involved in designing, implementing, and using a database.  
Each stage is performed by specific roles within the software development process.

---

## 🔄 Stages of DBLC

1. **Analysis** → *System Analyst*  
   - Gathers requirements from stakeholders.  
   - Produces a **Requirements Document** that describes what data needs to be stored and managed.

2. **Database Design** → *Database Designer*  
   - Translates requirements into an **Entity–Relationship Diagram (ERD)**.  
   - The ERD provides a high-level conceptual model of the database.

3. **Database Mapping** → *Database Designer*  
   - Converts the ERD into a **Schema**.  
   - The schema defines tables, columns, data types, and relationships to be implemented.

4. **Database Implementation** → *Database Developer*  
   - Builds the **Physical Database** using a DBMS (tables, constraints, indexes, relationships).

5. **Application Development** → *Application Programmer*  
   - Creates the **application layer** (Web, Mobile, or Desktop) that interacts with the database.

6. **Client (End User)** → *User*  
   - Interacts with the database **indirectly** through the application interface.

---

## ℹ️ Additional Notes

- If a company does not have a dedicated **Database Team**, the roles of **Database Designer** and **Database Developer** are usually handled by the **Backend Developer**.  
- The **ERD** is directly derived from the Requirements Document and provides a bridge between business requirements and technical design.  
- From one Requirements Document, multiple ERDs may be created.  
- However, **only one Schema** is ultimately derived from the ERD to represent the actual physical structure of the database.

---

# 4. Database Users & Roles

In the context of databases, a **User** refers to a **position** within a company (a job title).  
A **Role** refers to a **duty or task** that someone may perform, even if it is not their main position.

---

## 👤 Types of Database Users and Roles

1. **Database Administrator (DBA)**  
   - **User (Production Stage):**  
     - Responsible for managing the database after deployment.  
     - Tasks: monitoring, security, backup, tuning.  
   - **Role (Development Stage):**  
     - Can be performed by a backend developer.  
     - Tasks: creating databases, granting permissions, writing queries.

2. **System Analyst** → *User*  
   - Works with clients to gather and analyze business requirements.

3. **Database Designer**  
   - *User* if there is a dedicated Database Team.  
   - *Role* if there is no DB Team (handled by backend developers).  
   - Responsible for ERDs and schema design.

4. **Database Developer**  
   - *User* if there is a dedicated Database Team.  
   - *Role* if there is no DB Team (handled by backend developers).  
   - Implements the physical database and optimizes queries.

5. **Application Programmers** → *User*  
   - Build applications (Web, Mobile, Desktop) that interact with the database.

6. **BI & Big Data Specialist (Data Scientist)** → *User*  
   - Works with large datasets, analytics, and reporting.  
   - Uses database systems for insights and decision-making.

7. **End User** → *User*  
   - Interacts with the database **indirectly** through applications.  
   - Considered a user even if not an employee, because they consume database resources via the app.

---
# 5. Entity–Relationship Diagram (ERD) Concept

At this stage, the **Requirements Document** is transformed into a **visual model** that helps understand the business domain.  
The ERD consists of three main components:  

1. **Entity** → Represents an object about which we need to store data. (Drawn as a rectangle)  
2. **Attributes** → Represent properties of entities. (Drawn as ellipses)  
3. **Relationship** → Represents links between entities. (Drawn as a diamond)  

---

## 🟦 1. Entities

- **Strong Entity**  
  - Has a **Primary Key**.  
  - Its existence does not depend on another entity.  

- **Weak Entity**  
  - Has a **Partial Key**.  
  - Its existence depends on a strong entity.  
  - If the strong entity is deleted, the weak entity is also removed.  

+-------------------+ +------------------+
| Strong Entity |<---->| Weak Entity |
| (PK present) | | (Partial Key) |
+-------------------+ +------------------+


---

## 🟢 2. Attributes

- **Simple Attribute**  
  - Cannot be divided further.  

- **Composite Attribute**  
  - Can be broken down into smaller components.  
(Name)
|
+--- (First Name)
+--- (Last Name)


- **Multi-Valued Attribute**  
- Can hold multiple values for the same entity instance.  
- Represented by **double ellipse**.  
((Phone Numbers))

- **Derived Attribute**  
- Value can be calculated at runtime.  
- Represented by **dashed ellipse**.  
(Age) ----> Derived from (Date of Birth)


- **Complex Attribute**  
- Combination of **Multi-Valued** + **Composite**.  
- Example: Multiple addresses, each containing street, city, and country.

---

## 🔶 3. Relationships
Relationships describe how entities are connected in the ERD.  
Each relationship has three main properties:

---

### 1. Degree of Relationships
Defines how many entities are involved in the relationship:
- **Unary (Recursive Relationship):** Relationship between two instances of the same entity.  
- **Binary Relationship:** Relationship between two different entities.  
- **Ternary Relationship:** Relationship involving three different entities.  

---

### 2. Cardinality Constraint
Specifies how many instances of one entity can be associated with instances of another:
- **1 : 1 (One-to-One):** Each instance in one entity relates to only one instance in another.  
- **1 : M (One-to-Many):** One instance in an entity relates to multiple instances in another.  
- **M : M (Many-to-Many):** Multiple instances in one entity relate to multiple instances in another.  

---

### 3. Participation Constraint
Defines whether an entity’s participation in a relationship is mandatory or optional:
- **Mandatory (Total Participation):** Every instance in the entity must participate in the relationship (usually represented by double lines).  
- **Optional (Partial Participation):** Not every instance in the entity is required to participate (usually represented by a single line).  

---
# 6. Keys

A **Key** in a database is an attribute (or a set of attributes) used to uniquely identify records, or to define relationships between tables.  

---

## 6. 🗝️ Types of Keys

1. **Candidate Key**  
   - Minimal set of attributes that can uniquely identify a record in a table.  
   - Example: `{NationalID}`, `{Email}`.  
   - A table may have multiple candidate keys.  
   - **Conceptual only** (helps choose the PK).  

2. **Primary Key (PK)**  
   - The chosen candidate key to uniquely identify each record.  
   - Must be **unique** and **NOT NULL**.  
   - Only one PK per table.  
   - **Exists physically in DB** (enforced by DBMS).  

3. **Alternate Key**  
   - Candidate keys that were **not chosen** as the primary key.  
   - Example: If PK = `{NationalID}`, then `{Email}` becomes an alternate key.  
   - **Conceptual only**.  

4. **Foreign Key (FK)**  
   - An attribute in one table that refers to the **Primary Key** in another table.  
   - Enforces referential integrity.  
   - **Exists physically in DB**.  

5. **Composite Key**  
   - A key formed by combining **two or more attributes** to uniquely identify a record.  
   - Example: `{StudentID, CourseID}` in an `Enrollment` table.  
   - Can act as a **Primary Key**.  
   - **Exists physically in DB** (if chosen).  

6. **Partial Key**  
   - An attribute that can uniquely identify a weak entity **only when combined** with its strong entity’s key.  
   - Example: `DependentName` with `EmployeeID` in a dependent–employee relationship.  
   - **Conceptual only** (used in ERD for weak entities).  

7. **Super Key**  
   - Any set of attributes that can uniquely identify a record (may include extra attributes).  
   - Example: `{NationalID, Name}` is still unique but not minimal.  
   - **Conceptual only**.  

---

## 📌 Summary Table

| Key Type       | Definition | Exists in DB? |
|----------------|------------|----------------|
| Candidate Key  | Minimal unique identifier | ❌ Conceptual only |
| Primary Key    | Chosen unique identifier (NOT NULL) | ✅ Yes |
| Alternate Key  | Candidate keys not chosen as PK | ❌ Conceptual only |
| Foreign Key    | Refers to PK in another table | ✅ Yes |
| Composite Key  | Key with 2+ attributes | ✅ Yes (if used) |
| Partial Key    | Uniquely identifies weak entity with strong entity’s PK | ❌ Conceptual only |
| Super Key      | Any attribute set that uniquely identifies | ❌ Conceptual only |
