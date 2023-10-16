using FirstProjectAsp.Models;
using FirstProjectAsp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectAsp.Controllers
{
    public class BookGenreController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BookGenreController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public IActionResult Index()
        {
            List<BookGenre> objBookGenreList= _applicationDbContext.BookGenres.ToList();    
            return View(objBookGenreList);
        }
        public IActionResult newGenreAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult newGenreAdd(BookGenre bookGenre)
        {
            if(ModelState.IsValid)
            {
                _applicationDbContext.BookGenres.Add(bookGenre);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }
    }
} 
