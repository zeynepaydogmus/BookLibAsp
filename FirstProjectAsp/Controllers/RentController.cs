using FirstProjectAsp.Models;
using FirstProjectAsp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectAsp.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class RentController : Controller
    {
        private readonly IRentRepository _rentRepository;
        //FK
        private readonly IBookRepository _bookRepository;
        //verileri çek al yardımcı sınıf (.Net fw sınıfı)
        public readonly IWebHostEnvironment _webHostEnvironment;

        public RentController(IRentRepository rentRepository, IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
        {
            //newlemeden nesne direkt oluştu, kullandık.
            _rentRepository = rentRepository;
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //includeProps FK
            List<Rent> objRentList = _rentRepository.GetAll(includeProps:"Book").ToList();

            return View(objRentList);
        }
        public IActionResult newAddUpdate(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.BookName,
                Value = k.Id.ToString()
            });
            ViewBag.BookList = BookList;
            if(id==null || id == 0)
            {
                //add
                return View();
            }
            else
            {
                //update
                Rent? rentDb = _rentRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
                if (rentDb == null)
                {
                    return NotFound();
                }
                return View(rentDb);
            }
        }
        [HttpPost]
        public IActionResult newAddUpdate(Rent rent)
        {
            if(ModelState.IsValid)
            {
       
                if (rent.Id == 0)
                {
                    _rentRepository.Add(rent);
                    TempData["basarili"] = "Yeni kitap kiralama başarıyla oluşturuldu!";
                }
                else
                {
                    _rentRepository.UpdateRent(rent);
                    TempData["basarili"] = "Kitap kiralama başarıyla güncellendi!";
                }
                _rentRepository.Save();
               
             
                return RedirectToAction("Index" , "Rent");
            }
         
                return View();

        }


        public IActionResult delete(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.BookName,
                Value = k.Id.ToString()
            });
            ViewBag.BookList = BookList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Rent? rentDb = _rentRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (rentDb == null)
            {
                return NotFound();
            }
            return View(rentDb);
        }

        [HttpPost, ActionName("delete")]
        public IActionResult deleted(int? id)
        {
            Rent? rent = _rentRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filter
            if (rent== null)
            {
                return NotFound();  
            }
            _rentRepository.Delete(rent);
            _rentRepository.Save();
            TempData["basarili"] = "Kitap kiralama başarıyla silindi!";
            return RedirectToAction("Index","Rent");
        }
    }


} 
