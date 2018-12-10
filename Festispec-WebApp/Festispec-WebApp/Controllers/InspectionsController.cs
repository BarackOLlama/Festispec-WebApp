using AutoMapper;
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
    public class InspectionsController: ControllerBase
    {
        private readonly IInspectionService _inspectionService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public InspectionsController(IInspectionService inspectionService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _inspectionService = inspectionService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetInspections()
        {
            var inspections = _inspectionService.GetAll();

            return Ok(inspections);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetInspectionById(int id)
        {
            var inspection = _inspectionService.GetById(id);
            return Ok(inspection);
        }
        [AllowAnonymous]
        [HttpGet("ok")]
        public IActionResult Test()
        {
            var isd  = _inspectionService.Test();
            return Ok(isd);
        }
        
        
        [AllowAnonymous]
        [HttpGet("test/{id}")]
        public IActionResult GetInspectionByInspectorId(int id)
        {
            var inspection = _inspectionService.GetInspectionsByInspectorId(id);
            return Ok(inspection);
        }

//        [AllowAnonymous]
//        [HttpGet(nameof(GetInspectorInspections) + "/{inspectorId}")]
//        public IActionResult GetInspectorInspections(int inspectorId)
//        {
//            var isd  = _inspectionService.GetByInspectorId(inspectorId);
//            return Ok(isd);
//        }

        
    }
    

    
}