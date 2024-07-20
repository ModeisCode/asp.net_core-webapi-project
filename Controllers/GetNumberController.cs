using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetNumberController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public GetNumberController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("users");
            _users = database.GetCollection<User>("usersInfo");
        }


        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _users.Find(_ => true).ToListAsync();
        }

        // GET api/<GetNumberController>/5
        [HttpGet("{age}")]
        public async Task<ActionResult<User>> Get(int age)
        {
            var filter = Builders<User>.Filter.Eq(user => user.age, age);
            var user = await _users.Find(filter).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<GetNumberController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetNumberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetNumberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
