using DevFreela.API.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IValidationService _validationService;
        public ProjectsController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            try
            {
                _validationService.Validate(model);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Errors = ex.Errors });
            }

            return CreatedAtAction(nameof(GetById), new { id = 1 }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comment")]
        public IActionResult Comment(int id, CreateProjectCommentInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, null);
        }
    }
}
