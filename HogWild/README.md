# HogWild Project: A Beginner's Guide

Welcome to the HogWild project! This guide will walk you through setting up and running this application on your local machine. It's designed for beginners, with step-by-step instructions and explanations of the key concepts involved.

## 1. Project Overview

HogWild is a web application built with C# and the .NET framework. It uses Blazor for the user interface (UI) and Entity Framework Core for database interaction. The project is structured into two main parts:

-   `HogWildSystem`: A class library that contains the core business logic, data access layer (DAL), and data entities. This is where the "brains" of the application live.
-   `HogWildWeb`: The Blazor web application project, which provides the user interface that you see and interact with in your browser.

## 2. Prerequisites

Before you begin, make sure you have the following software installed on your computer:

-   **.NET 9 SDK:** This project targets .NET 9. You can download it from the official [.NET website](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
-   **Visual Studio 2022:** The recommended integrated development environment (IDE) for .NET projects. Make sure to include the "ASP.NET and web development" workload during installation.
-   **SQL Server Express LocalDB:** This is a lightweight version of SQL Server that comes with Visual Studio and is perfect for local development. Ensure it's installed as part of the "Data storage and processing" workload in the Visual Studio Installer.

## 3. Step-by-Step Setup Instructions

Follow these steps in order to get the application running.

### Step 1: Get the Code

First, you need a copy of the project on your machine. If you have `git` installed, you can clone the repository. Otherwise, you can download it as a ZIP file.

```bash
# Clone the repository
git clone <repository-url>
```

### Step 2: Set Up the Databases

This project uses two databases:
1.  **Identity Database:** Manages user accounts (login, registration).
2.  **Application Database (`HogWildDB`):** Stores the application's data (customers, invoices, etc.).

The connection strings in `HogWildWeb/appsettings.json` tell the application where to find these databases. We will use Entity Framework Core migrations to create them.

1.  **Open the Solution:** Open the `HogWild.sln` file in Visual Studio.
2.  **Open Package Manager Console:** In Visual Studio, go to `View` -> `Other Windows` -> `Package Manager Console`.
3.  **Create the Identity Database:**
    -   In the Package Manager Console, ensure the "Default project" dropdown is set to `HogWildWeb`.
    -   Run the following command. This command finds the migrations in the `HogWildWeb` project and creates the database for user accounts.

    ```powershell
    Update-Database
    ```
    *   **Why?** This command applies the Entity Framework migrations for the `ApplicationDbContext`, which is configured in `HogWildWeb` to handle user identity. This automatically creates the necessary tables for authentication.

4.  **Create the Application Database (`HogWildDB`):**
    -   The main application database context (`HogWildContext`) is in the `HogWildSystem` project. We need to tell Entity Framework how to create it.
    -   In the Package Manager Console, change the "Default project" to `HogWildSystem`.
    -   Run the following command. You might be prompted to install `dotnet-ef` if you haven't already.

    ```powershell
    dotnet ef database update --startup-project ../HogWildWeb
    ```
    *   **Why?** This command applies the migrations for the `HogWildContext`. Because the `HogWildSystem` project is a class library and cannot be run on its own, we use the `--startup-project` option to point to `HogWildWeb`. This provides the necessary configuration (like the connection string from `appsettings.json`) for the command to execute correctly.

### Step 3: Build and Run the Application

Now that the databases are set up, you can run the application.

1.  **Set Startup Project:** In the Solution Explorer, right-click on the `HogWildWeb` project and select "Set as Startup Project".
2.  **Run the Project:** Press the `F5` key or click the green play button (usually labeled "HogWildWeb") at the top of Visual Studio.
3.  **View the Application:** Visual Studio will build the project and open it in your default web browser.

You should now have a fully functional version of the HogWild application running locally!

## 4. Understanding the Project Structure

-   **`HogWild.sln`**: This is the solution file. It's like a container that groups all the related projects together.
-   **`HogWildSystem` Project**:
    -   `BLL` (Business Logic Layer): Contains services that handle the application's logic (e.g., `CustomerService`).
    -   `DAL` (Data Access Layer): Contains the `HogWildContext`, which is the bridge between your C# objects and the database.
    -   `Entities`: Defines the C# classes that map to your database tables (e.g., `Customer`, `Invoice`).
    -   `ViewModels`: Models specifically designed to hold data for the views (the UI).
-   **`HogWildWeb` Project**:
    -   `Components/Pages`: This is where the Blazor pages (the UI you see) are located. These are `.razor` files.
    -   `Program.cs`: The entry point of the web application. It's where services are configured and registered.
    -   `appsettings.json`: Configuration file for the web app, including database connection strings.
    -   `wwwroot`: Contains static files like CSS, JavaScript, and images.

## 5. Key Concepts for Beginners

-   **Blazor:** A modern web framework for building interactive web UIs with C# instead of JavaScript. The UI logic is written in C# and runs on the server.
-   **Entity Framework Core (EF Core):** An object-relational mapper (O/RM). It simplifies database access by letting you work with C# objects instead of writing raw SQL queries.
-   **Dependency Injection (DI):** A design pattern used heavily in modern .NET. Instead of creating dependencies (like a `CustomerService`) inside a class, they are "injected" from an external source. This makes the code more modular and easier to test. You can see it in action in `Program.cs`.
-   **Solution and Projects:** In Visual Studio, a "solution" is a container for one or more "projects." This helps organize larger applications. In our case, we have a project for the core logic and another for the web UI, which is a common and good practice.

## 6. Configuring `Program.cs` in HogWildWeb

The `Program.cs` file is the heart of the web application's configuration. Here’s how it’s set up to work with the `HogWildSystem` class library:

1.  **Connection Strings:** It retrieves two connection strings from `appsettings.json`:
    *   `DefaultConnection`: For the Identity database (user accounts).
    *   `OLTP-DMIT2018`: For the main application database (`HogWildDB`).

2.  **Registering Services:** The key to connecting the web and system projects is the `AddBackendDependencies` extension method. You will find this line in `Program.cs`:

    ```csharp
    builder.Services.AddBackendDependencies(options =>
        options.UseSqlServer(connectionStringHogWild));
    ```

    *   **What this does:** This custom extension method (located in `HogWildSystem/HogWildExtension.cs`) registers all the necessary services from your `HogWildSystem` project with the web application's service container. This includes:
        *   The `HogWildContext` (your DAL).
        *   All your BLL service classes (like `CustomerService`).
    *   **Why it's done this way:** This approach keeps the `Program.cs` file clean and follows the principle of separation of concerns. All the registration logic for `HogWildSystem` is neatly contained within that project itself.

## 7. DAL and BLL: Creation Order and Implementation

When building a layered application like this, you typically create the layers in the following order. This ensures that dependencies flow in one direction (Web -> System -> Database).

### Step 1: Create the DAL (Data Access Layer)

1.  **Entities:** First, define your C# classes in the `HogWildSystem/Entities` folder. These classes (`Customer`, `Invoice`, etc.) represent the tables in your database.
2.  **DbContext:** Create your `HogWildContext.cs` file in the `DAL` folder. This class inherits from `Microsoft.EntityFrameworkCore.DbContext` and contains `DbSet<>` properties for each of your entities. This is how EF Core knows which classes to map to database tables.

### Step 2: Create the BLL (Business Logic Layer)

1.  **Service Classes:** Create your service classes (e.g., `CustomerService.cs`) in the `BLL` folder. These classes contain the business logic for your application.
2.  **Inject the DbContext:** Each BLL service will need to interact with the database. To do this, you "inject" the `HogWildContext` into the service's constructor. This is an example of Dependency Injection.

    ```csharp
    public class CustomerService
    {
        private readonly HogWildContext _hogWildContext;

        internal CustomerService(HogWildContext hogWildContext)
        {
            _hogWildContext = hogWildContext;
        }

        // ... methods that use _hogWildContext ...
    }
    ```

### Step 3: Implement in HogWildWeb

Now that your `HogWildSystem` has its services defined and registered, you can use them in your Blazor pages (`.razor` files) in the `HogWildWeb` project.

1.  **Inject the BLL Service:** In your Blazor component (e.g., `CustomerList.razor.cs` or in the `@code` block of a `.razor` file), inject the BLL service you need using the `[Inject]` attribute.

    ```csharp
    @using HogWildSystem.BLL
    @inject CustomerService CustomerService
    ```

2.  **Call Service Methods:** You can now call the methods on your injected service to fetch or manipulate data. For example, in your `CustomerList` page, you might have a method to search for customers:

    ```csharp
    private void Search()
    {
        // Call the GetCustomers method from the injected CustomerService
        var result = CustomerService.GetCustomers(lastName, phoneNumber);
        if (result.IsSuccess)
        {
            Customers = result.Value;
        }
        else
        {
            // Handle errors
        }
    }
    ```

This layered approach makes your application organized, scalable, and easier to maintain.

---
*This guide was generated to help you get started. Happy coding!*