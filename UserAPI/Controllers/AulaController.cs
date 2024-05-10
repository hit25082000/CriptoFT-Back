using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private AulaService _aulaService;

        public AulaController(AulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpGet("/aulas-user")]
        [HttpGet]
        public JsonResult GetAulasUser(int userId)
        {
            List<Aula> aulas = _aulaService.GetAulas(userId);

            return new JsonResult(aulas);
        }

        [HttpPost]
        public bool AddAula([FromQuery] Aula aula, int userId)
        {
            Result result = _aulaService.AddAula(aula, userId);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool EditAula([FromQuery] Aula aula, int userId)
        {
            Result result = _aulaService.EditAula(aula);
            if (result.IsFailed) return false;
            return true;
        }
    }
}
