using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class VerifyUserRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
