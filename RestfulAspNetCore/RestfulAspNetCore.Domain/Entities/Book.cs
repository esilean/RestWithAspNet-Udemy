using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            
        }

        [Key]
        public int? Id
        {
            get;
            set;
        }public string Title
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public DateTime LaunchDate
        {
            get;
            set;
        }
    }
}
