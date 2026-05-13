using FinancialTracker.Domain;
using MediatR;

namespace FinancialTracker.Features.Expense.UpdateExpense
{
    public record UpdateExpenseCommand(
        int Id,
        string Name,
        ExpenseCategory Category,
        double Amount
    ) : IRequest<UpdateExpenseResponse>;
}
