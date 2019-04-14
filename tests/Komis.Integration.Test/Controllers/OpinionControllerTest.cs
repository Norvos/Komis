using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Komis.Integration.Test.Controllers
{
    public class OpinionControllerTest : ControllerTestsBase
    {
        [Fact]
        public async Task Unauthorized_entry__should_be_redirect()
        {
            var response = await Client.GetAsync("Opinion");

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

    }
}
