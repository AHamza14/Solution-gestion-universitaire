using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionGestionUniversitaire.Core.Entities;
using SolutionGestionUniversitaire.Core.Interfaces;

namespace SolutionGestionUniversitaire.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : ControllerBase
    {
        private readonly IGestionUniversitaireService _service;

        public ProfesseurController(IGestionUniversitaireService service)
        {
            _service = service;
        }

        [HttpPost("AjouterProf")]
        public async Task<IActionResult> AddAsync([FromBody] Professeur prof)
        {
            if (prof == null)
                return BadRequest();
            await _service.AddProfesseur(prof);
            return Ok();
        }

    }
}
