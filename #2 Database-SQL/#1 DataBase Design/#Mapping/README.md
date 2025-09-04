# Database Mapping

Before mapping, let’s clarify some basic definitions:

- **Database** → A collection of tables.  
- **Table / Entity** → A collection of records.  
- **Attribute / Column / Field** → A characteristic of an entity.  
- **Row / Record / Tuple** → An instance of an entity.  

When creating a Database, we must design a **Schema** that contains all tables, their columns, and their relationships.  
This schema is built step by step using **mapping rules**:

---

## 1. Mapping of Regular Entity Types
Based on the **type of attributes**:
- **Simple Attribute** → Directly mapped as a column.  
- **Composite Attribute** → Decomposed into its components.  
- **Multi-Valued Attribute** → Create a new table;  
  - Add the PK of the original entity as an FK.  
  - The PK of this new table = (Original PK + Multi-valued attribute).  
- **Derived Attribute** → Not stored, ignored (can be calculated at runtime).  
- **Complex Attribute** (Composite + Multi-Valued) → Create a new table, add PK of the original entity as FK, decompose into components, and select a non-repeating composite key.  

---

## 2. Mapping of Weak Entity Types
- Create a separate table for the **Weak Entity**.  
- Add the **PK of the Strong Entity** as an **FK**.  
- The PK of the weak entity’s table = (Strong Entity PK + Partial Key).  

---

## 3. Mapping of Binary 1:1 Relationships
**Case 1: Both sides Mandatory**  
- Create one table that contains attributes of both entities.  
- Choose either entity’s PK as the table PK.  

**Case 2: One Mandatory, One Optional**  
- Place the PK of the **optional entity** as an FK in the **mandatory entity**.  
- Avoids NULL values.  

**Case 3: Both Optional**  
- Create a new table.  
- Add both PKs as FKs in the new table.  
- One (or both as composite) becomes the PK.  

---

## 4. Mapping of Binary 1:M Relationships
Focus on the **M-side**:  

**Case 1: M-side Mandatory**  
- Take the PK from the **1-side** and add it as an FK in the **M-side**.  

**Case 2: M-side Optional**  
- Create a new table.  
- Add both PKs from the two entities as FKs.  
- Choose the **PK of the M-side** as the PK of the new table.  

---

## 5. Mapping of Binary M:M Relationships
- Create a new table.  
- Add both PKs from the two entities as FKs.  
- Both FKs together = Composite PK of the new table.  

---

## 6. Mapping of N-ary Relationships
- Create a new table.  
- Add the PKs of all participating entities as FKs.  
- Include any attributes defined on the relationship.  
- PK of the new table = Composite of all FKs.  

---

## 7. Mapping of Unary (Recursive) Relationships
- Place the PK of the entity as an **FK** in the **same table** to represent the relationship.  

--- 
# Database Mapping - Ordered Steps

## 0. Mapping 1:1 Mandatory–Mandatory (Special Case)
- Create **one table** that contains attributes of both entities.  
- Choose either entity’s PK as the table PK.  

---

## 1. Mapping Regular Entities
- **Simple Attribute** → Column.  
- **Composite Attribute** → Split into sub-attributes.  
- **Multi-valued Attribute** → New table (Entity PK as FK + attribute, Composite PK).  
- **Derived Attribute** → Not stored (calculated at runtime).  
- **Complex Attribute** → New table, decompose into sub-attributes, Composite PK.  

---

## 2. Mapping Weak Entities
- Create a new table.  
- PK = (Strong Entity PK + Partial Key).  
- Store Strong Entity PK as FK.  

---

## 3. Mapping Relationships

### a) Binary 1:1
- **Mandatory–Optional** → Add PK of optional side as FK in mandatory side.  
- **Optional–Optional** → New table with both PKs as FKs (Composite PK).  

### b) Binary 1:M
- **M-side Mandatory** → Add PK of 1-side as FK in M-side.  
- **M-side Optional** → New table with both PKs as FKs, PK includes M-side PK.  

### c) Binary M:M
- Create new table.  
- PK = (PK1 + PK2).  

### d) N-ary
- Create new table.  
- PK = All participating PKs (Composite).  

### e) Unary (Recursive)
- Add entity’s PK as FK in the same table.  

---
## Important Notes

- Any **attribute on a relationship** is placed in the **relationship’s table**  
  (the one that contains the PKs and FKs).  

- The higher the **cardinality**, the **fewer cases** we have to handle:  
  - **1:1** → Multiple cases (mandatory/optional combinations).  
  - **1:M** → Fewer cases.  
  - **M:M** → Always one case (new table).  
---

============================= Mapping Steps =============================
Step 0: Mapping 1-1 relationship mandatory from 2 sides
        => One Table , Choose PK of any entity to this table.

Step 1: Mapping of Regular (Strong) Entity Types
       => simple attributes
       => composite attribute     => Take Components of Attribute
       => Multi-Valued attribute  => New Table PK Composite
       => Derived Attribute       => Not Mapped
       => Complex Attribute       => New Table With Components of Attribute 

Step 2: Mapping of Weak Entity Types 
        => New Table PK Composite between FK & Partial Key

Step 3: Mapping of Binary 1:1 Relation Types
       => Both sides are Mandatory. 
                => One Table , Choose PK of any entity to this table.
       => Mandatory - Optional.
                => 2 Tables , Take PK Of Optional As FK In Mandatory Table.
       => Both sides are Optional
                => 3 Tables ,  Choose PK of any entity to this table
Step 4: Mapping of Binary 1:N Relationship Types.
       => N-Side Mandatory. 
                => 2 Tables , Take PK Of One As FK in Many
       => N-Side Optional. 
                => 3 Tables , PK of Third Table is PK of Many

Step 5: Mapping of Binary M:N Relationship Types.
                => 3 Tables , PK of Third Table is Composite PK (PK1 + PK2)
Step 6: Mapping of N-ary Relationship Types.
                => Table for Each Entity 
                   + Table for Relation Contains PKs of each table as FK
                    ( PK is Composite PK).

Step 7: Mapping of Unary Relationship.

