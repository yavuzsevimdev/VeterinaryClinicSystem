using VeterinaryClinic.UI.Dtos.Account;

namespace VeterinaryClinic.UI.Services.Account
{
    public interface IAccountService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task<bool> RegisterAsync(RegisterDto dto);
    }
}
