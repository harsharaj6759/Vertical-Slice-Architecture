using FinancialTracker.Domain;
using FinancialTracker.Data;
using MediatR;


namespace FinancialTracker.Features.Expense.CreateExpense
{
    public sealed class CreateExpenseHandler : IRequestHandler<CreateExpenseCommand, CreateExpenseResponse>
    {
        private readonly FinancialTrackerDbContext _dbContext;

        public CreateExpenseHandler(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateExpenseResponse> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Domain.Expense
            {
                Name = request.Name,
                Category = request.Category,
                Amount = request.Amount
            };

            _dbContext.Expenses.Add(expense);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateExpenseResponse(
                expense.Id,
                expense.Name,
                expense.Category.ToString(),
                expense.Amount
            );
        }
    }
}
