using System;
using Xunit;

using Newtonsoft.Json.Linq;
using hello;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using hello.Models;
using hello.Services;
using System.Linq;

namespace hello_test
{
    public class BlogsUnitTest
    {
        [Fact]
        public void Add_writes_to_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<BloggingContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new BloggingContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new BloggingContext(options))
                { 
                    var service = new BlogService(context);
                    service.Add("http://sample.com");
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new BloggingContext(options))
                {
                    Assert.Equal(1, context.Blogs.Count());
                    Assert.Equal("http://sample.com", context.Blogs.Single().Url);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void Find_searches_url()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<BloggingContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new BloggingContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Insert seed data into the database using one instance of the context
                using (var context = new BloggingContext(options))
                {
                    context.Blogs.Add(new Blog { Url = "http://sample.com/cats" });
                    context.Blogs.Add(new Blog { Url = "http://sample.com/catfish" });
                    context.Blogs.Add(new Blog { Url = "http://sample.com/dogs" });
                    context.SaveChanges();
                }

                // Use a clean instance of the context to run the test
                using (var context = new BloggingContext(options))
                {
                    var service = new BlogService(context);
                    var result = service.Find("cat");
                    Assert.Equal(2, result.Count());
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
