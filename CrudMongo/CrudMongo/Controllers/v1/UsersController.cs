using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Entities.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudMongo.Controllers.v1
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBusiness _business;
        public UsersController(IUsersBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _business.GetAllUsers();
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsers([FromBody] Users users )
        {
            var response = await _business.CreateUsers(users);
            return StatusCode(response.Code, response);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateUsers([FromBody] Users users)
        {
            var response = await _business.UpdateUsers(users);
            return StatusCode(response.Code, response);
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteUsers(string id)
        {
            var response = await _business.DeleteUsers(id);
            return StatusCode(response.Code, response);
        }
    }
}
