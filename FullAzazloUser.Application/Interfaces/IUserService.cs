using FullAzazloUser.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAzazloUser.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task CreateUser(UserDto userDto);
        Task UpdateUser(UserDto userDto);
        Task DeleteUser(int id);
    }
}
