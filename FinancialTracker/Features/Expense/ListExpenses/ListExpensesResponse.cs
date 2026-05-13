namespace FinancialTracker.Features.Expense.ListExpenses
{
    public sealed record ExpenseListItemResponse(
        int Id,
        string Name,
        string Category,
        double Amount
    );

    public sealed record ListExpensesResponse(
        ICollection<ExpenseListItemResponse> Expenses,
        int TotalCount,
        int Page,
        int PageSize,
        int TotalPages
    );
}
