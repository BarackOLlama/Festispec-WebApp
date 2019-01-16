using AutoMapper;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Helpers;
using Festispec_WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Festispec_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AnswerController(IAnswerService answerService, IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _answerService = answerService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AnswerQuestion([FromBody] AnswerDto answerDto)
        {
            return Ok(_answerService.Save(answerDto));
        }
    }
}