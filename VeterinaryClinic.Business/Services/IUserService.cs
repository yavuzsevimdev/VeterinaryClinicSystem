using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.Business.Dtos.UserDtos;

namespace VeterinaryClinic.Business.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task AddRoleAsync(string userId, string roleId);
        Task CreateRoleAsync(CreateRoleDto dto);
    }
}
