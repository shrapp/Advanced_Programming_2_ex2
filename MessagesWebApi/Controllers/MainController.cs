using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessagesApp.Services;
using MessagesApp.Models;


namespace MessagesWebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public class ApiFormat
        {
            public string? from { get; set; }
            public string? to { get; set; }
            public string? content { get; set; }
            public string? server { get; set; }
        }

        AppService service = AppService.CreateAppService();

        [HttpGet("contacts", Name = "GetContacts")]
        public List<Json_Contact> GetContacts(string user)
        {
            // return all contacts of the connected user in JSON
            if (service.ApiGetContacts(user).Count > 0)
            {
                return service.ApiGetContacts(user);
            }
            // find a way to send error
            return null;
        }

        [HttpGet("contacts/{id}", Name = "GetContact")]
        public Json_Contact? GetContact(string user, string id)
        {
            if(service.ApiGetContact(user, id) == null)
            {
                // find a way to send error
                return null;
            }
            // return the specific contact of the connected user in JSON
            return service.ApiGetContact(user, id);
        }

        [HttpPost("contacts", Name = "PostContact")]
        public IActionResult AddContact(string user,
                  [FromBody] Json_Contact contact)
        {
            bool s = service.ApiAddContact(user, contact);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpPut("contacts/{id}", Name = "PutContact")]
        public IActionResult PutContact(string user, string id,
                  [FromBody] Json_Contact contact)
        {
            contact.Id = id;
            bool s = service.ApiAddContact(user, contact);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpDelete("contacts/{id}", Name = "DeleteContact")]
        public IActionResult DeleteContact(string user, string id)
        {
            bool s = service.ApiDeleteContact(user, id);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpPost("invitations", Name = "Invitations")]
        public IActionResult Invitations([FromBody] ApiFormat data)
        {
            Json_Contact contact = new Json_Contact();
            contact.Server = data.server;
            contact.Id = data.from;
            bool s = service.ApiAddContact(data.to, contact);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpPost("transfer", Name = "Transfer")]
        public IActionResult Transfer([FromBody] ApiFormat data)
        {
            bool s = service.ApiAddMessage(data.from, data.to, data.content, null);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpGet("contacts/{id}/messages", Name = "GetMessages")]
        public List<Json_Message> GetMessages(string user, string id)
        {
            // return all Messages of the connected user in JSON
            if (service.ApiGetMessages(user, id).Count > 0)
            {
                return service.ApiGetMessages(user, id);
            }
            // find a way to send error
            return null;
        }

        [HttpGet("contacts/{contact}/messages/{id}", Name = "GetMessage")]
        public Json_Message GetMessage(string user, string contact ,int id)
        {
            if (service.ApiGetMessage(user,contact, id) == null)
            {
                // find a way to send error
                return null;
            }
            // return the specific contact of the connected user in JSON
            return service.ApiGetMessage(user, contact, id);
        }

        [HttpDelete("contacts/{contact}/messages/{id}", Name = "DeleteMessage")]
        public IActionResult DeleteMessage(string user, string contact, int id)
        {
            bool s = service.ApiDeleteMessage(user,contact, id);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpPost("contacts/{id}/messages", Name = "PostMessage")]
        public IActionResult PostMessage(string user, string id,
                  [FromBody] ApiFormat content)
        {
            bool s = service.ApiAddMessage(user, id, content.content, null);
            if (s) { return Ok(); };
            return BadRequest();
        }

        [HttpPut("contacts/{contact}/messages/{id}", Name = "PutMessage")]
        public IActionResult PostMessage(string user, string contact, int id,
                  [FromBody] ApiFormat content)
        {
            bool s = service.ApiAddMessage(user, contact, content.content, id);
            if (s) { return Ok(); };
            return BadRequest();
        }
    }
}
