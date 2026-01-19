using ExpenseApprovalSystem.Contracts.Enums;

namespace ExpenseApprovalSystem.Contracts.EmployeeDTO
{
    public class EmployeeExpenseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public ExpenseStatus Status { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
