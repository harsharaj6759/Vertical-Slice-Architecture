using FinancialTracker.Data;
using MediatR;

namespace FinancialTracker.Features.Expense.DeleteExpense
{
    public sealed class DeleteExpenseHandler : IRequestHandler<DeleteExpenseCommand, DeleteExpenseResponse>
    {
        private readonly FinancialTrackerDbContext _dbContext;

        public DeleteExpenseHandler(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeleteExpenseResponse> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);

            if (expense is null)
            {
                throw new InvalidOperationException($"Expense with id {request.Id} not found");
            }

            expense.IsDeleted = true;
            _dbContext.Expenses.Update(expense);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteExpenseResponse(true, $"Expense with id {request.Id} deleted successfully");
        }
    }
}
