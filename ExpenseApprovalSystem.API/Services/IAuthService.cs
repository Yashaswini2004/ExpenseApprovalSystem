using ExpenseApprovalSystem.Contracts.AuthDTO;

public interface IAuthService
{
    void Register(RegisterDto dto);
    LoginResponseDto Login(LoginDto dto);
}
