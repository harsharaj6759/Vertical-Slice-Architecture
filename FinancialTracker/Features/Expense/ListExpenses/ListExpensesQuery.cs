using MediatR;

namespace FinancialTracker.Features.Expense.ListExpenses
{
    public record ListExpensesQuery(
        int Page = 1,
        int PageSize = 10
    ) : IRequest<ListExpensesResponse>;
}
