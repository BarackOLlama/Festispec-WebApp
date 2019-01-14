using AutoMapper;
using Festispec_WebApp.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Festispec_WebApp.Helpers;
using Festispec_WebApp.Services;

namespace Festispec_WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _questionnaireService = questionnaireService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetQuestionnaires()
        {
            var questionnaires = _questionnaireService.GetAll();

            return Ok(questionnaires);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetQuestionnaire(int id)
        {
            var questionnaire = _questionnaireService.GetById(id);
            return Ok(questionnaire);
        }

        [AllowAnonymous]
        [HttpGet("inspection/{inspectionId}")]
        public IActionResult GetQuestionnaireByInspection(int inspectionId)
        {
            var questionnaire = _questionnaireService.GetByInspection(inspectionId);
            return Ok(questionnaire);
        }

      
    }
}