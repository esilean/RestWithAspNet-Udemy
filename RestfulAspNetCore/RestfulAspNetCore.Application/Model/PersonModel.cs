﻿using System.ComponentModel.DataAnnotations;

namespace RestfulAspNetCore.Application.Model
{
    public class PersonModel
    {

        public PersonModel()
        {

        }
        public int? Id
        {
            get;
            set;
        }
        [Required]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        public string LastName
        {
            get;
            set;
        }
        [Required]
        public string Address
        {
            get;
            set;
        }
        [Required]
        public string Gender
        {
            get;
            set;
        }
    }
}
