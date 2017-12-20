using System;
using Xunit;

using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using Newtonsoft.Json.Linq;
using hello.Models;

namespace hello_test
{
    public class ValuesControllerTest
    {
        private readonly HttpClient client;
        private readonly TestServer server;

        public ValuesControllerTest() {
            server = new TestServer(
                new WebHostBuilder().UseStartup<Startup>()
            );
            client = server.CreateClient();
        }

        [Fact]
        public async void size_of_result_should_be_2()
        {
            var response = await client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            dynamic collection = JArray.Parse(await response.Content.ReadAsStringAsync());
            Assert.Equal(2, collection.Count);
        }
    }
}
