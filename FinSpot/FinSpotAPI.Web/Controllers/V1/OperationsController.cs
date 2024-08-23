using Asp.Versioning;
using AutoMapper;
using FinSpotAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ApplicationModels = FinSpotAPI.Application.Models.Operations;
using Inbound = FinSpotAPI.Web.Models.V1.Operations.Inbound;
using Outbound = FinSpotAPI.Web.Models.V1.Operations.Outbound;

namespace FinSpotAPI.Web.Controllers.V1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOperationsService _operationsService;

        public OperationsController(
            IMapper mapper,
            IOperationsService operationsService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _operationsService = operationsService
                ?? throw new ArgumentNullException(nameof(operationsService));
        }

        [HttpPost("addOperation")]
        [ProducesResponseType(typeof(Outbound.OperationModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Outbound.OperationModel>> AddOperationAsync(Inbound.OperationCreateModel createOperationModel)
        {
            var model = _mapper.Map<ApplicationModels.OperationCreateModel>(createOperationModel);

            var result = await _operationsService.AddAsync(model);

            return Ok(_mapper.Map<Outbound.OperationModel>(result));
        }
    }
}
