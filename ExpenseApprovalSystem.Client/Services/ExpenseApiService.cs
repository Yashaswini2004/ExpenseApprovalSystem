using ExpenseApprovalSystem.Contracts.AdminDTO;
using ExpenseApprovalSystem.Contracts.EmployeeDTO;
using System.Net.Http.Json;

namespace ExpenseApprovalSystem.Client.Services
{
    public class ExpenseApiService
    {
        private readonly HttpClient _http;

        public ExpenseApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task SubmitExpenseAsync(SubmitExpenseDto dto, int employeeId)
        {
            await _http.PostAsJsonAsync(
                $"api/employee/expenses?employeeId={employeeId}",
                dto
            );
        }

   
        public async Task<List<ExpenseDto>> GetMyExpensesAsync(int employeeId)
        {
            return await _http.GetFromJsonAsync<List<ExpenseDto>>(
                $"api/employee/expenses/my?employeeId={employeeId}"
            ) ?? new List<ExpenseDto>();
        }

      
        public async Task<List<ExpenseDto>> GetAllExpensesAsync()
        {
            return await _http.GetFromJsonAsync<List<ExpenseDto>>(
                "api/admin/expenses"
            ) ?? new List<ExpenseDto>();
        }

        public async Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            return await _http.GetFromJsonAsync<AdminDashboardDto>(
                "api/admin/expenses/dashboard"
            )!;
        }

        public async Task ApproveExpenseAsync(int id, string? remarks)
        {
            await _http.PutAsJsonAsync(
                $"api/admin/expenses/{id}/approve", remarks
            );
        }

        public async Task RejectExpenseAsync(int id, string? remarks)
        {
            await _http.PutAsJsonAsync(
                $"api/admin/expenses/{id}/reject", remarks
            );
        }
    }
}
