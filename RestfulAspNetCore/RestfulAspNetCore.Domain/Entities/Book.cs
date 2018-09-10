using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAspNetCore.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Column("id")]
        public string Id
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
