﻿using Gambeling.Services.Users.Queries;
using Gambeling.WebAPI.DataTransfering.Dtos;
using Gambeling.WebAPI.DataTransfering.ViewModels;
using Infrastracture.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gambeling.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("GetToken")]
        public async Task<ActionResult> GetToken(
            [FromBody] UserDto userDto,
            [FromServices] IQueryHandler<GetTokenByCredentialQuery, string> queryHandler)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            string token = await queryHandler.HandelAsync(
                GetTokenByCredentialQuery.Create(userDto.UserName, userDto.Password));
            return Ok(JsonConvert.SerializeObject(new TokenViewModel { Token = token }));
        }
    }
}
