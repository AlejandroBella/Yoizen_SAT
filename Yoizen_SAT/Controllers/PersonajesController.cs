using Microsoft.AspNetCore.Mvc;
using Yoizen.Business.Entities;
using Yoizen.Business.Services;
using Yoizen.Data.Entities;

namespace Yoizen_SAT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonajesController : ControllerBase
    {
        private readonly ILogger<PersonajesController> _logger;
        private readonly PersonajeService personajeService;

        public PersonajesController(ILogger<PersonajesController> logger, PersonajeService personajeService)
        {
            _logger = logger;
            this.personajeService = personajeService;
        }
        [HttpGet]
        public IActionResult Get(string name, int limit = 20, int page = 1)
        {
            try
            {
                var result = personajeService.GetByName(name, new PagingParameters { PageIndex = page, PageLimit = limit });
                
                if(result.TotalDocs == 0)
                    return NotFound("recurso no encontrado");

                return Ok(result);
            }
            catch (KeyNotFoundException Kex)
            {
                return BadRequest(Kex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error executing the request, please contact Admin.{Environment.NewLine}{ex.Message}");
            }
        }
    }
}