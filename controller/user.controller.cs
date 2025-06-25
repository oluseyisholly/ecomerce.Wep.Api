using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.IService;
using EcommerceWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        // GET: api/sample
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaginatedAllUsers([FromQuery] PaginationQuery query)
        {
            var users = await _userService.GetPaginatedAllUsers(query);
            return Ok(users);
        }

        // GET: api/sample
        [HttpGet("paginated")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/sample
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LogIn()
        {
            var data = _userService.GetAllUsers();
            return Ok(data);
        }

        // GET: api/sample/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var item = new { Id = id, Name = $"Item {id}" };
            return Ok(item);
        }

        // POST: api/sample
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var data = await _userService.CreateUser(createUserDto);
            return Ok(data);
        }
    }

    // Sample Data Transfer Object (DTO)
}
