using System.Collections.Generic;
using System.Linq;
using hello.Models;
using Microsoft.EntityFrameworkCore;

namespace hello.Services
{
    public class BlogService
    {
        private BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context;
        }

        public void Add(string url)
        {
            var blog = new Blog { Url = url };
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public IEnumerable<Blog> Find(string term)
        {
            return _context.Blogs
                .Where(b => b.Url.Contains(term))
                .OrderBy(b => b.Url)
                .ToList();
        }

        public IEnumerable<Blog> AllBlogs()
        {
            return _context.Blogs
                .ToList();
        }

        public Blog FindByBlogId(int blogId)
        {
            return _context.Blogs
                .Where(b => b.BlogId.Equals(blogId))
                .Single();
        }
    }
}