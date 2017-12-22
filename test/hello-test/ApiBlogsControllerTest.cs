using System.Threading.Tasks;
using hello.Controllers;
using hello.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace hello_test
{
    public class ApiBlogsControllerTest
    {
        [Fact]
        public void Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var controller = new BlogsController(new BloggingContext());
            controller.ModelState.AddModelError("error","some error");

            // Act
            var result = controller.PostOne(body: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}