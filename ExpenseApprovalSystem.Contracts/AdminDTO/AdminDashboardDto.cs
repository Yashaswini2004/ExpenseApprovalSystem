using ExpenseApprovalSystem.Contracts.Enums;

namespace ExpenseApprovalSystem.Contracts.AdminDTO
{
    public class AdminDashboardDto
    {
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RejectedCount { get; set; }

        public decimal WeeklyTotalExpense { get; set; }

        public List<CategoryAverageDto> AverageByCategory { get; set; } = new();

        public CategoryTotalDto? MostExpenseCategory { get; set; }

   
        public List<AdminPendingExpenseDto> PendingExpenses { get; set; } = new();
    }

   
    public class AdminPendingExpenseDto
    {
        public int ExpenseId { get; set; }
        public string EmployeeName { get; set; } = "";
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ExpenseStatus Status { get; set; }
    }

    public class CategoryAverageDto
    {
        public ExpenseCategory Category { get; set; }
        public decimal AverageAmount { get; set; }
    }

    public class CategoryTotalDto
    {
        public ExpenseCategory Category { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
