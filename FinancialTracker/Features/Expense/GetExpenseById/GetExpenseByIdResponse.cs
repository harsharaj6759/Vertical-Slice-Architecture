namespace FinancialTracker.Features.Expense.GetExpenseById
{
    public sealed record GetExpenseByIdResponse(
        int Id,
        string Name,
        string Category,
        double Amount
    );
}
