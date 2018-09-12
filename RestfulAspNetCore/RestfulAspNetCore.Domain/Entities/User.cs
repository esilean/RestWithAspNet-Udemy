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

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string ClientSecret { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Created { get; set; }

        public bool IsActive { get; set; }

    }
}
