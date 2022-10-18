using System.ComponentModel.DataAnnotations;

namespace UserAPI.Data.Requests
{
    public class RequestPasswordResetRequest
    {
        [Required]
        public string Email { get; set; }        

    }
}
