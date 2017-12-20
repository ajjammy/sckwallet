using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hello.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        // GET api/blogs
        [HttpGet]
        public IActionResult Get()
        {
            using (var db = new BloggingContext())
            {
                var blogs = new List<Blog>();
                foreach (var blog in db.Blogs)
                {
                    blogs.Add(blog);
                }
                return new OkObjectResult(blogs);
            }
        }

        // POST api/blogs
        [HttpPost]
		public IActionResult Post([FromBody]string url)
		{
            using (var db = new BloggingContext())
            {
			    db.Blogs.Add(new Blog { Url = url });
                return new OkObjectResult(url);
            }
		}
    }
}