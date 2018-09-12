using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Application.Model
{
    public class UserModel
    {
        public UserModel()
        {

        }

        [Key]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ClientSecret { get; set; }


    }
}
