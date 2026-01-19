using ExpenseApprovalSystem.API.Services;
using ExpenseApprovalSystem.Contracts.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApprovalSystem.API.Controllers
{
    [ApiController]
    [Route("api/employee/expenses")]
    public class EmployeeExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public EmployeeExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

    
        [HttpPost]
        public IActionResult SubmitExpense(
            [FromBody] SubmitExpenseDto dto,
            [FromQuery] int employeeId  
        )
        {
            var result = _expenseService.SubmitExpense(dto, employeeId);
            return Ok(result);
        }

      
        [HttpGet("my")]
        public IActionResult GetMyExpenses([FromQuery] int employeeId)
        {
            var expenses = _expenseService.GetExpensesByEmployee(employeeId);
            return Ok(expenses);
        }
    }
}
