using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class BookListDbContext:DbContext
    {
        public BookListDbContext(DbContextOptions<BookListDbContext> options):base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
