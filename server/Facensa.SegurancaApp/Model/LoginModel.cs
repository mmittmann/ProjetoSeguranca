using System.ComponentModel.DataAnnotations;
using Facensa.SegurancaApp.CustomValidations;

namespace Facensa.SegurancaApp.Model
{
    public class LoginModel
    {
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [StrongPassword(ErrorMessage = "Senha fraca")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}