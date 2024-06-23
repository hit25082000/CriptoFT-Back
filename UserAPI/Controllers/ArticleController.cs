using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UserAPI.Models;
using UserAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("GetArticles")]
        public JsonResult GetArticles()
        {
            List<Article> articles = _articleService.GetArticles();

            return new JsonResult(articles);
        }

        [HttpPost]
        [Route("AddArticle")]
        public bool AddArticle([FromBody] Article article)
        {
            Result result = _articleService.AddArticle(article);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool EditArticle([FromQuery] Article article)
        {
            Result result = _articleService.EditArticle(article);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool RemoveArticle(int articleId)
        {
            Result result = _articleService.RemoveArticle(articleId);
            if (result.IsFailed) return false;
            return true;
        }
    }
}
