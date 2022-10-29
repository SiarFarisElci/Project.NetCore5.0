using System.ComponentModel.DataAnnotations;

namespace Project.COREUI.Models
{
    public class SingUpVM
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz!")]
        public string password { get; set; }
    }
}
