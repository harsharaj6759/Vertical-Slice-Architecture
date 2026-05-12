using FinancialTracker.Domain;
using MediatR;

namespace FinancialTracker.Features.Expense.CreateExpense
{
    public record CreateExpenseCommand
    (
        string Name,
        ExpenseCategory Category,
        double Amount
    ) : IRequest<CreateExpenseResponse>;
}
