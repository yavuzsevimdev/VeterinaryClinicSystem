using VeterinaryClinic.UI.Dtos.User;

namespace VeterinaryClinic.UI.Services.User
{
    public interface IUserService
    {
        Task<UserDto> GetMyProfileAsync();
    }
}
