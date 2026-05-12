namespace FinancialTracker.Domain
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Expense Name";
        public ExpenseCategory Category { get; set; } = ExpenseCategory.None;
        public double Amount { get; set; }

    }

    public enum ExpenseCategory
    {
        None,
        Grocery,
        Meat,
        Misc,
        Eating_out
    }
}

