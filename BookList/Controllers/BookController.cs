using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Controllers
{

    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly BookListDbContext _db;

        public BookController(BookListDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        //-----

        public async Task<IActionResult> Delete(int id)
        {
            var dbCurrentBook = await _db.Book.FirstOrDefaultAsync(x=>x.BookId==id);

            if (dbCurrentBook == null)
            {
                return Json(new{success=false, message="The book was could not be deleted"});
            }
            else
            {
                _db.Book.Remove(dbCurrentBook);
                await _db.SaveChangesAsync();
                return Json(new { success=true, message = "The book was removed" });
            }
        }
    }
}
