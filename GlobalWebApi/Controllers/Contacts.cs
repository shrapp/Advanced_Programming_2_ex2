using Microsoft.AspNetCore.Mvc;

namespace GlobalWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class Contacts : ControllerBase
    {

        private readonly ILogger<Contacts> _logger;

        class Contact
        {
            public string id;
            public string name;
            public string server;
            public string last;
            public string lastdate;
        }
     
        
     
  
        public Contacts(ILogger<Contacts> logger)
        {
            _logger = logger;
        }

        [HttpGet("contacts/{user}", Name = "GetContacts")]
        public IActionResult GetContacts(string user)
        {
            Contact bob = new Contact();
            bob.id = "bob";
            bob.name = "Bobby";
            bob.server = "localhost:7265";
            bob.last = "i know waht you did last summer";
            bob.lastdate = "2022-04-24T08:00:03.5994326";

            Contact alice = new Contact();
            bob.id = "alice";
            bob.name = "Alicia";
            bob.server = "localhost:7266";
            bob.last = "any last words?";
            bob.lastdate = "2022-04-24T08:00:03.5994326";

            // return all contacts of the connected user in JSON
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact()
        {
            // return the contact of the connected user in JSON
            return null;
        }
    }
}