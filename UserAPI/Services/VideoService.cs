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
    public class VideoService
    {
        private UserDbContext _context;
        private IMapper _map;

        public VideoService(IMapper mapper, UserDbContext context)
        {
            _context = context;
            _map = mapper;
        }

        internal List<Video> GetVideos(int userId)
        {
            List<Video> video = _context.Videos.Where(a => a.Id == userId).ToList();

            return video;
        }

        public Result AddVideo(Video video, int userId)
        {
            _context.Videos.Add(video);

            _context.SaveChanges();            
            
            return Result.Ok();
        }

        public Result EditVideo(Video video)
        {
            _context.Videos.Update(video);

            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result RemoveVideo(int videoId)
        {
            var video = _context.Videos.Find(videoId);

            _context.Videos.Remove(video);

            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
