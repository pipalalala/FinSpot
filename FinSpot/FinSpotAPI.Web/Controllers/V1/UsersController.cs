using Asp.Versioning;
using AutoMapper;
using FinSpotAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ApplicationModels = FinSpotAPI.Application.Models;
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
        private readonly IUserService _userServcice;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IMapper mapper,
            IUserService userServcice,
            ILogger<UsersController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userServcice = userServcice ?? throw new ArgumentNullException(nameof(userServcice));
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult> SignUpAsync(Inbound.UserSignUpModel userSignUpModel)
        {
            var model = _mapper.Map<ApplicationModels.Users.UserSignUpModel>(userSignUpModel);

            await _userServcice.SignUpAsync(model);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult> SignUpAsync(Inbound.UserSignInModel uerSignInModel)
        {
            var result = await _userServcice.SignInAsync(uerSignInModel.Email, uerSignInModel.Password);

            return Ok(_mapper.Map<Outbound.UserSignInModel>(result));
        }
    }
}
