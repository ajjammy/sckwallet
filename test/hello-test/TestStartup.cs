using hello;
using hello.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hello_test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            // Configure services for Test environment
            services.AddMvc();
            services.AddDbContext<BloggingContext>(options => options.UseInMemoryDatabase("Data Source=:memory:"));
        }
    }
}