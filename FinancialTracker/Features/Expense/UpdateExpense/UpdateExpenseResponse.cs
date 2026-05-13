namespace FinancialTracker.Features.Expense.UpdateExpense
{
    public sealed record UpdateExpenseResponse(
        int Id,
        string Name,
        string Category,
        double Amount
    );
}
