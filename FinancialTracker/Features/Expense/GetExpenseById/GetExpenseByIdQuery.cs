using MediatR;

namespace FinancialTracker.Features.Expense.GetExpenseById
{
    public record GetExpenseByIdQuery(int Id) : IRequest<GetExpenseByIdResponse>;
}
