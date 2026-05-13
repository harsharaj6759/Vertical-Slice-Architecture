using MediatR;

namespace FinancialTracker.Features.Expense.UpdateExpense
{
    public static class UpdateExpenseEndpoint
    {
        public static void MapUpdateExpenseEndpoint(this WebApplication app)
        {
            app.MapPut("/api/expense/{id}", async (
                int id,
                UpdateExpenseRequest request,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new UpdateExpenseCommand(
                    id,
                    request.Name,
                    Enum.TryParse<Domain.ExpenseCategory>(request.Category, true, out var category) ? category : Domain.ExpenseCategory.None,
                    request.Amount
                );

                var response = await sender.Send(command, cancellationToken);
                return Results.Ok(response);
            });
        }
    }
}
