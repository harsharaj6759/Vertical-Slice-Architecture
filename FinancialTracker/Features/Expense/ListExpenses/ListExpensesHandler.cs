using FinancialTracker.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTracker.Features.Expense.ListExpenses
{
    public sealed class ListExpensesHandler : IRequestHandler<ListExpensesQuery, ListExpensesResponse>
    {
        private readonly FinancialTrackerDbContext _dbContext;

        public ListExpensesHandler(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ListExpensesResponse> Handle(ListExpensesQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _dbContext.Expenses.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);

            var expenses = await _dbContext.Expenses
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var expenseItems = expenses.Select(e => new ExpenseListItemResponse(
                e.Id,
                e.Name,
                e.Category.ToString(),
                e.Amount
            )).ToList();

            return new ListExpensesResponse(
                expenseItems,
                totalCount,
                request.Page,
                request.PageSize,
                totalPages
            );
        }
    }
}
