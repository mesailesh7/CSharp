
# HogWild Application: A Beginner's Guide to Database Connectivity, LINQ, and Frontend Integration

This document provides a comprehensive guide to understanding how the HogWild application connects to a database, uses LINQ for data retrieval, and integrates the backend with the frontend. We will walk through the entire process, from the database connection string to displaying data on a web page.

## 1. Database Connection

The foundation of any data-driven application is its connection to a database. In the HogWild project, this is managed through a combination of configuration files and service registrations.

### 1.1. The Connection String

The first step is to define the connection string, which tells the application where to find the database. This is stored in the `appsettings.json` file in the `HogWildWeb` project.

**File:** `HogWildWeb/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "",
    "OLTP-DMIT2018": "Server=.;Database=OLTP-DMIT2018;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

-   **`ConnectionStrings`**: This section holds one or more database connection strings.
-   **`OLTP-DMIT2018`**: This is the name of our connection string.
-   **`Server=.`**: Specifies the database server. In this case, `.` refers to the local machine.
-   **`Database=OLTP-DMIT2018`**: The name of the database.
-   **`Trusted_Connection=true`**: Uses Windows Authentication to connect to the database.
-   **`TrustServerCertificate=True`**: Trusts the server's security certificate.
-   **`MultipleActiveResultSets=true`**: Allows multiple database operations to be active on the same connection.

### 1.2. Registering the Database Context

Next, we need to tell our application how to use this connection string. This is done in `Program.cs` within the `HogWildWeb` project.

**File:** `HogWildWeb/Program.cs`

```csharp
// ... (other using statements)
using HogWildSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ... (other services)

// code retrieves the HogWild connection string
var connectionStringHogWild = builder.Configuration.GetConnectionString("OLTP-DMIT2018");

// Code the logic to add our class library services to IServiceCollection
// The extension method will be code inside the HogWildSystem class library
// The extension method will have a paramater: options.UseSqlServer()
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionStringHogWild));

// ... (rest of the file)
```

-   **`builder.Configuration.GetConnectionString("OLTP-DMIT2018")`**: This line reads the connection string from `appsettings.json`.
-   **`builder.Services.AddBackendDependencies(...)`**: This is a custom extension method that registers the database context and other services from the `HogWildSystem` class library. It passes the database provider configuration (`UseSqlServer`) to the method.

### 1.3. The Database Context (`HogWildContext`)

The `HogWildContext` class in the `HogWildSystem` project is the bridge between our application and the database. It represents a session with the database and allows us to query and save data.

**File:** `HogWildSystem/DAL/HogWildContext.cs`

```csharp
#nullable disable
using System;
using System.Collections.Generic;
using HogWildSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogWildSystem.DAL;

internal partial class HogWildContext : DbContext
{
    public HogWildContext(DbContextOptions<HogWildContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    // ... other DbSets for other tables

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ... (fluent API configurations for entities)
    }
}
```

-   **`DbContext`**: `HogWildContext` inherits from `DbContext`, which is the primary class from Entity Framework Core for interacting with a database.
-   **`DbSet<Customer> Customers { get; set; }`**: This property represents the `Customers` table in the database. We will use this to query for customer data.
-   **`OnModelCreating`**: This method is used to configure the database model, such as defining relationships between tables.

## 2. LINQ Queries and the Business Logic Layer (BLL)

With the database connection established, we can now query for data. This is done in the Business Logic Layer (BLL), which contains the application's business rules and logic.

### 2.1. The `CustomerService`

The `CustomerService` class is responsible for all operations related to customers. It uses the `HogWildContext` to interact with the database.

**File:** `HogWildSystem/BLL/CustomerService.cs`

```csharp
public class CustomerService
{
    private readonly HogWildContext _hogWildContext;

    internal CustomerService(HogWildContext hogWildContext)
    {
        _hogWildContext = hogWildContext;
    }

    public Result<List<CustomerSearchView>> GetCustomers(string lastName, string phone)
    {
        // ... (business rules)

        var customers = _hogWildContext.Customers
            .Where(c => (string.IsNullOrWhiteSpace(lastName)
                            ||
                            c.LastName.ToUpper().Contains(lastName.ToUpper()))
                        && (string.IsNullOrWhiteSpace(phone)
                            || c.Phone.Contains(phone))
                        && !c.RemoveFromViewFlag
                   )
            .Select(c => new CustomerSearchView
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                City = c.City,
                Phone = c.Phone,
                Email = c.Email,
                StatusID = c.StatusID,
                TotalSales = c.Invoices.Sum(i => (decimal?)(i.SubTotal + i.Tax)) ?? 0
            })
            .OrderBy(c => c.LastName)
            .ToList();

        // ... (handle no results)

