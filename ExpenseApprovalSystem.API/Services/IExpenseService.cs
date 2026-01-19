using ExpenseApprovalSystem.API.Models;
using ExpenseApprovalSystem.Contracts.AdminDTO;
using ExpenseApprovalSystem.Contracts.EmployeeDTO;

namespace ExpenseApprovalSystem.API.Services
{
    public interface IExpenseService
    {

        Expense SubmitExpense(SubmitExpenseDto dto, int employeeId);

        List<Expense> GetExpensesByEmployee(int employeeId);

   

        List<Expense> GetAllExpenses();

        Expense ApproveExpense(int id, string? remarks);

        Expense RejectExpense(int id, string? remarks);

        AdminDashboardDto GetAdminDashboardData();
    }
}
