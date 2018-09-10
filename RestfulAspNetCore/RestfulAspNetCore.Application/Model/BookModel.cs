using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Application.Model
{
    public class BookModel
    {
        public BookModel()
        {

        }

        [Key]
        [Required]
        public int? Id
        {
            get;
            set;
        }
        [Required]
        public string Title
        {
            get;
            set;
        }
        [Required]
        public string Author
        {
            get;
            set;
        }
        [Required]
        public decimal Price
        {
            get;
            set;
        }
        [Required]
        public DateTime LaunchDate
        {
            get;
            set;
        }
    }
}