        return result.WithValue(customers);
    }
}
```

### 2.2. Understanding the LINQ Query

The `GetCustomers` method uses a LINQ (Language Integrated Query) query to retrieve customer data. Let's break it down:

-   **`_hogWildContext.Customers`**: Starts the query on the `Customers` table.
-   **`.Where(...)`**: Filters the customers based on the `lastName` and `phone` parameters.
    -   It checks if the `lastName` or `phone` parameters are provided. If so, it filters the customers accordingly.
    -   `!c.RemoveFromViewFlag` ensures that we only get active customers (soft delete).
-   **`.Select(...)`**: Projects the results into a `CustomerSearchView` view model. This is a good practice as it separates the database entity from the data transfer object used by the UI.
-   **`.OrderBy(c => c.LastName)`**: Sorts the results by the customer's last name.
-   **`.ToList()`**: Executes the query and returns a list of `CustomerSearchView` objects.

### 2.3. LINQPad for Query Testing

The project includes `.linq` files, which can be used with LINQPad, a tool for interactively querying databases with LINQ. This is a great way to test and develop your queries before adding them to your application.

**File:** `HogWildSystem/LINQ/GetCustomers.linq`

```csharp
<Query Kind="Program">
  <!-- ... (connection info) -->
</Query>

void Main()
{
	GetCustomers("Fo", "").Dump();	
}

public List<CustomerSearchView> GetCustomers(string lastName, string phone)
{
	// ... (query logic similar to CustomerService)
}
```

This file allows developers to run the `GetCustomers` method directly in LINQPad to see the results.

## 3. Frontend Integration with Blazor

Now that we have our backend logic, let's see how the frontend (a Blazor application) uses it to display data.

### 3.1. The `CustomerList` Page

The `CustomerList.razor` page is responsible for displaying the list of customers.

**File:** `HogWildWeb/Components/Pages/SamplePages/CustomerList.razor`

```html
@page "/SamplePages/CustomerList"
<PageTitle>Customer List</PageTitle>
<MudText Typo="Typo.h3">Customers</MudText>

<!-- ... (error and feedback messages) -->

<MudStack Row="true" Spacing="4" AlignItems="AlignItems.Center">
    <MudText Typo="Typo.h5">Customer Search</MudText>
    <MudTextField @bind-Value="lastName" Label="Last Name" />
    <MudTextField @bind-Value="phoneNumber" Label="Phone Number" />
    <MudButton OnClick="Search">Search</MudButton>
    <MudButton OnClick="New">New</MudButton>
</MudStack>

@if (Customers.Count > 0)
{
    <MudDataGrid Items="Customers">
        <Columns>
            <!-- ... (column definitions) -->
            <PropertyColumn Property="x => x.FirstName" Title="First Name" />
            <PropertyColumn Property="x => x.LastName" Title="Last Name" />
            <!-- ... (other columns) -->
        </Columns>
    </MudDataGrid>
}
```

-   **`@page "/SamplePages/CustomerList"`**: Defines the URL for this page.
-   **`@bind-Value="lastName"`**: Binds the input field to the `lastName` property in the code-behind.
-   **`OnClick="Search"`**: Calls the `Search` method when the button is clicked.
-   **`<MudDataGrid Items="Customers">`**: Displays the `Customers` list in a grid format.

### 3.2. The Code-Behind (`CustomerList.razor.cs`)

The logic for the `CustomerList` page is in its code-behind file.

**File:** `HogWildWeb/Components/Pages/SamplePages/CustomerList.razor.cs`

```csharp
public partial class CustomerList
{
    private string lastName = string.Empty;
    private string phoneNumber = string.Empty;

    [Inject]
    protected CustomerService CustomerService { get; set; } = default!;

    protected List<CustomerSearchView> Customers { get; set; } = new();

    private void Search()
    {
        try
        {
            var result = CustomerService.GetCustomers(lastName, phoneNumber);
            if (result.IsSuccess)
            {
                Customers = result.Value;
            }
            else
            {
                // ... (handle errors)
            }
        }
        catch (Exception ex)
        {
            // ... (handle exceptions)
        }
    }
}
```

-   **`[Inject]`**: This attribute is used for dependency injection. It tells the Blazor framework to inject an instance of `CustomerService` into this property.
-   **`Search()`**: This method is called when the user clicks the "Search" button. It calls the `GetCustomers` method in the `CustomerService` and updates the `Customers` property with the results. Blazor automatically re-renders the component when this property changes, updating the UI.

## 4. Step-by-Step Guide: From Database to Frontend

Here is a summary of the entire process:

1.  **Configuration (`appsettings.json`)**: The database connection string is defined.
2.  **Service Registration (`Program.cs`)**: The `DbContext` and other services are registered with the application's service container. The connection string is read and passed to the `DbContext`.
3.  **Data Access (`HogWildContext.cs`)**: The `DbContext` defines the database schema and provides `DbSet` properties for each table.
4.  **Business Logic (`CustomerService.cs`)**: The service class uses the `DbContext` to perform database operations. It contains LINQ queries to retrieve and manipulate data.
5.  **Dependency Injection**: The `CustomerService` is injected into the Blazor component (`CustomerList.razor.cs`).
6.  **User Interaction (`CustomerList.razor`)**: The user enters search criteria and clicks a button.
7.  **Data Retrieval (`CustomerList.razor.cs`)**: The button's click handler calls the `GetCustomers` method in the `CustomerService`.
8.  **UI Update**: The `Customers` list is populated with the data returned from the service. Blazor detects the change and updates the `MudDataGrid` to display the new data.

This architecture creates a clean separation of concerns, making the application easier to develop, test, and maintain.
