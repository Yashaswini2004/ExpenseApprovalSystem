using ExpenseApprovalSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/admin/expenses")]
    public class AdminExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public AdminExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

       
        [HttpGet]
        public IActionResult GetAllExpenses()
        {
            var expenses = _expenseService.GetAllExpenses();
            return Ok(expenses);
        }

        [HttpPut("{id}/approve")]
        public IActionResult ApproveExpense(int id, [FromBody] string? remarks)
        {
            var result = _expenseService.ApproveExpense(id, remarks);
            return Ok(result);
        }

        
        [HttpPut("{id}/reject")]
        public IActionResult RejectExpense(int id, [FromBody] string? remarks)
        {
            var result = _expenseService.RejectExpense(id, remarks);
            return Ok(result);
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var result = _expenseService.GetAdminDashboardData();
            return Ok(result);
        }
    }
}
