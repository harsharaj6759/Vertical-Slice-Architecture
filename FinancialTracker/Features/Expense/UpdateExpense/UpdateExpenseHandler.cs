using FinancialTracker.Data;
using MediatR;

namespace FinancialTracker.Features.Expense.UpdateExpense
{
    public sealed class UpdateExpenseHandler : IRequestHandler<UpdateExpenseCommand, UpdateExpenseResponse>
    {
        private readonly FinancialTrackerDbContext _dbContext;

        public UpdateExpenseHandler(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdateExpenseResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _dbContext.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);

            if (expense is null)
            {
                throw new InvalidOperationException($"Expense with id {request.Id} not found");
            }

            expense.Name = request.Name;
            expense.Category = request.Category;
            expense.Amount = request.Amount;

            _dbContext.Expenses.Update(expense);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateExpenseResponse(
                expense.Id,
                expense.Name,
                expense.Category.ToString(),
                expense.Amount
            );
        }
    }
}
