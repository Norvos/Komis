using FluentAssertions;
using Komis.Infrastructure.Commands.User;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Komis.Integration.Test.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
       
        [Fact]
        public async Task Given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = $"{RandomString(5)}@email.com",
                Username = RandomString(5),
                Password = "secret"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("http://localhost/Car/AddNewCarFromJSON", payload);


            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

        private static string RandomString(int range)
        {
            var chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, range)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray());

            return result;
        }
    }
}
