using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field cannot be null")]
        public string BookName { get; set; }

        public string BookAuthor { get; set; }

        public string ISBN { get; set; }
    }
}
