using MarketData.Models;
using MarketData.Services;
using MarketData.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MarketData.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketDataController : ControllerBase  
    {
        private readonly IFxQuoteService _fxQuoteService;
        private readonly IValidationService _validationService;
        private readonly ILogger<MarketDataController> _logger;

        public MarketDataController(IFxQuoteService fxQuoteService, IValidationService validationService, ILogger<MarketDataController> logger)
        {
            _fxQuoteService = fxQuoteService;
            _validationService = validationService;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] MarketDataContribution contribution)
        {
            //, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviorOptions
            try
            {
                //TODO This needs to be replaced with actual validation service
                var validationContributionResult = _validationService.ValidateMarketDataContribution(contribution);
                var isvalidIdentifier = Guid.TryParse(validationContributionResult.uniqueIdentifier, out Guid parsedIdentifier);

                _logger.LogInformation("Validation Identifier : {ParsedIdentifier}, Validation Success {isSuccess}", parsedIdentifier, validationContributionResult.isSuccess);

                if (!validationContributionResult.isSuccess || !isvalidIdentifier)
                {
                    ModelState.AddModelError("Service Validation", "Validation Service Failed");
                    return ValidationProblem();
                }
                

                if (contribution.MarketDataType != (int)MarketDataType.FxQuote)
                {
                    ModelState.AddModelError("DataType", "Invalid Data Type Requested");
                    return ValidationProblem(ModelState);
                }


                var result = await _fxQuoteService.Create(contribution.FxQuote);
                if (result == null)
                {
                    ModelState.AddModelError("FxQuote Service", "Creation of FX Quote Failed");
                    return ValidationProblem(ModelState);
                }

                else
                    return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Log :", ex.StackTrace);
                return BadRequest();
            }
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FxQuote>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FxQuote>>> GetAll()
        {
            try
            {
                var result = await _fxQuoteService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Log :", ex.StackTrace);
                return BadRequest();
            }
        }

    }
}
