using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hello.Services;
using hello.Models;

namespace hello.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private readonly BlogService _blogService;

        public BlogsController(BloggingContext bloggingContext)
        {
            _blogService = new BlogService(bloggingContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(_blogService.AllBlogs());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return new OkObjectResult(_blogService.FindByBlogId(id));
        }

        [HttpPost]
		public IActionResult PostOne([FromBody]Blog body)
		{
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            _blogService.Add(body.Url);
            
            return new OkObjectResult("saved to database");
        }
    }
}