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
    public class AulaService
    {
        private UserDbContext _context;
        private IMapper _map;

        public AulaService(IMapper mapper, UserDbContext context)
        {
            _context = context;
            _map = mapper;
        }

        internal List<Aula> GetAulas(int userId)
        {
            List<Aula> aulas = _context.Aulas.Where(a => a.Id == userId).ToList();

            return aulas;
        }

        public Result AddAula(Aula aula,int userId)
        {
            var user = _context.Users.Find(userId.ToString());

            aula.User = _map.Map<User>(user);

            _context.Aulas.Add(aula);

            _context.SaveChanges();            
            
            return Result.Ok();
        }

        public Result EditAula(Aula aula)
        {
            _context.Aulas.Update(aula);

            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
