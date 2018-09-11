using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Domain.Entities
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

    }
}
