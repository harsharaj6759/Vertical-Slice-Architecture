using FinancialTracker.Domain;
using MediatR;

namespace FinancialTracker.Features.Expense.CreateExpense
{
    public static class CreateExpenseEndpoint
    {
        public static void MapCreateExpenseEndpoint(this WebApplication app)
        {
            app.MapPost("/api/expense", async (
                CreateExpenseRequest request,
                ISender sender,
                CancellationToken cancellationToken) => 
            {
                var command = new CreateExpenseCommand(
                    request.Name,
                    Enum.TryParse<ExpenseCategory>(request.Category, true, out var category) ? category : 0, 
                    request.Amount
                );

                var response = await sender.Send(command, cancellationToken);

                return Results.Created($"/api/expense/{response.Id}", response);
            });
        }
    }
}
