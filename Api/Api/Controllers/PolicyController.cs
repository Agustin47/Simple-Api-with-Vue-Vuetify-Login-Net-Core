
namespace Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts.Services;
    using Contracts.RequestResponseContracts;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly IGetServices _getServices;

        public PolicyController(IGetServices getServices)
        {
            _getServices = getServices;
        }

        // GET api/client
        [HttpGet]
        public IActionResult Get()
        {
            var response = _getServices.GetClientPolicies(new GetClientPoliciesRequest {  });
            return Ok(response.Policies);
        }

        // GET api/client/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var response = _getServices.GetClientPolicies(new GetClientPoliciesRequest { UserName = name});
            return Ok(response.Policies);
        }

        // GET api/client/5
        [HttpGet("GetUser/{policyId}")]
        public IActionResult GetUser(string policyId)
        {
            var response = _getServices.GetUserByPolicies(new GetClientByPoliciesRequest { PolicyId = policyId });
            return Ok(response.Clients);
        }

        // POST api/client
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
