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
    public class NoticiaService
    {
        private UserDbContext _context;
        private IMapper _map;

        public NoticiaService(IMapper mapper, UserDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        internal List<Noticia> GetNoticias()
        {
            List<Noticia> noticias = _context.Noticias.Where(x => x.Id == x.Id).ToList();

            return noticias;
        }

        public Result AddNoticia(Noticia noticia)
        {
            _context.Noticias.Add(noticia);

            _context.SaveChanges();            
            
            return Result.Ok();
        }

        public Result EditNoticia(Noticia noticia)
        {
            _context.Noticias.Update(noticia);

            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result RemoveNoticia(int noticiaId)
        {
            var noticia = _context.Noticias.Find(noticiaId);

            _context.Noticias.Remove(noticia);

            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
