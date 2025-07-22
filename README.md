USER MANAGEMENT ASP.NET MVC PROJECT

Project: UsersManagementApp (ASP.NET MVC + SQL Server)
Developed By: Farheen Shafiq

<img width="975" height="479" alt="image" src="https://github.com/user-attachments/assets/85e34632-4155-4082-8633-0bc9406951ff" />
<img width="975" height="420" alt="image" src="https://github.com/user-attachments/assets/c544d2ff-ec80-434c-a7bd-6a83428189e2" />
<img width="975" height="474" alt="image" src="https://github.com/user-attachments/assets/cfaffcd1-8b57-44f9-bf15-e5883105c309" />
<img width="975" height="470" alt="image" src="https://github.com/user-attachments/assets/c928c7b2-3329-488d-a5cc-a4c58e7604ca" />


 TECHNOLOGIES USED:

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

DATABASE DETAILS:

-------------------------
Database Name: UsersManagementApp  

Server Name: DESKTOP-8BL3MIG\SQLEXPRESS 

Authentication: SQL Server Authentication 

Username: User  

Password: SQL@server 

📄 SQL SCRIPT TO CREATE DATABASE:

Paste and run table from DatabaseInfo.txt in SQL Server Management Studio:

✅ HOW TO RUN THE PROJECT:

1. Open Visual Studio.
2. Go to File > Open > Project/Solution.
3. Select the `.sln` file of this project.
4. Build the project using `Ctrl + Shift + B`.
5. Right-click the project > Set as Startup Project.
6. Open `Web.config` and add your SQL Server connection string:

<connectionStrings> <add name="DefaultConnection" connectionString="Server=DESKTOP-8BL3MIG\SQLEXPRESS;Database=UsersManagementApp;User Id=User;Password=SQL@server;" providerName="System.Data.SqlClient" /> </connectionStrings> ```

Save all and press Ctrl + F5 to run the app.


  












