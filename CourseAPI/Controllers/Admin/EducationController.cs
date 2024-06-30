using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Educations;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseAPI.Controllers.Admin
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;
        private readonly ILogger<EducationController> _logger;

        public EducationController(IEducationService educationService,
                              ILogger<EducationController> logger)
        {
            _educationService = educationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all method is working");
            return Ok(await _educationService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {
            await _educationService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _educationService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _educationService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EducationEditDto request)
        {
            await _educationService.EditAsync(id, request);
            return Ok(new { response = "Data successfully updated" });
        }
    }
}
