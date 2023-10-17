using Gambeling.WebAPI.DataTransfering.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using WebAPI.Tests.Base;

namespace WebAPI.Tests;

public class UsersControllerTests : BaseEndpointTests, IClassFixture<CustomWebApplicationFactory>
{
    HttpClient _client;

    public UsersControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
        _client = Factory.CreateClient();
        _client.BaseAddress = new Uri("https://localhost:7044");
    }

    [Fact]
    public async Task CreateCustomer_CustomerHasEmptyEmailAddress_ExceptionThrown()
    {
        UserDto userDto = new() { UserName = "UserName", Password = "password" };

        var stringContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

        Func<Task> result = async () => await _client.PostAsJsonAsync(
           "api/users", userDto);

        await Assert.ThrowsAsync<InvalidOperationException>(result);
    }
}
