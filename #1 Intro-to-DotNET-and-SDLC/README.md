# Introduction to .NET and SDLC

This section provides a detailed summary of the fundamentals before diving deeper into .NET.  
It covers the difference between **Web Applications and Websites**, the **Web Development Team Hierarchy**, and a full walkthrough of the **Software Development Life Cycle (SDLC)**.

---

## 1. Web Application vs Website

### Web Application
- **Dynamic content** → interaction between user and server.  
- Supports both **Read and Write** operations.  
- Requires **User Authentication** (e.g., login, registration).  
- Example: Online banking, e-commerce platforms.

### Website
- **Static content** → same for all users.  
- **Read-only** (users can view but not modify).  
- Usually does **not require authentication**.  
- Example: Blogs, company landing pages.

---

## 2. Web Development Team Hierarchy

The typical team structure in software companies:

- **Project Manager**  
  - Defines the team composition and responsibilities.

- **Business Consultant / System Analyst**  
  - Connects with the client to gather business requirements.  
  - Translates requirements for the development team.

- **Development Team**  
  - Divided into **Frontend** and **Backend**.  
  - Each sub-team has:
    - **Team Leader**  
    - **Specialist, Senior, Junior** developers  
  - Reason for 3 levels:  
    - **Technical** → natural career growth (junior → senior → specialist).  
    - **Financial** → not all tasks need senior-level salaries.

- **Testing Team**  
  - Ensures the project is bug-free and meets requirements.  
  - Divided into:
    - **Quality Control (QC)** → verifies business requirements.  
    - **Quality Assurance (QA)** → ensures best quality and performance.  
  - Same structure: Specialist, Senior, Junior.

[ Client ]
│
[ Business Consultant ]
│
[ Project Manager ]
│
┌─────────────────────────┐
│ Development │
│ Team (Frontend + │
│ Backend) │
└─────────────────────────┘
│
[ Testing Team ]
(QC + QA)


---

## 3. Software Development Life Cycle (SDLC)

The SDLC ensures that software is built systematically to avoid risks and problems.  
Main steps:

Analysis → Design → Development → Testing → Staging → Deployment → Maintenance


---

### Step 1: Analysis
- Participants: **Project Manager, Business Consultant, Sales, Client**.  
- Collect requirements and define scope.  
- Output: **Software Requirement Specification (SRS)** document.  

---

### Step 2: Design
- Participants: **Project Manager, Business Consultant, UI/UX Designers, Development Team**.  
- **UX Design** → focus on usability, mockups, and sitemap.  
- **UI Design** → styling, colors, fonts using tools like Figma or Photoshop.  
- **UI Development** → build templates.  
- **Frontend Framework** → Angular (preferred with .NET), React, etc.

[ UX Mockup ] → [ UI Design ] → [ UI Development ] → [ Frontend Framework ]


---

### Step 3: Development

**Backend splits into two main areas:**

#### 1. Programming (.NET Platform)
- .NET is a **platform**, not just a framework.  
- Contains multiple frameworks:  
  - **Cloud** → Azure  
  - **Web** → ASP.NET, Blazor  
  - **Desktop** → .NET MAUI, WPF, WinForms  
  - **Mobile** → .NET MAUI, Xamarin  
  - **Gaming** → Unity  
  - **IoT** → ARM32, ARM64  
  - **AI** → .NET for Apache Spark  

**Versions of .NET**  
- **.NET Framework (2002–2019)** → Windows-only, not cross-platform, not open-source.  
- **.NET Core (2016–today)** → Cross-platform, open-source, foundation for modern .NET.  
- Microsoft releases yearly updates (November) with new features, bug fixes, and syntax improvements.  

**Languages**: C#, F#, VB.NET (C# is the most popular).  

---

#### 2. ASP.NET Project Types
ASP.NET allows building different types of projects:

- **MVC (Model–View–Controller)**  
  - Model → Database structure.  
  - View → HTML page.  
  - Controller → Handles requests, connects Model & View.  
  - Example:  
    ```
    www.netflix.com/Movies/GetMovie?id=100
    Movies → Controller
    GetMovie → Action (function)
    id=100 → Parameter
    ```
  - MVC Flow:
    ```
    [ User Request ]
           ↓
     [ Controller ] ----> Calls ----> [ Model (Database) ]
           ↓
       Sends Data
           ↓
     [ View (HTML Page) ]
           ↓
    [ User Sees Result ]
    ```

- **Razor Pages (MVVM-like)**  
  - Model takes the role of both **data handler** and **request processor**.  
  - Simpler, page-focused applications.  
  - Flow:
    ```
    [ User Request ]
           ↓
     [ Model (acts as Controller + DB Handler) ]
           ↓
     [ View (Razor Page) ]
           ↓
    [ User Sees Result ]
    ```

- **Web API**  
  - Provides endpoints returning JSON/XML.  
  - Consumed by mobile apps (Flutter, Android, iOS) or frontend frameworks (React, Angular).  
  - Flow:
    ```
    [ User Request ]
           ↓
     [ Controller ] ---> Interacts with ---> [ Model (Database) ]
           ↓
      Returns JSON Response
    ```

- **Blazor**  
  - Modern .NET framework inspired by Angular/React.  
  - **Blazor Server** → server-side, supports real-time via SignalR.  
  - **Blazor WebAssembly** → client-side, runs in the browser.

---

#### 3. Database
- **Relational Database (RDBMS)**  
  - Structured, table-based (SQL Server, MySQL, PostgreSQL, Oracle).  
  - Relationships between tables (1–1, 1–many, many–many).  

- **Non-Relational Database (NoSQL)**  
  - Unstructured or semi-structured (MongoDB, Cassandra, Redis).  
  - Schema-less or schema-light, flexible formats (documents, key-value, graphs).  

- **Other Types**:  
  - **In-Memory DB** → stores in RAM for speed (Redis, Memcached, SAP HANA).  
  - **Cloud DB** → hosted in the cloud, scalable and reliable (Azure SQL, Amazon RDS, Firestore).  

---

### Step 4: Testing
- Done by **Testers** using DevOps/TFS for task tracking.  
- If service passes → marked done by both Dev & Tester.  
- If bugs exist → returned to developer.  
- Severe issues may lead to rebuilding the service.  

**Types of Testing**:  
- **Manual Testing** → Tester simulates real user.  
- **Automation Testing** → Scripts run many test cases automatically.  

**Loop:** Development ↔ Testing until stable.  

**Testing Team Roles**:  
- **Quality Control (QC)** → verifies business requirements.  
- **Quality Assurance (QA)** → ensures best version of product, performance, reliability, and UX.  

[ Development ] ⇄ [ Testing ]


---

### Step 5: Staging
- Client reviews features in a **staging environment** with Business Consultant.  
- **User Acceptance Testing (UAT)** performed by client.  
- Possible outcomes:  
  - ✅ Approved → move to Deployment.  
  - ❌ Bugs → returned for fixes.  
  - 🔄 New requirements outside SRS → require new contract and budget.  

[ Testing ] → [ UAT by Client ]
│
├── Approved → Deployment
└── Changes/Bugs → Back to Development


---

### Step 6: Deployment
- Application is released to **production**.  
- Deployment may be handled by the development team or client’s IT team.

---

### Step 7: Maintenance
- Ongoing support after deployment.  
- Fixing bugs, optimizing performance, updating features.  

---

## Agile Note
- Agile methodology reduces large UAT rejections by showing progress early.  
- After each module is completed, a demo is shown to the client for feedback.  
[ Develop Small Feature ] → [ Show Client ] → [ Feedback ] → [ Adjust ]