
using FinancialTracker.Data;
using FinancialTracker.Features.Expense.CreateExpense;
using FinancialTracker.Features.Expense.GetExpenseById;
using FinancialTracker.Features.Expense.ListExpenses;
using FinancialTracker.Features.Expense.UpdateExpense;
using FinancialTracker.Features.Expense.DeleteExpense;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FinancialTrackerDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("default"))
);

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapCreateExpenseEndpoint();
app.MapGetExpenseByIdEndpoint();
app.MapListExpensesEndpoint();
app.MapUpdateExpenseEndpoint();
app.MapDeleteExpenseEndpoint();

app.Run();

