using ExpenseApprovalSystem.Contracts.AuthDTO;
using System.Net.Http.Json;

namespace ExpenseApprovalSystem.Client.Services
{
    public class AuthApiService
    {
        private readonly HttpClient _http;

        public AuthApiService(HttpClient http)
        {
            _http = http;
        }

      public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
{
    var response = await _http.PostAsJsonAsync("api/auth/login", dto);

   
    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
    {
        return null;
    }

  
    if (!response.IsSuccessStatusCode)
    {
        var error = await response.Content.ReadAsStringAsync();
        throw new Exception(string.IsNullOrWhiteSpace(error)
            ? "Login failed. Please try again."
            : error);
    }

    return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
}


        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/register", dto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
