using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace FinSpotAPI.Web.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync()
        {
            return await Task.FromResult(Ok("v2"));
        }
    }
}
