using FirstProjectAsp.Models;
using FirstProjectAsp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectAsp.Controllers
{
    
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookGenreRepository _bookGenreRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, IBookGenreRepository bookGenreRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _bookGenreRepository = bookGenreRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize(Roles = "Admin, Student")]
        public IActionResult Index()
        {
            
            List<Book> objBookList = _bookRepository.GetAll(includeProps:"BookGenre").ToList();

            return View(objBookList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult newAddUpdate(int? id)
        {
            IEnumerable<SelectListItem> BookGenreList = _bookGenreRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.Name,
                Value = k.Id.ToString()
            });
            ViewBag.BookGenreList = BookGenreList;
            if(id==null || id == 0)
            {
                //add
                return View();
            }
            else
            {
                //update
                Book? bookDb = _bookRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
                if (bookDb == null)
                {
                    return NotFound();
                }
                return View(bookDb);
            }
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult newAddUpdate(Book book, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string bookPath = Path.Combine(wwwRootPath, @"img");
                if (file!= null)
                {
                    using (var fileStream = new FileStream(Path.Combine(bookPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    book.ImageUrl = @"\img\" + file.FileName;
                }
     
                if (book.Id == 0)
                {
                    _bookRepository.Add(book);
                    TempData["basarili"] = "Yeni kitap başarıyla eklendi!";
                }
                else
                {
                    _bookRepository.UpdateBook(book);
                    TempData["basarili"] = "Kitap başarıyla güncellendi!";
                }
                _bookRepository.Save();
               
             
                return RedirectToAction("Index");
            }
         
                return View();

        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? bookDb = _bookRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (bookDb == null)
            {
                return NotFound();
            }
            return View(bookDb);
        }

        [HttpPost, ActionName("delete")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult deleted(int? id)
        {
            Book? book = _bookRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (book== null)
            {
                return NotFound();  
            }
            _bookRepository.Delete(book);
            _bookRepository.Save();
            TempData["basarili"] = "Kitap türü başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }


} 
