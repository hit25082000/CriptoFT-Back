using System.ComponentModel.DataAnnotations;
using UserAPI.Models;

namespace UserAPI.Data.Dtos
{
    public class ProfileDto
    {
        [Required]
        public User user { get; set; }
        [Required]
        public IFormFile icone { get; set; }
        [Required]
        public List<Video> AulasAssistidas { get; set; }
        public string sobre { get; set; }

    }
}
