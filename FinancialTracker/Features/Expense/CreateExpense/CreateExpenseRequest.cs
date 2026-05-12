using FinancialTracker.Domain;

namespace FinancialTracker.Features.Expense.CreateExpense
{
    public sealed record CreateExpenseRequest
    (
        string Name,
        string Category,
        double Amount
    );


}