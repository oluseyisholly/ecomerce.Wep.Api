using EcommerceWebApi.Dto;
using EcommerceWebApi.IService;
using EcommerceWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        // GET: api/sample
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _userService.GetAllUsers();
            return Ok(data);
        }

        // GET: api/sample
        // [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LogIn()
        {
            var data = _userService.GetAllUsers();
            return Ok(data);
        }

        // GET: api/sample/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = new { Id = id, Name = $"Item {id}" };

            return Ok(item);
        }

        // POST: api/sample
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            throw new Exception();
            return Ok(createUserDto);
        }
    }

    // Sample Data Transfer Object (DTO)
}
