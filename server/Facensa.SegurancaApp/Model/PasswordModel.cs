using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facensa.SegurancaApp.Model
{
    public class PasswordModel
    {
        public string Id { get; set; }

        [Display(Name = "Sistema")]
        public string System { get; set; }

        [Display(Name = "Usuário")]
        public string User { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}