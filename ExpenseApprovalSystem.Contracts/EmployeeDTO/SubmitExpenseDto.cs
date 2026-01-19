using ExpenseApprovalSystem.Contracts.Enums;

namespace ExpenseApprovalSystem.Contracts.EmployeeDTO
{
    public class SubmitExpenseDto
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
