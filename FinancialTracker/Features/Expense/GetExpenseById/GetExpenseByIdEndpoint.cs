using MediatR;

namespace FinancialTracker.Features.Expense.GetExpenseById
{
    public static class GetExpenseByIdEndpoint
    {
        public static void MapGetExpenseByIdEndpoint(this WebApplication app)
        {
            app.MapGet("/api/expense/{id}", async (
                int id,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetExpenseByIdQuery(id);
                var response = await sender.Send(query, cancellationToken);
                return Results.Ok(response);
            });
        }
    }
}
