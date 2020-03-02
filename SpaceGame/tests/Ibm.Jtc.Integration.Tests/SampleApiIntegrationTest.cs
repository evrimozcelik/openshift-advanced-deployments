using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace Cloudy.Integration.Tests
{
    public class SampleIntegrationTest : IClassFixture<WebApplicationFactory<TailSpin.SpaceGame.Web.Startup>>
    {

        private readonly WebApplicationFactory<TailSpin.SpaceGame.Web.Startup> _factory;

        public SampleIntegrationTest(WebApplicationFactory<TailSpin.SpaceGame.Web.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task Response_Should_Return_OK(string url)
        {
            var client = _factory.CreateClient();
            
            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); 

            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
