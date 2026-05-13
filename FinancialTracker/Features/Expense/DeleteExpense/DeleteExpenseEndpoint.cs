using MediatR;

namespace FinancialTracker.Features.Expense.DeleteExpense
{
    public static class DeleteExpenseEndpoint
    {
        public static void MapDeleteExpenseEndpoint(this WebApplication app)
        {
            app.MapDelete("/api/expense/{id}", async (
                int id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteExpenseCommand(id);
                var response = await sender.Send(command, cancellationToken);
                return Results.Ok(response);
            });
        }
    }
}
