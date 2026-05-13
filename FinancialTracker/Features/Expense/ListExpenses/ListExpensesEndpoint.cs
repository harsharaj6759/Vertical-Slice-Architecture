using MediatR;

namespace FinancialTracker.Features.Expense.ListExpenses
{
    public static class ListExpensesEndpoint
    {
        public static void MapListExpensesEndpoint(this WebApplication app)
        {
            app.MapGet("/api/expenses", async (
                int page = 1,
                int pageSize = 10,
                ISender sender = null!,
                CancellationToken cancellationToken = default) =>
            {
                var query = new ListExpensesQuery(page, pageSize);
                var response = await sender.Send(query, cancellationToken);
                return Results.Ok(response);
            });
        }
    }
}
