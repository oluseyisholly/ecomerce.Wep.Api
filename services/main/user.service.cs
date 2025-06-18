using AutoMapper;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;
using EcommerceWebApi.Repository;
using Microsoft.AspNetCore.Identity;

namespace EcommerceWebApi.Service
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        private readonly IMapper _mapper = mapper;

        public CreateUserDto CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            _userRepository.CreateUser(user);
            return createUserDto;
        }

        public async Task RegisterAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public User GetUsersById()
        {
            throw new NotImplementedException();
        }
    }
}
