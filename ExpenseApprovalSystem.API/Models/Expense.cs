using System.ComponentModel.DataAnnotations;
using ExpenseApprovalSystem.Contracts.Enums;

namespace ExpenseApprovalSystem.API.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, 1000000, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public ExpenseCategory Category { get; set; }

        [Required(ErrorMessage = "Expense date is required")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;

        [StringLength(250, ErrorMessage = "Admin remarks cannot exceed 250 characters")]
        public string? AdminRemarks { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
