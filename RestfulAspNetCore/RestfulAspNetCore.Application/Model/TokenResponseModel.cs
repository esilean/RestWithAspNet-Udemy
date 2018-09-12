using System.ComponentModel.DataAnnotations;

namespace RestfulAspNetCore.Application.Model
{
    public class TokenResponseModel
    {
        public TokenResponseModel()
        {

        }

        [Key]
        [Required]
        public string access_token { get; set; }

        [Required]
        public string expires_in { get; set; }

        [Required]
        public string refresh_token { get; set; }

    }
}
