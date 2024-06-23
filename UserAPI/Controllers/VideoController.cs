using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UserAPI.Models;
using UserAPI.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("/videos-user")]
        [HttpGet]
        public JsonResult GetVideosUser(int userId)
        {
            List<Video> aulas = _videoService.GetVideos(userId);

            return new JsonResult(aulas);
        }

        [HttpPost]
        public bool AddVideo([FromQuery] Video video, int userId)
        {
            Result result = _videoService.AddVideo(video, userId);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool EditVideo([FromQuery] Video video, int userId)
        {
            Result result = _videoService.EditVideo(video);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool RemoveVideo(int videoId)
        {
            Result result = _videoService.RemoveVideo(videoId);
            if (result.IsFailed) return false;
            return true;
        }
    }
}
