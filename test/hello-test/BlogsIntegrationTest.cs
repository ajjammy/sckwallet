using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http.Headers;
using Xunit;
using System.Text;
using Newtonsoft.Json;

namespace hello_test
{
    public class BlogsIntegrationTest
    {
        private readonly HttpClient client;
        private readonly TestServer server;
        private readonly string _ContentType = "application/json";
        

        public BlogsIntegrationTest() {
            server = new TestServer(
                new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<TestStartup>()
            );
            
            client = server.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
        }

        [Fact]
        public async Task when_get_all_blogs_then_returns_ok()
        {
            // Act
            var response = await client.GetAsync("/api/blogs");
            var contents = await response.Content.ReadAsStringAsync();

            // ASSERT
            Assert.True(response.StatusCode == HttpStatusCode.OK, 
            $"Expected OK but received {response.StatusCode}");
        }

        [Fact]
        public async Task when_post_new_blog_then_returns_ok()
        {
            var formData = new Dictionary<string, string>
            {
                {"blogId", "0"},
                {"url", "www.google.com"},
                {"posts", null}    
            };

            HttpRequestMessage postRequest = new HttpRequestMessage(HttpMethod.Post, "api/blogs")
            {
                Content = new StringContent(
                                    JsonConvert.SerializeObject(formData, Formatting.Indented), 
                                    Encoding.UTF8, 
                                    _ContentType)
            };

            var response = await client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();

            // ASSERT
            Assert.True(response.StatusCode == HttpStatusCode.OK, 
            $"Expected OK but received {response.StatusCode}");
        }
    }
}