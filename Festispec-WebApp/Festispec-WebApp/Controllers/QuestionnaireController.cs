using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Helpers;
using Festispec_WebApp.Models;
using Festispec_WebApp.Services;

namespace Festispec_WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionnaireController: ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public QuestionnaireController(IQuestionnaireService questionnaireService, IMapper mapper, IOptions<AppSettings> appSettings)
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

    }
    

    
}