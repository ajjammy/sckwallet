using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using hello_ewallet.Models;
using System.Threading.Tasks;

namespace hello_ewallet.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        // GET api/messages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Message1", "Message2" };
        }

        // GET api/messages/1
        [HttpGet("{id}")]
        public IActionResult FindMessages(int id)
        {
            using (var db = new AppDb())
			{
				db.Connection.Open();
				var query = new MessagesQuery(db);
				var result = query.FindOne(id);
				if (result == null)
					return new NotFoundResult();
				return new OkObjectResult(result);
			}
        }
    }
}