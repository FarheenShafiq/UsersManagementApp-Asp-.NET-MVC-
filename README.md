USER MANAGEMENT ASP.NET MVC PROJECT
====================================
Project: UsersManagementApp (ASP.NET MVC + SQL Server)
Developed By: Farheen Shafiq
TECHNOLOGIES USED:
--------------------------
- ASP.NET MVC (.NET Framework)
- SQL Server (Local DB using SQL Server Authentication)
- Entity Framework (Code First + Manual Table Creation)
- HTML, CSS (Basic styling)
- Visual Studio
🎯 PROJECT FEATURES:
-----------------------
- User Registration
- User Login
- Records page to list users
- Form validation with ASP.NET Data Annotations
- Session management
- SQL Server integration
📂 PROJECT STRUCTURE:
-------------------------
Controllers/
├── HomeController.cs   (Handles Register, Login, and Records)
Models/
├── UsersModel.cs       (Represents the Users table)
Views/
├── Home/ Index
├── UsersManagement
│   ├── Register.cshtml
│   ├── Login.cshtml
│   ├── Edit.cshtml
│   ├── Records.cshtml
Views/Shared/
├── _Layout.cshtml      (Common layout)
wwwroot/
├── site.css           

🗄 DATABASE DETAILS:
-------------------------
Database Name: UsersManagementApp  
Server Name: DESKTOP-8BL3MIG\SQLEXPRESS  
Authentication: SQL Server Authentication  
Username: User  
Password: SQL@server  
📄 SQL SCRIPT TO CREATE DATABASE:
-----------------------------------
Paste and run this in SQL Server Management Studio:
CREATE DATABASE UsersManagementApp;
GO
USE UsersManagementApp;
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Department NVARCHAR(100) NOT NULL,
    Designation NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);
GO
✅ HOW TO RUN THE PROJECT:
-----------------------------
1. Open Visual Studio.
2. Go to File > Open > Project/Solution.
3. Select the `.sln` file of this project.
4. Build the project using `Ctrl + Shift + B`.
5. Right-click the project > Set as Startup Project.
6. Open `Web.config` and add your SQL Server connection string:

<connectionStrings> <add name="DefaultConnection" connectionString="Server=DESKTOP-8BL3MIG\SQLEXPRESS;Database=UsersManagementApp;User Id=User;Password=SQL@server;" providerName="System.Data.SqlClient" /> </connectionStrings> ```

Save all and press Ctrl + F5 to run the app.

OUTPUT:

  












