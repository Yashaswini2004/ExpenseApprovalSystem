using ExpenseApprovalSystem.API.Data;
using ExpenseApprovalSystem.API.Models;
using ExpenseApprovalSystem.Contracts.AuthDTO;
using System;
using System.Linq;

namespace ExpenseApprovalSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public void Register(RegisterDto dto)
        {
            var exists = _context.Users.Any(u => u.Email == dto.Email);
            if (exists)
                throw new Exception("Email already registered");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password, 
                Role = "Employee",
                CreatedDate = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

 public LoginResponseDto? Login(LoginDto dto)
{
    var email = dto.Email.Trim().ToLower();
    var password = dto.Password.Trim();

    var user = _context.Users.FirstOrDefault(u =>
        u.Email.ToLower() == email &&
        u.Password == password);

    if (user == null)
        return null;   

    return new LoginResponseDto
    {
        UserId = user.Id,
        Name = user.Name,
        Role = user.Role
    };
}


    }
}
