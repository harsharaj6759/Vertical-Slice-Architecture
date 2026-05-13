namespace FinancialTracker.Features.Expense.UpdateExpense
{
    public sealed record UpdateExpenseRequest(
        string Name,
        string Category,
        double Amount
    );
}
