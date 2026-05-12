# Vertical Slice Architecture

## Project Overview

This project was created to learn vertical slice architecture using a Financial Tracker project. It demonstrates how to implement vertical slices to organize code around business features rather than technical layers.

## Tech Stack

- **Framework**: ASP.NET Core 9.0
- **Database**: SQLite
- **ORM**: Entity Framework Core
- **Patterns**: MediatR (CQRS pattern)
- **Language**: C#

## Project Structure

The project follows a vertical slice architecture pattern where each feature is organized as a complete vertical slice containing all layers (Presentation, Application, Domain, Data).

```
FinancialTracker/
├── Domain/                    # Core domain entities
│   └── Expense.cs            # Expense entity and ExpenseCategory enum
├── Data/                      # Data access layer
│   └── FinancialTrackerDbContext.cs
├── Features/                  # Vertical slices (features)
│   └── Expense/
│       └── CreateExpense/     # Complete vertical slice for creating expenses
│           ├── CreateExpenseCommand.cs      # MediatR Command
│           ├── CreateExpenseHandler.cs      # Command Handler
│           ├── CreateExpenseEndpoint.cs     # API Endpoint
│           ├── CreateExpenseRequest.cs      # Request DTO
│           └── CreateExpenseResponse.cs     # Response DTO
├── Migrations/                # Database migrations
├── Program.cs                 # Application startup configuration
└── appsettings.json          # Configuration files
```

## Features

### 1. Create Expense
- **Endpoint**: `POST /expenses`
- **Description**: Create a new expense entry with the following details:
  - **Name**: Expense name/description
  - **Category**: Category of the expense (Grocery, Meat, Misc, Eating_out)
  - **Amount**: Expense amount
- **Request Model**:
  ```csharp
  public sealed record CreateExpenseRequest(
      string Name,
      string Category,
      double Amount
  );
  ```
- **Implementation**: 
  - Uses MediatR pattern for CQRS
  - `CreateExpenseCommand` - Command object
  - `CreateExpenseHandler` - Business logic handler
  - `CreateExpenseEndpoint` - HTTP endpoint mapping
  - Direct database persistence via Entity Framework Core

## Domain Model

### Expense Entity
- **Id**: Unique identifier
- **Name**: Expense description
- **Category**: Enum-based categorization
  - None
  - Grocery
  - Meat
  - Misc
  - Eating_out
- **Amount**: Expense amount (double)

## How to Run

1. Ensure you have .NET 9.0 SDK installed
2. Navigate to the `FinancialTracker` directory
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. The API will be available at `http://localhost:5124`

## Future Enhancements

- [ ] Get Expense (retrieve single expense)
- [ ] Get All Expenses (list all expenses)
- [ ] Update Expense (modify existing expense)
- [ ] Delete Expense (remove expense)
- [ ] Expense filtering and search
- [ ] Budget tracking features
- [ ] Reports and analytics
- [ ] Additional vertical slices for other financial features

## Learning Objectives

This project demonstrates:
- ✅ Vertical slice architecture pattern
- ✅ CQRS pattern with MediatR
- ✅ Clean separation of concerns
- ✅ Feature-oriented code organization
- ✅ Entity Framework Core integration
- ✅ ASP.NET Core minimal APIs

## References

- [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)
- [MediatR Documentation](https://github.com/jbogard/MediatR)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
