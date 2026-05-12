using FinancialTracker.Domain;

namespace FinancialTracker.Features.Expense.CreateExpense
{
    public sealed record CreateExpenseResponse
    (
        int Id,
        string Name,
        string Category,
        double Amount
    );
}
