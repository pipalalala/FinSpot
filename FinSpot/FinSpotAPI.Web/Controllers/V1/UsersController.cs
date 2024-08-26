using Asp.Versioning;
using AutoMapper;
using FinSpotAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ApplicationModels = FinSpotAPI.Application.Models.Users;
using Inbound = FinSpotAPI.Web.Models.V1.Users.Inbound;
using Outbound = FinSpotAPI.Web.Models.V1.Users.Outbound;

namespace FinSpotAPI.Web.Controllers.V1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public UsersController(
            IMapper mapper,
            IUsersService usersService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult> SignUpAsync(Inbound.UserSignUpModel userSignUpModel)
        {
            var model = _mapper.Map<ApplicationModels.UserSignUpModel>(userSignUpModel);

            await _usersService.SignUpAsync(model);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        [ProducesResponseType(typeof(Outbound.UserSignInModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Outbound.UserSignInModel>> SignUpAsync(Inbound.UserSignInModel uerSignInModel)
        {
            var result = await _usersService.SignInAsync(uerSignInModel.Email, uerSignInModel.Password);

            return Ok(_mapper.Map<Outbound.UserSignInModel>(result));
        }

        [HttpDelete("deleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAccountAsync()
        {
            await _usersService.DeleteAccountAsync();

            return Ok();
        }
    }
}
