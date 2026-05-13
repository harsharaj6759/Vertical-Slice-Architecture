using MediatR;

namespace FinancialTracker.Features.Expense.DeleteExpense
{
    public record DeleteExpenseCommand(int Id) : IRequest<DeleteExpenseResponse>;
}
