
namespace Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts.Services;
    using Contracts.RequestResponseContracts;
    using Newtonsoft.Json;
    using Api.Models;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "user,admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IGetServices _getServices;

        public ClientController(IGetServices getServices)
        {
            _getServices = getServices;
        }

        // GET api/client
        [HttpGet]
        public IActionResult Get()
        {
            var response = _getServices.GetClient(new GetClientRequest { });
            return Ok(response.Clients);
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _getServices.GetClient(new GetClientRequest { Id = id});
            return Ok(response.Clients);
        }

        

        // POST api/client
        [HttpPost]
        public IActionResult Post([FromBody] ClientViewModel value)
        {
            return Ok();
        }

        // PUT api/client/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        [HttpPut]
        public IActionResult Put([FromBody] ClientViewModel value)
        {
            return Ok();
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }

    }
}
