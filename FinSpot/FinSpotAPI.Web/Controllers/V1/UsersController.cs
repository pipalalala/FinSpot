using Asp.Versioning;
using AutoMapper;
using FinSpotAPI.Application.Services.Interfaces;
using FinSpotAPI.Web.Models.V1.Users.Inbound;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ApplicationModels = FinSpotAPI.Application.Models;

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
        public async Task<ActionResult> SignUpAsync(UserSignUpModel userSignUpModel)
        {
            var model = _mapper.Map<ApplicationModels.UserService.UserSignUpModel>(userSignUpModel);

            await _userServcice.SignUpAsync(model);

            return Ok();
        }
    }
}
