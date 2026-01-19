using ExpenseApprovalSystem.API.Data;
using ExpenseApprovalSystem.API.Models;
using ExpenseApprovalSystem.Contracts.AdminDTO;
using ExpenseApprovalSystem.Contracts.EmployeeDTO;
using ExpenseApprovalSystem.Contracts.Enums;

namespace ExpenseApprovalSystem.API.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }


  public Expense SubmitExpense(SubmitExpenseDto dto, int employeeId)
{
    var expense = new Expense
    {
        Title = dto.Title,
        Amount = dto.Amount,
        Category = dto.Category,
        ExpenseDate = dto.ExpenseDate,
        EmployeeId = employeeId,
        CreatedDate = DateTime.UtcNow
    };

 
    if (dto.Amount < 500)
    {
        expense.Status = ExpenseStatus.Rejected;
        expense.AdminRemarks = "Auto-rejected: Amount below ₹500";
    }
    else
    {
        expense.Status = ExpenseStatus.Pending;
    }

    _context.Expenses.Add(expense);
    _context.SaveChanges();

    return expense;
}

  public List<Expense> GetExpensesByEmployee(int employeeId)
    {
            return _context.Expenses
                .Where(e => e.EmployeeId == employeeId)
                .OrderByDescending(e => e.CreatedDate)
                .ToList();
    }

        public List<Expense> GetAllExpenses()
        {
            return _context.Expenses
                .OrderByDescending(e => e.CreatedDate)
                .ToList();
        }

        public Expense ApproveExpense(int id, string? remarks)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id)
                ?? throw new Exception("Expense not found");

            expense.Status = ExpenseStatus.Approved;
            expense.AdminRemarks = remarks;

            _context.SaveChanges();
            return expense;
        }

        public Expense RejectExpense(int id, string? remarks)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id)
                ?? throw new Exception("Expense not found");

            expense.Status = ExpenseStatus.Rejected;
            expense.AdminRemarks = remarks;

            _context.SaveChanges();
            return expense;
        }

   

      public AdminDashboardDto GetAdminDashboardData()
{
    var expenses = _context.Expenses.ToList();

    var startOfWeek = DateTime.Today.AddDays(
    DayOfWeek.Monday - DateTime.Today.DayOfWeek
);


    return new AdminDashboardDto
    {
        PendingCount = expenses.Count(e => e.Status == ExpenseStatus.Pending),
        ApprovedCount = expenses.Count(e => e.Status == ExpenseStatus.Approved),
        RejectedCount = expenses.Count(e => e.Status == ExpenseStatus.Rejected),

        WeeklyTotalExpense = expenses
            .Where(e => e.Status == ExpenseStatus.Approved &&
                        e.ExpenseDate >= startOfWeek)
            .Sum(e => e.Amount),

        AverageByCategory = expenses
            .Where(e => e.Status == ExpenseStatus.Approved)
            .GroupBy(e => e.Category)
            .Select(g => new CategoryAverageDto
            {
                Category = g.Key,
                AverageAmount = g.Average(x => x.Amount)
            })
            .ToList(),

        MostExpenseCategory = expenses
            .Where(e => e.Status == ExpenseStatus.Approved)
            .GroupBy(e => e.Category)
            .Select(g => new CategoryTotalDto
            {
                Category = g.Key,
                TotalAmount = g.Sum(x => x.Amount)
            })
            .OrderByDescending(x => x.TotalAmount)
            .FirstOrDefault(),
        PendingExpenses = (
            from e in _context.Expenses
            join u in _context.Users
                on e.EmployeeId equals u.Id
            where e.Status == ExpenseStatus.Pending
            select new AdminPendingExpenseDto
            {
                ExpenseId = e.Id,
                EmployeeName = u.Name,
                Category = e.Category,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                Status = e.Status
            }
        ).ToList()
    };
}

    }
}
