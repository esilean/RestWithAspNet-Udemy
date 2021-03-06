﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Application.Model
{
    public class UserLoginModel
    {
        public UserLoginModel()
        {

        }

        [Key]
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        [Required]
        public string Grant_type { get; set; }

        public string Refresh_token { get; set; }

    }
}
