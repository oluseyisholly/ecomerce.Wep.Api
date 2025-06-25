using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Exceptions;
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

        public async Task<StandardResponse<CreateUserDto>> CreateUser(CreateUserDto createUserDto)
        {
            //check if user exists
            var existingUser = await _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser is not null)
            {
                throw new NotFoundException("try Again Later");
            }

            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.CreateUser(user);

            return new StandardResponse<CreateUserDto>
            {
                Message = "Created Successfully",
                Data = createUserDto,
            };
        }

        public async Task RegisterAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
        }

        public async Task<StandardResponse<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var result = _mapper.Map<List<User>>(users);

            return new StandardResponse<List<User>> { Message = "success", Data = result };
        }

        public async Task<StandardResponse<PaginatedResponse<User>>> GetPaginatedAllUsers(
            PaginationQuery query
        )
        {
            var users = await _userRepository.GetPaginatedAllUsers(query);

            return new StandardResponse<PaginatedResponse<User>>
            {
                Message = "success",
                Data = users,
            };
        }

        public User GetUsersById()
        {
            throw new NotImplementedException();
        }
    }
}
