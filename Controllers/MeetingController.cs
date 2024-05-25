using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        //Üstüne [HttpPost] veya attribute eklemediğimiz her metod HTTP GET olarak kabul edilir.
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost] //kullanıcı bilgilerini işlemek için kullanılan metod.
        public IActionResult Apply(UserInfo model)  
        {
            if (ModelState.IsValid)
            {
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(info=>info.WillAttend == true).Count();
                return View("Thanks", model);
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult List() // Kullanıcı listesini görüntülemek için kullanılan metod.
        {
            return View(Repository.Users);
        }

        public IActionResult Details(int id) // Belirli bir kullanıcının detaylarını görüntülemek için kullanılan metod.
        {
            return View(Repository.GetById(id));
        }
    }
}