using MessagesWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagesWebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("contacts", Name = "GetContacts")]
        public IActionResult GetContacts(string user)
        {
            
            // return all contacts of the connected user in JSON
            return Ok();
        }

        [HttpGet("contacts/{id}", Name = "GetContact")]
        public IActionResult GetContact(string user, string id)
        {

            // return the specific contact of the connected user in JSON
            return Ok();
        }

        [HttpPost("contacts", Name = "PostContact")]
        public IActionResult AddContact(string user,
                  [FromBody] Json_Contact inputModel)
        {
            // return created status
            return Ok();
        }

        [HttpPut("contacts/{id}", Name = "PutContact")]
        public IActionResult PutContact(string user, string id,
                  [FromBody] Json_Contact inputModel)
        {
            // return created status
            return Ok();
        }

        [HttpDelete("contacts/{id}", Name = "DeleteContact")]
        public IActionResult DeleteContact(string user, string id)
        {
            // return delete status
            return Ok();
        }

        [HttpPost("invitations", Name = "Invitations")]
        public IActionResult Invitations([FromBody] Json_Contact inputModel)
        {
            // return ?????
            return Ok();
        }

        [HttpPost("transfer", Name = "Transfer")]
        public IActionResult Transfer([FromBody] Json_Contact inputModel)
        {
            // return ?????
            return Ok();
        }

        [HttpGet("contacts/{id}/messages", Name = "GetMessages")]
        public IActionResult GetMessages(string user, string id)
        {

            // return all messages of the connected user and contact in JSON
            return Ok();
        }

        [HttpGet("contacts/{contact}/messages/{id}", Name = "GetMessage")]
        public IActionResult GetMessage(string user, string contact ,string id)
        {

            // return the message of the connected user and contact in JSON
            return Ok();
        }

        [HttpDelete("contacts/{contact}/messages/{id}", Name = "DeleteMessage")]
        public IActionResult DeleteMessage(string user, string contact, string id)
        {
            // return delete status
            return Ok();
        }

        [HttpPost("contacts/{id}/messages", Name = "PostMessage")]
        public IActionResult PostMessage(string user, string id,
                  [FromBody] string content)
        {
            // return created status
            return Ok();
        }

        [HttpPut("contacts/{contact}/messages/{id}", Name = "PutMessage")]
        public IActionResult PostMessage(string user, string contact, string id,
                  [FromBody] string content)
        {
            // return created status
            return Ok();
        }
    }
}
