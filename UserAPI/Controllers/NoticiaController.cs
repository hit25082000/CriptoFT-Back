using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private NoticiaService _noticiaService;

        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("ObterNoticias")]
        public JsonResult GetNoticias()
        {
            List<Noticia> noticias = _noticiaService.GetNoticias();

            return new JsonResult(noticias);
        }

        [HttpPost]
        [Route("AddNoticia")]
        public bool AddNoticia([FromBody] Noticia noticia)
        {
            Result result = _noticiaService.AddNoticia(noticia);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool EditNoticia([FromQuery] Noticia noticia)
        {
            Result result = _noticiaService.EditNoticia(noticia);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool RemoveNoticia(int noticiaId)
        {
            Result result = _noticiaService.RemoveNoticia(noticiaId);
            if (result.IsFailed) return false;
            return true;
        }
    }
}
