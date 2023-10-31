using Gambeling.WebAPI.DataTransfering.Dtos;
using Infrastracture.Exceptions;
using System.Net.Http.Json;
using WebAPI.Tests.Base;

namespace WebAPI.Tests;

public class AuthenticationControllerTests : BaseEndpointTests, IClassFixture<CustomWebApplicationFactory>
{
    readonly HttpClient _client;

    public AuthenticationControllerTests(CustomWebApplicationFactory factory) : base(factory)
    {
        _client = Factory.CreateClient();
        _client.BaseAddress = new Uri("https://localhost:7044");
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public async Task GetToken_UserNameIsNotValid_MissingRequiredPropertyExceptionIsThrown(string userName)
    {
        UserDto userDto = new() { UserName = userName, Password = "AnotherPassword" };

        async Task Result() => await _client.PostAsJsonAsync(
           "api/authentication/gettoken", userDto);

        await Assert.ThrowsAsync<MissingRequiredPropertyException>(Result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public async Task GetToken_PasswordIsNotValid_MissingRequiredPropertyExceptionIsThrown(string password)
    {
        UserDto userDto = new() { UserName = "AnotherUser", Password = password };

        async Task Result() => await _client.PostAsJsonAsync(
           "api/authentication/gettoken", userDto);

        await Assert.ThrowsAsync<MissingRequiredPropertyException>(Result);
    }

    [Fact]
    public async Task GetToken_UserDoesNotExist_EntityNotFoundExceptionIsThrown()
    {
        UserDto userDto = new() { UserName = "AnotherUser", Password = "AnotherPassword" };

        async Task Result() => await _client.PostAsJsonAsync(
           "api/authentication/gettoken", userDto);

        await Assert.ThrowsAsync<EntityNotFoundException>(Result);
    }

    [Fact]
    public async Task GetToken_UserExists_TokenIsReturned()
    {
        UserDto userDto = new() { UserName = "UserName", Password = "password" };

        HttpResponseMessage response = await _client.PostAsJsonAsync(
           "api/authentication/gettoken", userDto);

        string result = response.Content.ReadAsStringAsync().Result;
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
    }
}
