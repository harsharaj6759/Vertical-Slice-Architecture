using FinancialTracker.Data;
using MediatR;

namespace FinancialTracker.Features.Expense.GetExpenseById
{
    public sealed class GetExpenseByIdHandler : IRequestHandler<GetExpenseByIdQuery, GetExpenseByIdResponse>
    {
        private readonly FinancialTrackerDbContext _dbContext;

        public GetExpenseByIdHandler(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetExpenseByIdResponse> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);

            if (expense is null)
            {
                throw new InvalidOperationException($"Expense with id {request.Id} not found");
            }

            return new GetExpenseByIdResponse(
                expense.Id,
                expense.Name,
                expense.Category.ToString(),
                expense.Amount
            );
        }
    }
}
