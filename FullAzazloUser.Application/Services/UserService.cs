using AutoMapper;
using FullAzazloUser.Application.DTOs;
using FullAzazloUser.Application.Interfaces;
using FullAzazloUser.Domain.Entities;
using FullAzazloUser.Domain.Interfaces;

namespace FullAzazloUser.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.CreateUserAsync(user);
        }
        public async Task UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUserAsync(user);
        }
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        
    }
}
