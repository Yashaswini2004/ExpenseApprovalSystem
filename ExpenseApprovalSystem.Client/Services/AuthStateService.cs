public class AuthStateService
{
    public bool IsLoggedIn { get; private set; }
    public int EmployeeId { get; private set; }
    public string? UserName { get; private set; }
    public string? Role { get; private set; }

    public event Action? OnChange;

    public void Login(int employeeId, string userName, string role)
    {
        IsLoggedIn = true;
        EmployeeId = employeeId;
        UserName = userName;
        Role = role;
        NotifyStateChanged();
    }

    public void Logout()
    {
        IsLoggedIn = false;
        EmployeeId = 0;
        UserName = null;
        Role = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
