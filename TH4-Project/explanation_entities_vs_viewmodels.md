
# Entities vs. ViewModels in C# Applications

This document explains the roles of **Entities** and **ViewModels** in a .NET application, why both are used, and how they relate to each other, using the context of your project structure.

## Summary (TL;DR)

*   **Entity**: Represents the "shape" of your data in the **database**. Its primary job is to get data to and from the database. It should match a database table's structure.
*   **ViewModel**: Represents the data needed for a specific **UI View** (a page or a component). Its primary job is to prepare data for display and to receive data from user input. It is tailored specifically for the UI's needs.

Think of it like this: The **Entity** is the raw ingredient (like a potato). The **ViewModel** is the finished dish you serve (like french fries or mashed potatoes). You don't serve a raw potato to the customer; you prepare it for them.

---

## 1. What is an Entity?

An **Entity** is a class that directly maps to a table in your database. In projects using an Object-Relational Mapper (ORM) like Entity Framework (which you appear to be using), each property in the entity class typically corresponds to a column in the database table.

**Purpose:**
*   To define the structure of your application's core data.
*   To act as the data carrier for all database operations (Create, Read, Update, Delete).
*   To be the "single source of truth" for what your data looks like.

**Location in your project:** `TH4System/Entities/`

### Example: `Order.cs` Entity

Based on your file `TH4System/Entities/Order.cs`, an entity might look like this. Notice how the properties are simple and directly represent data columns.

```csharp
// TH4System/Entities/Order.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int OrderId { get; set; } // Primary Key

    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; } // Foreign Key

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } // Navigation property

    public int? PickerId { get; set; } // Foreign Key (nullable)

    [Column(TypeName = "decimal(9, 2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "decimal(9, 2)")]
    public decimal GST { get; set; }

    // This is raw data, not for direct display
    public int StatusCode { get; set; } // e.g., 1=Placed, 2=Picking, 3=Ready
}
```

---

## 2. What is a ViewModel?

A **ViewModel** (or "View Model") is a class that is custom-designed to support the needs of a specific View (e.g., a Razor page). It holds the exact data and supports the specific actions that the UI needs, no more and no less.

**Purpose:**
*   To shape data for presentation (e.g., combining data from multiple entities).
*   To avoid exposing your database structure directly to the UI, which is a security and maintenance risk.
*   To reduce the amount of data sent to the client (only send what's needed).
*   To hold UI-specific information that doesn't belong in the database (e.g., dropdown list options, or a boolean for whether a button should be enabled).

**Location in your project:** `TH4System/ViewModels/`

### Example: `OrderListView.cs` ViewModel

This ViewModel might be used by your `OrderList.razor` page. It takes data from the `Order` entity but transforms it for display.

```csharp
// TH4System/ViewModels/OrderListView.cs

public class OrderListView
{
    // Simplified data for the list view
    public int OrderId { get; set; }

    // Combined or formatted data
    public string CustomerName { get; set; } // From the related Customer entity
    public string OrderDateDisplay { get; set; } // Formatted as a nice string
    public string TotalDisplay { get; set; } // Formatted as currency
    public string StatusText { get; set; } // e.g., "Order Placed", "Being Picked"

    // UI-specific properties
    public bool CanBeCancelled { get; set; } // Logic determined by the system
}
```

---

## 3. Key Differences Summarized

| Feature          | Entity                                       | ViewModel                                                |
| ---------------- | -------------------------------------------- | -------------------------------------------------------- |
| **Purpose**      | Data persistence (Database)                  | Data presentation (UI)                                   |
| **Coupling**     | Tightly coupled to the database schema.      | Tightly coupled to a specific View's requirements.       |
| **Properties**   | Match table columns.                         | Match what the UI needs to display or capture.           |
| **Data Source**  | Represents a single table (usually).         | Can be composed of data from one or more entities.       |
| **Location**     | `Entities` folder.                           | `ViewModels` folder.                                     |
| **Lifetime**     | Used in the data and business logic layers.  | Used in the business logic and presentation (UI) layers. |

---

## 4. The Workflow: From Entity to ViewModel

Here is the typical flow of data from the database to the UI, showing why both are necessary.

1.  **Request:** A user navigates to the "Order List" page in your Blazor app.
2.  **Controller/Service Call:** The UI layer calls a method in a service class, for example, `OrderService.GetAllOrders()`.
3.  **Data Fetching (using Entities):** The `OrderService` uses the `DbContext` to query the database. This query returns a list of `Order` **entities**.
    ```csharp
    // Inside OrderService.cs
    var orderEntities = _context.Orders.Include(o => o.Customer).ToList();
    ```
4.  **Mapping (The crucial step):** The service **does not** return the raw entities. Instead, it creates a new list of `OrderListView` **ViewModels**. It loops through the entities and maps the required data. This is where the "transformation" happens.
    ```csharp
    // Inside OrderService.cs
    var orderViewModels = orderEntities.Select(entity => new OrderListView
    {
        OrderId = entity.OrderId,
        CustomerName = entity.Customer.FullName, // Data from a related entity
        OrderDateDisplay = entity.OrderDate.ToString("MMM dd, yyyy"), // Formatting
        TotalDisplay = (entity.SubTotal + entity.GST).ToString("C"), // Calculation & Formatting
        StatusText = GetStatusString(entity.StatusCode), // Business logic
        CanBeCancelled = (entity.StatusCode == 1) // UI-specific logic
    }).ToList();
    ```
5.  **Return ViewModel:** The service returns the `List<OrderListView>` to the UI.
6.  **UI Binding:** The Blazor page (`OrderList.razor`) receives this list and simply binds its HTML elements to the clean, pre-formatted properties of the ViewModel.

By using this pattern, you achieve **Separation of Concerns**. The Entity worries about the database, the ViewModel worries about the UI, and the Service class acts as a mediator between them.
