using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hello.Models;

namespace hello.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        // GET api/blogs
        [HttpGet]
        public IActionResult GetAll()
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

        // GET api/blogs/1
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Single(b => b.BlogId == id);
                return new OkObjectResult(blog);
            }
        }

        // POST api/blogs
        [HttpPost]
		public IActionResult PostOne([FromBody]Blog body)
		{
            using (var db = new BloggingContext())
            {
			    db.Blogs.Add(new Blog { Url = body.Url });
                var count = db.SaveChanges();
                return new OkObjectResult(string.Format("{0} records saved to database", count));
            }
		}

        // PUT api/blogs/1
		[HttpPut("{id}")]
		public IActionResult PutOne(int id, [FromBody]Blog body)
		{
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Single(b => b.BlogId == id);
                blog.Url = body.Url;
                
                var count = db.SaveChanges();
                return new OkObjectResult(string.Format("{0} records saved to database", count));
            }
		}
    }
}