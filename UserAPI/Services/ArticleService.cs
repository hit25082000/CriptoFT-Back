using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;
using UserAPI.Data;
using UserAPI.Data.Dtos;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class ArticleService
    {
        private UserDbContext _context;
        private IMapper _map;

        public ArticleService(IMapper mapper, UserDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        internal List<Article> GetArticles()
        {
            List<Article> Articles = _context.Articles.Where(x => x.Id == x.Id).ToList();

            return Articles;
        }

        public Result AddArticle(Article Article)
        {
            _context.Articles.Add(Article);

            _context.SaveChanges();            
            
            return Result.Ok();
        }

        public Result EditArticle(Article Article)
        {
            _context.Articles.Update(Article);

            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result RemoveArticle(int articleId)
        {
            var article = _context.Articles.Find(articleId);

            _context.Articles.Remove(article);

            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
