namespace FinancialTracker.Features.Expense.DeleteExpense
{
    public sealed record DeleteExpenseResponse(
        bool Success,
        string Message
    );
}
