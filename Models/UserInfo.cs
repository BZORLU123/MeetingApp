using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        
        //ErrorMessage istediğimiz hata mesajını yazdırmak için kullanılır.
        [Required(ErrorMessage ="Ad Giriniz")] 
        public string? Name { get; set; }
        [Required(ErrorMessage ="Telefon Numarası Giriniz")]
        public string? Phone { get; set; }
        [Required(ErrorMessage ="E-Posta Giriniz")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Durum Seçiniz")]
        public bool? WillAttend { get; set; }
    }
}