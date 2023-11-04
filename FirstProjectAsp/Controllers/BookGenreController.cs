using FirstProjectAsp.Models;
using FirstProjectAsp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectAsp.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class BookGenreController : Controller
    {
        private readonly IBookGenreRepository _bookGenreRepository;
        public BookGenreController(IBookGenreRepository context)
        {
            _bookGenreRepository = context;
        }
        public IActionResult Index()
        {
            List<BookGenre> objBookGenreList = _bookGenreRepository.GetAll().ToList();
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
                _bookGenreRepository.Add(bookGenre);
                _bookGenreRepository.Save();
                TempData["basarili"] = "Yeni kitap türü başarıyla eklendi!";
                return RedirectToAction("Index");
            }
         
                return View();

        }

        public IActionResult updateGenre(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
                BookGenre? bookGenreDb = _bookGenreRepository.Get(u=>u.Id==id); //Expression<Func<T, bool>> filter
            if (bookGenreDb == null)
            {
                return NotFound();  
            }
            return View(bookGenreDb);   
        }


        [HttpPost]
        public IActionResult updateGenre(BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                _bookGenreRepository.UpdateBookGenre(bookGenre);
                _bookGenreRepository.Save();
                TempData["basarili"] = "Kitap türü başarıyla güncellendi!";
                return RedirectToAction("Index");
            }
                return View();
        }


        public IActionResult deleteGenre(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookGenre? bookGenreDb = _bookGenreRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (bookGenreDb == null)
            {
                return NotFound();
            }
            return View(bookGenreDb);
        }

        [HttpPost, ActionName("deleteGenre")]
        public IActionResult deletedGenre(int? id)
        {
            BookGenre? bookGenre = _bookGenreRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (bookGenre == null)
            {
                return NotFound();  
            }
            _bookGenreRepository.Delete(bookGenre);
            _bookGenreRepository.Save();
            TempData["basarili"] = "Kitap türü başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }


} 
