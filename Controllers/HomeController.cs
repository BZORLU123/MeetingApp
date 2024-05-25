using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetinApp.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index() 
        {
            // Geçerli saat bilgisini al
            int saat = DateTime.Now.Hour;

            // Saat 12'den büyükse "İyi günler", değilse "Günaydın" selamlaması yap
            ViewBag.selamlama = saat > 12 ? "İyi günler":"Günaydın";

            // Toplantıya katılacak kullanıcıların sayısını hesapla 
            int usercount = Repository.Users.Where(info => info.WillAttend==true).Count(); //LINQ

            // Toplantı bilgilerini içeren yeni bir MeetingInfo nesnesi oluştur
            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "Ankara, Atatürk Kongre Merkezi",
                Date = new DateTime(2024,06,01,20,0,0),
                NumberOfPeople = usercount 
            };
            return View(meetingInfo);
        }
    }
}