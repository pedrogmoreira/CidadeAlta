using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CidadeAlta.Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "The UserName is Required")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
