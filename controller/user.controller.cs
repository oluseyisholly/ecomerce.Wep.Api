using EcommerceWebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET: api/sample
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = new[]
            {
                new { Id = 1, Name = "Item One" },
                new { Id = 2, Name = "Item Two" },
                new { Id = 3, Name = "Item Three" },
            };

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
